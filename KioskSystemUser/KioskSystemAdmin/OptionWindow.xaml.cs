using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for OptionWindow.xaml
    /// </summary>
    public partial class OptionWindow : Window
    {
        public OptionWindow()
        {
            InitializeComponent();
        }

        private void ServiceCreation(object sender, RoutedEventArgs e)
        {
            ServiceCreationWindow service = new ServiceCreationWindow();
            service.Show();
            this.Close();
        }

        private void QuestionCreation(object sender, RoutedEventArgs e)
        {
            QuestionCreationWindow question = new QuestionCreationWindow();
            question.Show();
            this.Close();
        }

        private void CompanyCreation(object sender, RoutedEventArgs e)
        {
            CompanyCreationWindow company = new CompanyCreationWindow();
            company.Show();
            this.Close();
        }

        private void BranchCreation(object sender, RoutedEventArgs e)
        {
            BranchCreationWindow branch = new BranchCreationWindow();
            branch.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
