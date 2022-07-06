using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordSaver.Model;

namespace PasswordSaver.ViewModel
{
    internal class AddPasswordViewModel
    {
        public void CreatePassword(string username, string password, string email, string website)
        {
            AccountRepo repo = new AccountRepo();
            Account account = new Account(username, password, email, website);
            repo.SaveAccount(account);
        }
    }
}
