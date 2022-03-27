using BusinessManagement.Core.Entities;
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
        public virtual DbSet<ProductBrand>     ProductBrands     { get; set; } = null!;
        public virtual DbSet<ProductCategory>  ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductMaterial>  ProductMaterials  { get; set; } = null!;
        public virtual DbSet<ProductSupplier>  ProductSuppliers  { get; set; } = null!;
        public virtual DbSet<Receipt>          Receipts          { get; set; } = null!;
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

            builder.Entity<ProductBrand>(entity =>
            {
                entity.ToTable("ProductBrand");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ProductBrandName).IsRequired().HasColumnType("nvarchar");

                entity.Property(e => e.CountryCode).IsRequired().HasColumnType("varchar");
            });

            builder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.Category).IsRequired().HasColumnType("nvarchar");

                entity.Property(e => e.SizeCode).IsRequired().HasColumnType("varchar");

                entity.Property(e => e.SizeValue).IsRequired().HasColumnType("int");
            });

            builder.Entity<ProductMaterial>(entity =>
            {
                entity.ToTable("ProductMaterial");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ProductNaterialName).IsRequired().HasColumnType("nvarchar");
            });

            builder.Entity<ProductSupplier>(entity =>
            {
                entity.ToTable("ProductSupplier");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ProductSupplierName).IsRequired().HasColumnType("nvarchar");

                entity.HasOne(ps => ps.Stores)
                      .WithMany(s => s.ProductSuppliers)
                      .HasForeignKey(ps => ps.StoresId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.ReceiptDate).IsRequired().HasColumnType("datetime");

                entity.Property(e => e.ReceiptAmount).IsRequired().HasColumnType("float");
            });

            builder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.StoreName).IsRequired().HasColumnType("nvarchar");

                entity.Property(e => e.StoreAddress).IsRequired().HasColumnType("nvarchar");

                entity.Property(e => e.StorePhone).IsRequired().HasColumnType("nvarchar");
            });
        }
    }
}
