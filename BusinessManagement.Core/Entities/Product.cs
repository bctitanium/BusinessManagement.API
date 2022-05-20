namespace BusinessManagement.Core.Entities
{
    public class Product : BaseEntity
    {
        public int        StoreId            { get; set; }
        public string     ProductName        { get; set; } = string.Empty;
        public string?    ProductDescription { get; set; }
        public double?    BuyPrice           { get; set; }
        public double     SellPrice          { get; set; }
        public int        Quantity           { get; set; }
        public string?    ImageFile          { get; set; }

        public virtual Store?    Stores      { get; set; }
        public virtual Category? Categories  { get; set; }
        public virtual Brand?    Brands      { get; set; }

        public virtual ICollection<SupplyProduct>    SupplyProducts   { get; set; } = new HashSet<SupplyProduct>();
        public virtual ICollection<DetailedReceipt>  DetailedReceipts { get; set; } = new HashSet<DetailedReceipt>();
    }
}
