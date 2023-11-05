using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TraVeL.Core.Helpers;
using TraVeL.Core.Models;

namespace TraVeL.Core.Services
{
    public class MainDataService
    {
        public string GetUser()
        {
            return "SELECT password FROM Account WHERE username = @Username";
        }

        public bool IsUserCredentialsCorrect(AccountDetails user)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                using (SqlCommand command = new SqlCommand(GetUser(), connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    connection.Open();
                    string passwordFromDatabase = (string)command.ExecuteScalar();
                    connection.Close();

                    if (passwordFromDatabase != null && passwordFromDatabase == user.Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
