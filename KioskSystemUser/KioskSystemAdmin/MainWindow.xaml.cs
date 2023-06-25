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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KioskSystemAdmin
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
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "" && Password.Password != "")
            {
                Admin admin= new Admin();
                admin.AdminName = Username.Text;
                admin.Password = Password.Password;
                AdminLogin(admin);
            }
            else
            {
                MessageBox.Show("Enter Correct Username and Password!!");
            }
        }

        public void AdminLogin(Admin admin)
        {
            CommonResponseDTO<int> commonResponseDTO = new CommonResponseDTO<int>();
            using (HttpClient client = new HttpClient())
            {
                commonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Admin", admin).Result.Content.ReadFromJsonAsync<CommonResponseDTO<int>>().Result;
            }

            if (commonResponseDTO.Data > 0)
            {
                MessageBox.Show("Login Successfull!!!");
                OptionWindow optionWindow = new OptionWindow();
                optionWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed!!!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
