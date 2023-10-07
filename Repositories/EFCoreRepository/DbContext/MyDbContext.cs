using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Showroom.Models;
using Showroom.Repositories.EFCoreRepository.Configurations;

namespace Showroom.Repositories.EFCoreRepository.DbContext;
public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<UserLoyalCards> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString: $"Server=localhost;Database=EFCoreDb;Integrated Security=True;TrustServerCertificate=True;");
    }        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LoyalCardsConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

