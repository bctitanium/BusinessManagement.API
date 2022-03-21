namespace BusinessManagement.Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string  Category            { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; }
        public string? Gender              { get; set; }
        public string  SizeCode            { get; set; } = string.Empty;
        public string  SizeValue           { get; set; } = string.Empty;
    }
}
