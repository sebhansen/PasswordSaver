using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordSaver.Model;

namespace PasswordSaver.ViewModel
{
    public class PasswordOverviewViewModel
    {
        AccountRepo accountRepo = new AccountRepo();
        
        // This allows us to acces this specific Report from other classes
        public static Account ActiveAccount;

        //Making an observable collection of incidents as a property.
        //Observable collection notifies the View when something is added or removed from the list.
        private ObservableCollection<Model.Account> obsAccounts;
        public ObservableCollection <Model.Account> ObsAccounts
        {
            get { return obsAccounts; }
            set { obsAccounts = value; OnPropertyChanged("ObsAccounts"); }
        }

        //Making an account property that holds the value of the selected account in the View
        private Model.Account selectedAccount;

        public Model.Account SelectedAccount
        {
            get { return selectedAccount; }
            set { selectedAccount = value; OnPropertyChanged("SelectedAccount"); }
        }
        public PasswordOverviewViewModel()
        {
            //This all happens when we instantiate the class in the code behind. We fill the observable collection of 
            //incidents with all the Accounts in the database, and make sure the View can see them.
            List<Model.Account> accounts = accountRepo.GetAccounts();
            obsAccounts = new();
            foreach (Model.Account account in accounts)
            {
                obsAccounts.Add(account);
            }
        }
        public void UpdateAccount(string username, string password, string email, string website)
        {
            Account account = new Account(username, password, email, website);
            accountRepo.UpdateAccount(account);
        }

        //This is the event that notifies the properties
        public event PropertyChangedEventHandler PropertyChanged;

        //The event handler
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
