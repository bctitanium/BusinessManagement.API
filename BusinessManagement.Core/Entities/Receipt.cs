namespace BusinessManagement.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public string       CustomerId     { get; set; } = string.Empty;
        public string       StaffId        { get; set; } = string.Empty;
        public DateTime?    ReceiptDate    { get; set; }
        public double       ReceiptAmount  { get; set; }

        public virtual Customer? Customers { get; set; }
        public virtual Staff?    Staffs    { get; set; }

        public virtual ICollection<DetailedReceipt> DetailedReceipts { get; set; } = new HashSet<DetailedReceipt>();
    }
}
