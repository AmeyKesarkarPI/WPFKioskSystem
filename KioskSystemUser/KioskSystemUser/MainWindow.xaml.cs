using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KioskSystemUser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class CommonResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int Branch = GetBranch();
            DisplayWelcomeMsg(Branch);
        }
        public int GetBranch()
        {
            int BranchId = 0;
            string s = "";
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ServicePin.txt";
            if (File.Exists(filepath))
            {
                s = File.ReadAllText(filepath);
            }
            if (s != null || s != "")
            {
                string[] sarray = s.Split('=');
                BranchId = int.Parse(sarray[1]);
            }
            return BranchId;
        }


        public void DisplayWelcomeMsg(int Branch)
        {

            CommonResponseDTO<ServiceBranch> CommonResponseDTO = new CommonResponseDTO<ServiceBranch>();
            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.GetFromJsonAsync<CommonResponseDTO<ServiceBranch>>($"https://localhost:44373/Api/Branch/{Branch}").Result;

                if (CommonResponseDTO.Success == true)
                {
                    ServiceBranch Sb = CommonResponseDTO.Data;
                    WelcomeMsg.Content = $"Welcome To {Sb.CompanyName} {Sb.BranchName}";
                    DisplayQuestions(Branch);
                }
                else
                {
                    WelcomeMsg.Content = $"Out Of Service";
                }
            }
        }

        public void DisplayQuestions(int Branch)
        {
            CommonResponseDTO<List<Service>> CommonResponseDTO = new CommonResponseDTO<List<Service>>();
            using (HttpClient client = new HttpClient())
            {
                CommonResponseDTO = client.GetFromJsonAsync<CommonResponseDTO<List<Service>>>($"https://localhost:44373/Api/Kiosk/{Branch}").Result;

                foreach (var item in CommonResponseDTO.Data)
                {
                    AddServiceButton(item.ServiceName, item.ServiceID, Branch);
                }
            }
        }

        public void AddServiceButton(string text, int i, int Branch)
        {
            Button button = new Button();
            button.Name = $"ServiceName{i}";
            button.Height = 50;
            button.Width = 340;
            button.Content = text;
            button.FontSize = 20;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.FontWeight = FontWeights.Bold;
            button.Background = new SolidColorBrush(Colors.BlanchedAlmond);
            button.BorderBrush = new SolidColorBrush(Colors.BurlyWood);
            button.BorderThickness = new Thickness(2);
            button.Margin = new Thickness(5);
            button.Click += (ss, ee) => { 
                ServiceWindow service = new ServiceWindow();
                service.Show();
                this.Close();
                service.DisplayQuestions(i,Branch);
            };

            DynamicServices.Children.Add(button);
            DynamicServices.Height += 50;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
