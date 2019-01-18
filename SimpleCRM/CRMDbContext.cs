using Microsoft.EntityFrameworkCore;
using SimpleCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCRM
{
    public class CRMDbContext: DbContext
    {
        public CRMDbContext(DbContextOptions options): base(options)
        {
            Database.Migrate();
        }

        public DbSet<CostumerModel> Costumers { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostumerModel>().Property(t => t.Email)
                    .HasMaxLength(70)
                    .IsRequired();

            modelBuilder.Entity<CostumerModel>().Property(t => t.Nome)
                    .HasMaxLength(120)
                    .IsRequired();
        }
    }
}
