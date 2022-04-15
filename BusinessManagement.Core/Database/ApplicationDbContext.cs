﻿using BusinessManagement.Core.Entities;
using BusinessManagement.Core.UserIdentify;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Core.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<DetailedReceipts> DetailedReceipts  { get; set; } = null!;
        public virtual DbSet<Product>          Products          { get; set; } = null!;
        public virtual DbSet<Brand>            Brands            { get; set; } = null!;
        public virtual DbSet<Category>         Categories        { get; set; } = null!;
        public virtual DbSet<Material>         Materials         { get; set; } = null!;
        public virtual DbSet<Supplier>         Suppliers         { get; set; } = null!;
        public virtual DbSet<Receipt>          Receipts          { get; set; } = null!;
        public virtual DbSet<Staff>            Staffs            { get; set; } = null!;
        public virtual DbSet<Store>            Stores            { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Guid)
                      .IsUnique();

                entity.Property(e => e.Guid)
                      .HasDefaultValue("NEWID()");

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime");
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.HasOne(ur => ur.Role)
                      .WithMany(r => r!.UserRoles)
                      .HasForeignKey(ur => ur.RoleId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u!.UserRoles)
                      .HasForeignKey(ur => ur.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
            });

            builder.Entity<DetailedReceipts>(entity =>
            {
                entity.ToTable("DetailedReceipt");

                entity.HasIndex(e => e.Id).IsUnique();
            });

            builder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ProductName)
                      .IsRequired()
                      .HasMaxLength(150)
                      .HasColumnType("nvarchar");
                
                entity.Property(e => e.SellPrice)
                      .IsRequired()
                      .HasColumnType("float");
                
                entity.Property(e => e.BuyPrice)
                      .IsRequired()
                      .HasColumnType("float");
                
                entity.Property(e => e.Quantity)
                      .IsRequired()
                      .HasColumnType("int");

                entity.Property(e => e.Size)
                      .IsRequired()
                      .HasColumnType("int");

                entity.HasOne(p => p.Stores)
                      .WithMany(s => s.Products)
                      .HasForeignKey(s => s.StoreId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.BrandName).IsRequired().HasColumnType("nvarchar").HasMaxLength(30);

                entity.Property(e => e.CountryCode).IsRequired().HasColumnType("varchar").HasMaxLength(5);
            });

            builder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.CategoryName).IsRequired().HasColumnType("nvarchar").HasMaxLength(30);

                entity.Property(e => e.SizeCode).IsRequired().HasColumnType("varchar").HasMaxLength(5);

                entity.Property(e => e.SizeValue).IsRequired();

                entity.Property(e => e.Season).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);

                entity.Property(e => e.Weather).IsRequired().HasColumnType("nvarchar").HasMaxLength(20);

                entity.HasOne(pc => pc.Products)
                      .WithOne(p => p.Categories)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.MaterialName).IsRequired().HasColumnType("nvarchar").HasMaxLength(30);
            });

            builder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.SupplierName).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            });

            builder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ReceiptDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ReceiptAmount).IsRequired().HasColumnType("float");
            });

            builder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasOne(st => st.Stores)
                      .WithMany(s => s.Staffs)
                      .HasForeignKey(st => st.StoreId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.StoreName).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);

                entity.Property(e => e.StoreAddress).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);

                entity.Property(e => e.StorePhone).HasColumnType("nvarchar").HasMaxLength(20);
            });
        }
    }
}
