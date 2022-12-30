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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                           .HasOne<Category>(p => p.Category)
                           .WithMany(m => m.Product)
                           .HasForeignKey(v => v.IdCategory);
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
