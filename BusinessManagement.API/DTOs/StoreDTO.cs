﻿namespace BusinessManagement.API.DTOs
{
    //[ModelBinder(typeof(MultipleSourcesModelBinder<StoreDTO>))]
    public class StoreDTO : BaseDTO
    {
        public string   StoreName       { get; set; } = string.Empty;
        public string   StoreAddress    { get; set; } = string.Empty;
        public string   StorePhone      { get; set; } = string.Empty;
        public string   Logo            { get; set; } = string.Empty;

        public virtual ICollection<int>     Products    { get; set; } = Array.Empty<int>();
        public virtual ICollection<int>     Staffs      { get; set; } = Array.Empty<int>();
    }
}
