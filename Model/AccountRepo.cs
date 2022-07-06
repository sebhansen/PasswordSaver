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
        private List<Account> accounts = new List<Account>();
        public void SaveAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Account (Username, Password, Email, Website) VALUES (@Username, @Password, @Email, @Website)", connection))
                {
                    // Create and set the parameters values 
                    // We use "Parameters.Add" instead of "Parameters.AddWithValue" because this way, the method will check if the datatype maches 
                    // before the program runs, so it won't crash. "Parameters.AddWithValue" will try to guess the datatype, and isn't always correct.
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = account.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = account.Password;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = account.Email;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = account.Website;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateAccount(Account account)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Account SET Username = @Username, Password = @Password, Email = @Email, Website = @Website", connection))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = account.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = account.Password;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = account.Email;
                    cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = account.Website;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Account> GetAccounts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("EXEC GetAccounts", connection);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //Making a new object of WorkEnvironmentIncident and adding all the data that the sql statement returned after.
                        Account account = new Account();

                        account.Username = dr["Username"].ToString();
                        account.Password = dr["Password"].ToString();
                        account.Email = dr["Email"].ToString();
                        account.Website = dr["Website"].ToString();

                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }
    }
}
