using System;
using System.Collections.Generic;
using System.Text;
using TraVeL.Core.Helpers;
using Microsoft.EntityFrameworkCore;

namespace TraVeL.Core.Models
{
    public class DatabaseHelper
    {
        public static bool IsDatabaseConnected()
        {
            using (var context = new AppDbContext())
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
