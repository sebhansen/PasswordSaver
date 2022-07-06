using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSaver.Model
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    
        public Account(string username, string password, string email, string website)
        {
            Username = username;
            Password = password;
            Email = email;
            Website = website;
        }
        public Account() 
        {
        }
    }
}
