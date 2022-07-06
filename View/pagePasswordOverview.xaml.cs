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
    /// <summary>
    /// Interaction logic for pagePasswordOverview.xaml
    /// </summary>
    public partial class pagePasswordOverview : Page
    {
        public pagePasswordOverview()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pageFrontPage pageFrontPage = new pageFrontPage();
            this.NavigationService.Navigate(pageFrontPage);
        }
    }
}
