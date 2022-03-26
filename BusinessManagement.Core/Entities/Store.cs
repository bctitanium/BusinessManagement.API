namespace BusinessManagement.Core.Entities
{
    public class Store : BaseEntity
    {
        public string StoreName    { get; set; } = string.Empty;
        public string StoreAddress { get; set; } = string.Empty;
        public string StorePhone   { get; set; } = string.Empty;

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); //đầu 1
        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new HashSet<ProductSupplier>();
    }
}
