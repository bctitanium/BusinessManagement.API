namespace BusinessManagement.Core.Entities
{
    public class Store : BaseEntity
    {
        public string StoreName    { get; set; } = string.Empty;
        public string StoreAddress { get; set; } = string.Empty;
        public string StorePhone   { get; set; } = string.Empty;
        public string Logo         { get; set; } = string.Empty;

        public virtual ICollection<Product>   Products   { get; set; } = new HashSet<Product>();
        public virtual ICollection<Staff>     Staffs     { get; set; } = new HashSet<Staff>();
    }
}
