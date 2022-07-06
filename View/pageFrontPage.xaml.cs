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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordSaver.View
{
    public partial class pageFrontPage : Page
    {
        public pageFrontPage()
        {
            InitializeComponent();
        }

        private void btnAddPassword_Click(object sender, RoutedEventArgs e)
        {
            pageAddPassword pageAddPassword = new pageAddPassword();
            this.NavigationService.Navigate(pageAddPassword);
        }

        private void btnViewPasswords_Click(object sender, RoutedEventArgs e)
        {
            pagePasswordOverview pagePasswordOverview = new pagePasswordOverview();
            this.NavigationService.Navigate(pagePasswordOverview);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pageFrontPage());
        }
    }
}
