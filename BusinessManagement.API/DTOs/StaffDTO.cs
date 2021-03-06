using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.API.DTOs
{
    public class StaffDTO
    {
        [FromRoute]
        public string Guid { get; set; } = string.Empty;

        public string? Username { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public int StoreId { get; set; }
        public bool IsHead { get; set; } = false;

        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<string> Roles { get; set; } = Array.Empty<string>();
        public virtual ICollection<int> Receipts { get; set; } = Array.Empty<int>();
    }
}
