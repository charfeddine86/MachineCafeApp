using MachineCafe.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MachineCafeUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string BaseUrl = "";
        List<DataModelProduit> listProduit = new List<DataModelProduit>();


        public MainWindow()
        {
            InitializeComponent();
            BaseUrl = "http://localhost:49234";
           
            ObservableCollection<string> listItemProduit = new ObservableCollection<string>();
            ObservableCollection<string> listItemMug = new ObservableCollection<string>();

            listProduit =UIHttpGetProduit();    
            foreach (var item in listProduit)
            {
                listItemProduit.Add(item.NomProduit);
            } 
            CBListProduit.ItemsSource = listItemProduit;

            listItemMug.Add("Oui");
            listItemMug.Add("Non");
            CBmug.ItemsSource = listItemMug;
         
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private List<DataModelProduit> UIHttpGetProduit()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = string.Format("api/Commende/GetTypeProduits");
            var result = client.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                Task<string> message = result.Content.ReadAsStringAsync();
                string data = message.Result;

                var responseBody = result.Content.ReadAsStringAsync().Result;
                List<DataModelProduit> obj = JsonConvert.DeserializeObject<List<DataModelProduit>>(responseBody);
                
                return obj;
            }
            return null;
        }

        private DataModelCommende UIHttpGetProduitBynumBadge(int numBadge)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = string.Format("api/Commende/GetCommendeByNumBadge/{0}", numBadge);
            var result = client.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                Task<string> message = result.Content.ReadAsStringAsync();
                string data = message.Result;

                var responseBody = result.Content.ReadAsStringAsync().Result;
                DataModelCommende obj = JsonConvert.DeserializeObject<DataModelCommende>(responseBody);

                return obj;
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listProduit = UIHttpGetProduit();
            int numProduit = 0;
            bool mug = false;


            numProduit = listProduit.FirstOrDefault(c => c.NomProduit == CBListProduit.Text).IdProduit;
            int qteSucre = Convert.ToInt16(TBsucre.Text);
           
            if (CBmug.Text == "Oui")
            {
              mug = true; 
            }

            int numBadge = Convert.ToInt16(TBbadge.Text);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string url = string.Format("api/Commende/GetCommende/{0}/{1}/{2}/{3}", numProduit, qteSucre, mug, numBadge);
            var result = client.GetAsync(url).Result;

            TBbadge.Text = "";
            TBsucre.Text = "";
            CBListProduit.Text = "";
            CBmug.Text = "Oui";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int numBadge = Convert.ToInt16(TBbadge.Text);
            listProduit = UIHttpGetProduit();
            DataModelCommende commende = new DataModelCommende();
            commende = UIHttpGetProduitBynumBadge(numBadge);

            TBsucre.Text = Convert.ToString(commende.QteSucre);
         
            TBsucre.Text = Convert.ToString(commende.QteSucre);
            CBListProduit.Text = listProduit.FirstOrDefault(c => c.IdProduit == commende.NumProduit).NomProduit;
            if (commende.Mug==true)
            {
                CBmug.Text = "Oui";
            }
            else
            {
                CBmug.Text = "Non";
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TBbadge.Text = "";
            TBsucre.Text = "";
            CBListProduit.Text = "";
            CBmug.Text = "Oui";        
        }
    }
}
