using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for GetCustomerInfoWindow.xaml
    /// </summary>
    public partial class GetCustomerInfoWindow : Window
    {
        public GetCustomerInfoWindow()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            OptionWindow option = new OptionWindow();
            option.Show();
            this.Close();
        }

        private void Get(object sender, RoutedEventArgs e)
        {
            if (TokenNo.Text != "" && CounterID.Text != "")
            {
                CommonResponseDTO<List<Customer>> customer = new CommonResponseDTO<List<Customer>>();
                int id = int.Parse(CounterID.Text);
                using (HttpClient client = new HttpClient())
                {
                    customer = client.GetFromJsonAsync<CommonResponseDTO<List<Customer>>>($"https://localhost:44373/Api/Customer/{id}?Token={TokenNo.Text}").Result;
                }
                if (customer != null)
                {
                    foreach (var item in customer.Data)
                    {
                        StackPanel panel = new StackPanel();
                        Label label = new Label();
                        CustomerInformation.Children.Remove(CounterPanel);
                        CustomerInformation.Children.Remove(TokenPanel);
                        Cusotmer.Children.Remove(Controls);
                        CustomerInformation.Width += 100; 


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Customer ID:");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.CustomerId.ToString());
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;

                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Branch ID:");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.BranchID.ToString());
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Service Type:");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.ServiceType.ToString());
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Counter ID:");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.CounterID.ToString());
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Status");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.Status);
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Token");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.Token);
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;


                        panel = AddInformationStackPanel();
                        label = AddInformationLabel("Status ID");
                        panel.Children.Add(label);
                        label = AddInformationLabel(item.StatusID.ToString());
                        panel.Children.Add(label);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;

                        //StackPanel panel2 = new StackPanel();
                        //panel2.Orientation = Orientation.Horizontal;
                        //panel2.Margin = new Thickness(0, 0, 0, 10);

                        string[] answers = item.Answers.Split(','); 
                        foreach (var item1 in answers)
                        {
                            panel = AddInformationStackPanel();
                            label = AddInformationLabel($"Answer{Array.IndexOf(answers,item1) + 1}");
                            panel.Children.Add(label);
                            label = AddInformationLabel(item1);
                            panel.Children.Add(label);
                            CustomerInformation.Children.Add(panel);
                            CustomerInformation.Height += 30;
                        }

                        Button button = new Button();
                        panel = AddInformationStackPanel();
                        panel.HorizontalAlignment = HorizontalAlignment.Center;
                        button = AddBackButton();
                        panel.Children.Add(button);
                        CustomerInformation.Children.Add(panel);
                        CustomerInformation.Height += 30;
                    }
                }
            }else
            {
                MessageBox.Show("Enter Correct TokenNo and CounterID");
            }
        }

        public Label AddInformationLabel(string Info)
        {
            Label label = new Label();
            label.Height = 45;
            label.Width = 340;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Margin = new Thickness(0, 0, 10, 0);
            label.FontWeight = FontWeights.Bold;
            label.FontSize = 25;
            label.Content = Info;
            //CustomerInformation.Children.Add(label);
            return label;
        }



        public StackPanel AddInformationStackPanel()
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(0, 0, 0, 10);
            return panel;
        }

        public Button AddBackButton()
        {
            Button button = new Button();
            button.Height = 50;
            button.Width = 150;
            button.Content = "Back";
            button.FontSize = 25;
            button.FontWeight = FontWeights.Bold;
            button.Margin = new Thickness(0, 0, 10, 0);
            button.Background = new SolidColorBrush(Colors.BlueViolet);
            button.Click += (ss, ee) => {
                OptionWindow window = new OptionWindow();
                window.Show();
                this.Close();
            };

            return button;
        }
    }
}
