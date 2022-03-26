namespace BusinessManagement.Core.Entities
{
    public class ProductSupplier : BaseEntity
    {
        public string ProductSupplierName { get; set; } = string.Empty;

        public Store? Store { get; set; }
    }
}
