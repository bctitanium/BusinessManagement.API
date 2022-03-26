﻿namespace BusinessManagement.Core.Entities
{
    public class Store : BaseEntity
    {
        public string StoreName    { get; set; } = string.Empty;
        public string StoreAddress { get; set; } = string.Empty;
        public string StorePhone   { get; set; } = string.Empty;

        public virtual ICollection<ProductSupplier> ProductSuppliers { get; set; } = new HashSet<ProductSupplier>(); //đầu 1
    }
}
