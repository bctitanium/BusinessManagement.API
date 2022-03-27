namespace BusinessManagement.Core.Entities
{
    public class ProductSupplier : BaseEntity
    {
        public string?  StoresId                { get; set; }
        public string   ProductSupplierName     { get; set; } = string.Empty;

        public virtual Store? Stores { get; set; }
    }
}
