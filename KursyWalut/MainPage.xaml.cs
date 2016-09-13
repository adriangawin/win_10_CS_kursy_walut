using KursyWalut.helpers;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KursyWalut
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        String[] FileNameList;

        private async Task GetDates()
        {
            String responseBody = await GetContentFromNBP("http://www.nbp.pl/kursy/xml/dir.txt");
            FileNameList = responseBody.Split('\n');
            for (int s = 0; s < FileNameList.Length; s++)
                FileNameList[s] = FileNameList[s].Trim('\r');
            for (int s = 0; s < FileNameList.Length - 1; s++)
            {
                if (!FileNameList[s].Substring(0, 1).Equals("a"))
                    continue;
                string xml_url = @"http://www.nbp.pl/kursy/xml/" + FileNameList[s] + "@.xml";
                string dateItem = ExtractDateFromFileName(FileNameList[s]);
                if (!dateList.Items.Contains(dateItem))
                {
                    dateList.Items.Add(dateItem);
                }
            }
        }

        private async void pobierz_Click(object sender, RoutedEventArgs e)
        {
            info.Text = "pobieranie...";
            await GetDates();
            info.Text = "zakończono";
            dateList.SelectedIndex = this.dateList.Items.Count - 1; 
        }

        private async void ProccedWithXML(String xml_url)
        {
            XDocument loadedXML = XDocument.Parse(await GetXMLContent(xml_url));
            if (loadedXML.ToString().Length != 0)
            {
                ExtractDataFromXML(loadedXML);
            }
        }

        private void Listbox_daty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmpS = (string)dateList.SelectedItem;
            tmpS = tmpS.Substring(2, 2) + tmpS.Substring(5, 2) + tmpS.Substring(8, 2);
            foreach (string ss in FileNameList)
            {
                if (!ss.Substring(0, 1).Equals("a"))
                    continue;
                if (ss.Substring(5, 6).Equals(tmpS))
                {
                    tmpS = ss;
                    break;
                }
            }
            //info.Text = "pobieranie...";
            ProccedWithXML(@"http://www.nbp.pl/kursy/xml/" + tmpS + @".xml");
            //info.Text = "data: " + FileNameList[FileNameList.Length-1];
        }
        private string ExtractDateFromFileName(string fileName)
        {
            return "20" + fileName.Substring(5, 2) + "-" + fileName.Substring(7, 2) + "-" + fileName.Substring(9, 2);
        }

        private async Task<string> GetContentFromNBP(string NBPurl)
        {
            String responseBody;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri(NBPurl));//GET
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        private async Task<string> GetXMLContent(string xmlURL)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseXML = await client.GetAsync(new Uri(xmlURL));
            responseXML.EnsureSuccessStatusCode();
            String responseBodyXML = await responseXML.Content.ReadAsStringAsync();
            return responseBodyXML;
        }
        private void ExtractDataFromXML(XDocument XMLdata)
        {
            var data = from query in XMLdata.Descendants("pozycja")
                       select new Waluta
                       {
                           NazwaKraju = (string)query.Element("nazwa_waluty"),
                           KodWaluty = (string)query.Element("kod_waluty"),
                           KursSredni = (string)query.Element("kurs_sredni")
                       };
            listBox_waluty.ItemsSource = data;

        }

        private void button_exitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
    }

}
