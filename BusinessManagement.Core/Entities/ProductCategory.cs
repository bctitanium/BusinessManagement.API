namespace BusinessManagement.Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string  Category            { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; }
        public string? Gender              { get; set; }
        public string  SizeCode            { get; set; } = string.Empty;
        public int?    SizeValue           { get; set; }
        public string  Season              { get; set; } = string.Empty;
        public string  Weather             { get; set; } = string.Empty;
    }
}
