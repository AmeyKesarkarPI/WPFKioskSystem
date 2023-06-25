using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KioskSystemAgent
{
    /// <summary>
    /// Interaction logic for MarkServingWindow.xaml
    /// </summary>
    public partial class MarkServingWindow : Window
    {
        public MarkServingWindow()
        {
            InitializeComponent();
        }


        private void Set(object sender, RoutedEventArgs e)
        {

            if (TokenNo.Text != "" && CounterID.Text != "")
            {
                CommonResponseDTO<string> CsStr = new CommonResponseDTO<string>();
                Customer customer = new Customer();
                int id = int.Parse(CounterID.Text);
                customer.Token = TokenNo.Text;
                customer.CounterID = id;
                using (HttpClient client = new HttpClient())
                {
                    CsStr = client.PostAsJsonAsync($"https://localhost:44373/Api/Customer", customer).Result.Content.ReadFromJsonAsync<CommonResponseDTO<string>>().Result;
                }
                if (CsStr.Success == true)
                {
                    MessageBox.Show(CsStr.Message);
                }
                else
                {
                    MessageBox.Show("Customer Not Found");
                }
            }
            else
            {
                MessageBox.Show("Enter Correct TokenNo and CounterID");
            }
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            OptionWindow optionWindow = new OptionWindow();
            optionWindow.Show();
            this.Close();
        }
    }
}
