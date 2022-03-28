namespace BusinessManagement.Core.Entities
{
    public class ProductSupplier : BaseEntity
    {
        public int      StoresId                { get; set; }
        public string   ProductSupplierName     { get; set; } = string.Empty;

        public virtual Store? Stores { get; set; }
    }
}
