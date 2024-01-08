using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Entities;

namespace WareHousingApi.DataModel
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers,ApplicationRoles,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Country> Countries_tbl { get; set; }
        public DbSet<Supplier> Suppliers_tbl { get; set; }
        public DbSet<Products> Products_tbl { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUsers>(entity =>
            {
                entity.ToTable(name: "users_tbl");
                entity.Property(e => e.Id).HasColumnName("UserId");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            builder.Entity<ApplicationRoles>(entity =>
            {
                entity.ToTable(name: "Roles_tbl");
                
            });
        }


    }
}
