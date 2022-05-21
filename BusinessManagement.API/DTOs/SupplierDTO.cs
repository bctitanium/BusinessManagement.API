namespace BusinessManagement.API.DTOs
{
    public class SupplierDTO : BaseDTO
    {
        public int    StoreId           { get; set; }
        public string SupplierName      { get; set; } = string.Empty;

        public virtual ICollection<int> SupplyProducts { get; set; } = Array.Empty<int>();
    }
}
