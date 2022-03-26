using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Core.Entities
{
    public class Product : BaseEntity
    {
        public string     StoreId            { get; set; } = string.Empty;
        public string     ProductName        { get; set; } = string.Empty;
        public string?    ProductDescription { get; set; }
        public double?    BuyPrice           { get; set; }
        public double     SellPrice          { get; set; }
        public int        Quantity           { get; set; }
        public SizeChart  Size               { get; set; }
        public string?    ImageFile          { get; set; }

        public virtual Store? Stores { get; set; }

        public enum SizeChart
        {
            XS, S, M, L, XL, XXL
        }
    }
}
