namespace BusinessManagement.Core.Entities
{
    public class Brand : BaseEntity
    {
        public int    ProductId     { get; set; }
        public string BrandName     { get; set; } = string.Empty;
        public string CountryCode   { get; set; } = string.Empty;

        public virtual Product? Products { get; set; }
    }
}
