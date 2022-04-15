using BusinessManagement.Core.Entities;

namespace BusinessManagement.API.DTOs
{
    public class ProductDTO
    {
        public int       StoreId            { get; set; }
        public string    ProductName        { get; set; } = string.Empty;
        public string?   ProductDescription { get; set; }
        public double?   BuyPrice           { get; set; }
        public double    SellPrice          { get; set; }
        public int       Quantity           { get; set; }
        public SizeChart Size               { get; set; }
        public string?   ImageFile          { get; set; }

        public enum SizeChart
        {
            XS, S, M, L, XL, XXL
        }
    }
}
