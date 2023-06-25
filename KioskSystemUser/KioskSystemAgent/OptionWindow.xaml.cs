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

namespace KioskSystemAgent
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

        private void GetCustomer(object sender, RoutedEventArgs e)
        {
            GetCustomerInfoWindow window = new GetCustomerInfoWindow();
            window.Show();
            this.Close();
        }

        private void Serving(object sender, RoutedEventArgs e)
        {
            MarkServingWindow window = new MarkServingWindow();
            window.Show();
            this.Close();
        }

        private void Served(object sender, RoutedEventArgs e)
        {
            MarkServedWindow window = new MarkServedWindow();
            window.Show();
            this.Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
