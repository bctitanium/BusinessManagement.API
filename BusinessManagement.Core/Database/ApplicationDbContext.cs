using BusinessManagement.Core.Entities;
using BusinessManagement.Core.UserIdentify;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Core.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DetailedReceipts> DetailedReceipts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBrand> ProductBrands { get; set; } = null!;
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; } = null!;
        public virtual DbSet<ProductSupplier> ProductSuppliers { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<StaffRole> StaffRoles { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                entity.Property(e => e.Id).HasDefaultValue("NEWID()");

                entity.HasIndex(e => e.Id).IsUnique();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });
        }
    }
}
