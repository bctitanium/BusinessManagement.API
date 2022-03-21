namespace BusinessManagement.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public DateTime ? ReceiptDate   { get; set; }
        public double     ReceiptAmount { get; set; }
    }
}
