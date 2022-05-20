namespace BusinessManagement.API.DTOs
{
    public class DetailedReceiptDTO : BaseDTO
    {
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int Quantity { get; set; }
    }
}
