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

namespace KioskSystemUser
{
    /// <summary>
    /// Interaction logic for TokenDisplayWindow.xaml
    /// </summary>
    public partial class TokenDisplayWindow : Window
    {
        public TokenDisplayWindow()
        {
            InitializeComponent();
        }

        public void UpdateFields(string token,int counter)
        {
            CounterText.Content = counter.ToString();
            TokenText.Content = token;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
