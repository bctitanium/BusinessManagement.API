namespace BusinessManagement.API.DTOs
{
    public class BrandDTO : BaseDTO
    {
        public int      ProductId   { get; set; }
        public string   BrandName   { get; set; } = string.Empty;
        public string   CountryCode { get; set; } = string.Empty;
    }
}
