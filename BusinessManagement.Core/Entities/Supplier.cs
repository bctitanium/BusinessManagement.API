namespace BusinessManagement.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public int      StoreId         { get; set; }
        public string   SupplierName    { get; set; } = string.Empty;

        public virtual ICollection<SupplyProduct> SupplyProducts { get; set; } = new HashSet<SupplyProduct>();
    }
}
