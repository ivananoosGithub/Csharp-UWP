using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TraVeL.Core.Helpers;

namespace TraVeL.Core.Models
{
    public class DatabaseHelper
    {
        public static bool IsDatabaseConnected()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(Constants.connectionString) // Replace with your SQL Server connection string
                .Options;

            using (var context = new AppDbContext(options))
            {
                try
                {
                    context.Database.OpenConnection();
                    return true; // Connection successful
                }
                catch (Exception)
                {
                    return false; // Connection failed
                }
            }
        }
    }
}
