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
    /// Interaction logic for QuestionCreationWindow.xaml
    /// </summary>
    public partial class QuestionCreationWindow : Window
    {
        public QuestionCreationWindow()
        {
            InitializeComponent();
        }



        private void AddQuestion(object sender, RoutedEventArgs e)
        {
            var ser = Service.Children[Service.Children.Count - 2];
            int s = int.Parse(ser.Uid);
            int max = 5;
            if (s != max)
            {
                AddNewQuestionStack(s);
            }
            else
            {
                MessageBox.Show("Cannot Add More Questions");
            }
        }

        public void AddNewQuestionStack(int s)
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
            label.Content = $"Question{s + 1}:";
            panel.Children.Add(label);

            TextBox textBox = new TextBox();
            RegisterName($"Question{s + 1}", textBox);
            textBox.Height = 40;
            textBox.Width = 200;
            textBox.Margin = new Thickness(0, 0, 10, 0);
            textBox.FontWeight = FontWeights.Bold;
            textBox.FontSize = 25;
            panel.Children.Add(textBox);

            Service.Children.Insert(Service.Children.Count - 1, panel);

        }


        private void Submit(object sender, RoutedEventArgs e)
        {
            var ser = Service.Children[Service.Children.Count - 2];
            int s = int.Parse(ser.Uid);
            CommonResponseDTO<List<Questions>> commonResponseDTO = new CommonResponseDTO<List<Questions>>();
            Questions question = new Questions();
            question.ServiceID = int.Parse(ServiceID.Text);
            question.Question = new string[s];
            for (int i = 0; i < s; i++)
            {
                TextBox que = Service.FindName($"Question{i + 1}") as TextBox;
                question.Question[i] = que.Text;
            }

            if (question != null)
            {
                using (HttpClient client = new HttpClient())
                {
                    commonResponseDTO = client.PostAsJsonAsync($"https://localhost:44373/Api/Question", question).Result.Content.ReadFromJsonAsync<CommonResponseDTO<List<Questions>>>().Result;
                }

                if (commonResponseDTO != null)
                {
                    MessageBox.Show(commonResponseDTO.Message);
                    QuestionCreationWindow que = new QuestionCreationWindow();
                    que.Show(); 
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
