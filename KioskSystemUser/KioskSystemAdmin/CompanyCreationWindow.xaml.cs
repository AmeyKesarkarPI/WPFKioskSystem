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

namespace KioskSystemAdmin
{
    /// <summary>
    /// Interaction logic for CompanyCreationWindow.xaml
    /// </summary>
    public partial class CompanyCreationWindow : Window
    {
        public CompanyCreationWindow()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            CommonResponseDTO<Company> commonResponseDTO = new CommonResponseDTO<Company>();
            Company company = new Company();
            company.CompanyName = CompanyName.Text;

            if (company != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    commonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Company", company).Result.Content.ReadFromJsonAsync<CommonResponseDTO<Company>>().Result;
                }

                if (commonResponseDTO != null)
                {
                    MessageBox.Show(commonResponseDTO.Message);
                    CompanyCreationWindow companyCreation = new CompanyCreationWindow();
                    companyCreation.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter All Fields");
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
