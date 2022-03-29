namespace BusinessManagement.API.DTOs
{
    public class ProductSupplierDTO : BaseDTO
    {
        public int    StoreId             { get; set; }
        public string ProductSupplierName { get; set; } = string.Empty;
    }
}
