using BusinessManagement.Core.Entities;

namespace BusinessManagement.API.DTOs
{
    public class SupplierDTO : BaseDTO
    {
        public int    StoreId           { get; set; }
        public string SupplierName      { get; set; } = string.Empty;
    }
}
