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
        public DbSet<DestinationModel> Destination { get; set; } // DbSet for your Destination model

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
