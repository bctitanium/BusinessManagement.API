namespace BusinessManagement.Core.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; } = string.Empty;
        public string CountryCode      { get; set; } = string.Empty;
    }
}
