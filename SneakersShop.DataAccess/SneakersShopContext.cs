using Microsoft.EntityFrameworkCore;
using SneakersShop.DataAccess.Configurations;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.DataAccess
{
    public class SneakersShopContext : DbContext
    {
        public SneakersShopContext() { }

        public SneakersShopContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SizeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.Entity<ProductColor>().HasKey(x => new { x.ColorId, x.ProductId });
            modelBuilder.Entity<StoreProductSize>().HasKey(x => new { x.ProductSizeId, x.StoreId });
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId });
            modelBuilder.Entity<Role>().Property(x => x.IsDefault).HasDefaultValue(false);
            modelBuilder.Entity<Size>().Property(x => x.Number).HasColumnType("decimal(3,1)");
            modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasColumnType("decimal(7,2)");
            modelBuilder.Entity<Order>().Property(x => x.Total).HasColumnType("decimal(8,2)");
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(7,2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RFBQSM7\SQLEXPRESS;Initial Catalog=BazaZaAsp;Integrated Security=True");
        }

        public DbSet<Brand> Brands { get; set; } 
        public DbSet<Color> Colors { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeCategory> SizeCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreProductSize> StoreProductSizes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
