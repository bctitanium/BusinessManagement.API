namespace BusinessManagement.API.DTOs
{
    public class ProductDTO : BaseDTO
    {
        public int       StoreId            { get; set; }
        public string    ProductName        { get; set; } = string.Empty;
        public string?   ProductDescription { get; set; }
        public double?   BuyPrice           { get; set; }
        public double    SellPrice          { get; set; }
        public int       Quantity           { get; set; }
        public string?   ImageFile          { get; set; }

        public virtual ICollection<int> SupplyProducts   { get; set; } = Array.Empty<int>();
        public virtual ICollection<int> DetailedReceipts { get; set; } = Array.Empty<int>();
    }
}
