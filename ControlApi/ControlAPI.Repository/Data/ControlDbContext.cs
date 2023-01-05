using ControlAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAPI.Repository.Data
{
    public partial class ControlDbContext : DbContext
    {
        public ControlDbContext() { }
        public ControlDbContext(DbContextOptions<ControlDbContext> options)
           : base(options)
        { }



        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                           .HasOne<Category>(p => p.Category)
                           .WithMany(m => m.Product)
                           .HasForeignKey(v => v.IdCategory);

            modelBuilder.Entity<Order>()
                          .HasOne<Bill>(p => p.Bill)
                          .WithMany(m => m.Order)
                          .HasForeignKey(v => v.IdBill);

            modelBuilder.Entity<Order>()
                           .HasOne<Product>(p => p.Product)
                           .WithMany(m => m.Order)
                           .HasForeignKey(v => v.IdProduct);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Database=ControlDB; Integrated Security=True;");
            }
        }
    }
}
