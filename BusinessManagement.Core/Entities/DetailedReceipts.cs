namespace BusinessManagement.Core.Entities
{
    public class DetailedReceipts : BaseEntity
    {
        public int    ProductId     { get; set; }
        public int    ReceiptId     { get; set; }
        public int    Quantity      { get; set; }

        public virtual Product? Products { get; set; }
        public virtual Receipt? Receipts { get; set; }
    }
}
