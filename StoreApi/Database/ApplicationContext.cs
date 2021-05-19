using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<StoreModel> Store { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<StoreBalanceModel> StoreBalance { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }
    }
}
