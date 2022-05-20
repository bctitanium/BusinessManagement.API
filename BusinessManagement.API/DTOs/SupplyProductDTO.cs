namespace BusinessManagement.API.DTOs
{
    public class SupplyProductDTO : BaseDTO
    {
        public int      SupplierId  { get; set; }
        public int      ProductId   { get; set; }
        public int      Quantity    { get; set; }
        public DateTime OrderedAt   { get; set; }
        public DateTime ArrivesAt   { get; set; }
        public bool     IsArrived   { get; set; } = false;
    }
}
