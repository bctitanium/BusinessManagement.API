namespace BusinessManagement.Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string ProductBrandName { get; set; } = string.Empty;
        public string CountryCode      { get; set; } = string.Empty;
    }
}
