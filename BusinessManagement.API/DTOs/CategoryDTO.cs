﻿namespace BusinessManagement.API.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? CategoryDescription { get; set; }
        public string? Gender { get; set; }
        public string SizeCode { get; set; } = string.Empty;
        public int? SizeValue { get; set; }
        public string Season { get; set; } = string.Empty;
        public string Weather { get; set; } = string.Empty;
        public string MainMaterial { get; set; } = string.Empty;
    }
}
