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
    /// Interaction logic for BranchCreationWindow.xaml
    /// </summary>
    public partial class BranchCreationWindow : Window
    {
        public BranchCreationWindow()
        {
            InitializeComponent();
        }

        private void AddServiceID(object sender, RoutedEventArgs e)
        {
            var ser = Branch.Children[Branch.Children.Count - 2];
            int s = int.Parse(ser.Uid);
            int max = 5;
            if (s != max)
            {
                AddNewServiceIDStack(s);
            }
            else
            {
                MessageBox.Show("Cannot Add More Questions");
            }
        }

        public void AddNewServiceIDStack(int s)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(10);
            panel.Uid = $"{s + 1}";
            Label label = new Label();
            label.Height = 40;
            label.Width = 200;
            label.Margin = new Thickness(0, 0, 10, 0);
            label.FontWeight = FontWeights.Bold;
            label.FontSize = 25;
            label.Content = $"ServiceID{s + 1}:";
            panel.Children.Add(label);

            TextBox textBox = new TextBox();
            RegisterName($"ServiceID{s + 1}", textBox);
            textBox.Height = 40;
            textBox.Width = 200;
            textBox.Margin = new Thickness(0, 0, 10, 0);
            textBox.FontWeight = FontWeights.Bold;
            textBox.FontSize = 25;
            panel.Children.Add(textBox);

            Branch.Children.Insert(Branch.Children.Count - 1, panel);

        }


        private void Submit(object sender, RoutedEventArgs e)
        {
            var ser = Branch.Children[Branch.Children.Count - 2];
            int s = int.Parse(ser.Uid);
            CommonResponseDTO<Branch> commonResponseDTO = new CommonResponseDTO<Branch>();
            Branch branch = new Branch();
            branch.Region = Region.Text;
            branch.CompanyId = int.Parse(CompanyID.Text);
            branch.ServiceIds = new int[s];
            for (int i = 0; i < s; i++)
            {
                TextBox serID = Branch.FindName($"ServiceID{i + 1}") as TextBox;
                branch.ServiceIds[i] = int.Parse(serID.Text);
            }

            if (branch != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    commonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Branch", branch).Result.Content.ReadFromJsonAsync<CommonResponseDTO<Branch>>().Result;
                }

                if (commonResponseDTO != null)
                {
                    MessageBox.Show(commonResponseDTO.Message);
                    BranchCreationWindow BranchCre = new BranchCreationWindow();
                    BranchCre.Show();
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
