using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using VirtualMind.Core.Entities;

namespace VirtualMind.Core.Context
{
    public class VirtualMindAPPDbContext : DbContext
    {


        public VirtualMindAPPDbContext() : base()
        {

        }

        public VirtualMindAPPDbContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<CurrencyEntity> Currency { get; set; }
        public DbSet<CurrencyBuyEntity> CurrencyBuy { get; set; }
    }
}
