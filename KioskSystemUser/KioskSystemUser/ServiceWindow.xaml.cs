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
using System.Xml.Serialization;

namespace KioskSystemUser
{
    /// <summary>
    /// Interaction logic for ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public int QuestionCount = 0;
        public int BranchID = 0;
        public int ServiceID = 0;
        public ServiceWindow()
        {
            InitializeComponent();
        }

        public void DisplayQuestions(int ServiceID, int Branch)
        {
            this.ServiceID = ServiceID;
            this.BranchID = Branch;
            CommonResponseDTO<List<Questions>> commonResponseDTO = new CommonResponseDTO<List<Questions>>();    
            using (HttpClient client = new HttpClient())
            {
                commonResponseDTO = client.GetFromJsonAsync<CommonResponseDTO<List<Questions>>>($"https://localhost:44373/Api/Question/{ServiceID}").Result;
                QuestionCount = commonResponseDTO.Data.Count();
                foreach (var item in commonResponseDTO.Data)
                {
                    StackPanel QuestionPanel = new StackPanel();
                    Label QuestionLabel = new Label();
                    TextBox AnswerText = new TextBox();

                    QuestionPanel = AddQuestionStackPanel(item.QuestionID);
                    QuestionLabel = AddQuestionLabel(item.Question, item.QuestionID);
                    AnswerText = AddAnswerTexts(item.QuestionID);

                    QuestionPanel.Children.Add(QuestionLabel);
                    QuestionPanel.Children.Add(AnswerText);

                    DynamicQuestions.Children.Add(QuestionPanel);
                    DynamicQuestions.Height += 30;
                }
            }
        }

        public StackPanel AddQuestionStackPanel(int i)
        {
            StackPanel panel = new StackPanel();
            panel.Name = $"Panel{i}";
            panel.Orientation = Orientation.Horizontal;
            panel.Margin = new Thickness(0,0,0,20);
            return panel;
        }
        public Label AddQuestionLabel(string Question, int QuestionID)
        {
            Label label = new Label();
            label.Height = 40;
            label.Width = 340;
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.Margin = new Thickness(0,0,10,0);
            label.FontWeight = FontWeights.Bold;
            label.FontSize = 25;
            label.Content = Question;
            label.Name = $"Question{QuestionID}";
            return label;
        }

        public TextBox AddAnswerTexts(int QuestionID)
        {
            TextBox textBox = new TextBox();
            textBox.Height = 40;
            textBox.Width = 300;
            textBox.Name = $"Answer{QuestionID}";
            textBox.BorderThickness = new Thickness(2);
            textBox.FontSize = 25;
            textBox.BorderBrush = new SolidColorBrush(Colors.Gray);
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.AcceptsReturn = true;
            return textBox;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            CommonResponseDTO<Token> token = new CommonResponseDTO<Token>();
            Answer answer = new Answer();
            answer.Answers = new string[QuestionCount];
            answer.QuestionsID = new int[QuestionCount];
            for (int i = 0; i < QuestionCount; i++)
            {
                StackPanel stack = (StackPanel)DynamicQuestions.Children[i];
                TextBox textBox = (TextBox)stack.Children[1];
                answer.Answers[i] = textBox.Text.Trim();
                answer.QuestionsID[i] = i + 1;
            }
            answer.BranchID = BranchID;
            answer.ServiceID = ServiceID;

            using(HttpClient client = new HttpClient())
            {
                token = client.PostAsJsonAsync($"https://localhost:44373/Api/Answer", answer).Result.Content.ReadFromJsonAsync<CommonResponseDTO<Token>>().Result;
            }

            TokenDisplayWindow TokenDisplay = new TokenDisplayWindow();
            TokenDisplay.Show();
            TokenDisplay.UpdateFields(token.Data.TokenID, token.Data.CounterID);
            this.Close();
        }
    }
}
