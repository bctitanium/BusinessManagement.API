namespace BusinessManagement.Core.Entities
{
    public class SupplyProduct : BaseEntity
    {
        public int      SupplierId  { get; set; }
        public int      ProductId   { get; set; }
        public int      Quantity    { get; set; }
        public DateTime OrderedAt   { get; set; }
        public DateTime ArrivesAt   { get; set; }
        public bool     IsArrived   { get; set; } = false;

        public virtual Supplier?    Suppliers   { get; set; }
        public virtual Product?     Products    { get; set; }
    }
}
