using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Core.Entities
{
    public class Product : BaseEntity
    {
        public string    StoreId            { get; set; } = string.Empty;
        public string    ProductName        { get; set; } = string.Empty;
        public string?   ProductDescription { get; set; }
        public double?   BuyPrice           { get; set; }
        public double    SellPrice          { get; set; }
        public int       Quantity           { get; set; }
        public int       Size               { get; set; }
        public string?   ImageFile          { get; set; }
        public string?   Gender             { get; set; }

        public Store?   Store { get; set; }
    }
}
