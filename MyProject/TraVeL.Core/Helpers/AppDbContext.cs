using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TraVeL.Core.Models;

namespace TraVeL.Core.Helpers
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = Ivan-Kim\\SQLEXPRESS; " +
                "Database = traveldb; User Id = ivankim; " +
                "Password = ivan;");
        }
    }
}
