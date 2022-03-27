using BusinessManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.API.DTOs
{
    //[ModelBinder(typeof(MultipleSourcesModelBinder<StoreDTO>))]
    public class StoreDTO : BaseDTO
    {
        public string StoreName { get; set; } = string.Empty;
        public string StoreAddress { get; set; } = string.Empty;
        public string StorePhone { get; set; } = string.Empty;

        public virtual ICollection<string> Products { get; set; } = Array.Empty<string>();
        public virtual ICollection<string> ProductSuppliers { get; set; } = Array.Empty<string>();
    }
}
