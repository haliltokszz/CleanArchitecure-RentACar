using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p=>p.Models);
            });
            
            modelBuilder.Entity<Model>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.BrandId).HasColumnName("BrandId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                a.HasOne(p => p.Brand);
            });

            Brand[] brandEntitySeeds =
            {
                new(Guid.Parse("22c7f32e-cae1-4da1-93cb-3a86aa2b230a"), "BMW"), 
                new(Guid.Parse("52af8057-a7a7-45bf-b756-d65285630fd3"), "Mercedes")
            };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);
            
            Model[] modelEntitySeeds = { 
                new(Guid.Parse("ce6b11b1-c2b5-4168-9f73-62c56bb30206"), Guid.Parse("22c7f32e-cae1-4da1-93cb-3a86aa2b230a"), "Series 4", 1500,""),
                new(Guid.Parse("70dafe03-9a0e-4516-9e58-15c6660bf271"),  Guid.Parse("52af8057-a7a7-45bf-b756-d65285630fd3"), "A180", 1000, "") };
            modelBuilder.Entity<Model>().HasData(modelEntitySeeds);
            
        }
    }
}
