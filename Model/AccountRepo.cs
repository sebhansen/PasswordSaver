using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordSaver.Model
{
    public class AccountRepo
    {
        private readonly string connectionString = File.ReadLines("DatabaseHelper.txt").Skip(4).Take(1).First(); //Real ConnectionString MUST be on line 5, or this will not work.
        public void SaveAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, Password, Email, Website) VALUES (@Username, @Password, @Email, @Website)", connection))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = account.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = account.Password;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = account.Email;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = account.Website;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
