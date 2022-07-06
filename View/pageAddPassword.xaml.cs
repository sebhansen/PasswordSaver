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
using PasswordSaver.ViewModel;

namespace PasswordSaver.View
{
    public partial class pageAddPassword : Page
    {
        public pageAddPassword()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new pageFrontPage());
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            AddPasswordViewModel addPasswordViewModel = new AddPasswordViewModel();
            addPasswordViewModel.CreatePassword(txtbUsername.Text, txtbPassword.Text, txtbEmail.Text, txtbWebsite.Text);
            MessageBox.Show("Bruger oprettet!");
            this.NavigationService.Navigate(new pageFrontPage());
        }
    }
}
