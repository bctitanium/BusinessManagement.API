namespace BusinessManagement.API.DTOs
{
    public class ReceiptDTO : BaseDTO
    {
        public string CustomerId { get; set; } = string.Empty;
        public string StaffId { get; set; } = string.Empty;
        public DateTime? ReceiptDate { get; set; }
        public double ReceiptAmount { get; set; }
    }
}
