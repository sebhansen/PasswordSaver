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
    public partial class pagePasswordOverview : Page
    {
        PasswordOverviewViewModel passwordOverviewVM = new PasswordOverviewViewModel();
        public pagePasswordOverview()
        {
            InitializeComponent();
            DataContext = passwordOverviewVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pageFrontPage pageFrontPage = new pageFrontPage();
            this.NavigationService.Navigate(pageFrontPage);
        }
        private void setText()
        {
            
            txtbUsername.Text = passwordOverviewVM.SelectedAccount.Username;
            txtbPassword.Text = passwordOverviewVM.SelectedAccount.Password;
            txtbEmail.Text = passwordOverviewVM.SelectedAccount.Email;
            txtbWebsite.Text = passwordOverviewVM.SelectedAccount.Website;

            txtbUsername.IsEnabled = false;
            txtbPassword.IsEnabled = false;
            txtbEmail.IsEnabled = false;
            txtbWebsite.IsEnabled = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PasswordOverviewViewModel.ActiveAccount = passwordOverviewVM.SelectedAccount;
            setText();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtbUsername.IsEnabled = true;
            txtbPassword.IsEnabled = true;
            txtbEmail.IsEnabled = true;
            txtbWebsite.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil gemme?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                passwordOverviewVM.UpdateAccount(txtbUsername.Text, txtbPassword.Text, txtbEmail.Text, txtbWebsite.Text);
            }
            this.NavigationService.Refresh();
        }
    }
}
