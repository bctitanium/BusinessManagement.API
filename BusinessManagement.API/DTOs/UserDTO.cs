using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.API.DTOs
{
    public class UserDTO
    {
        [FromRoute]
        public string    Guid         { get; set; } = string.Empty;
        public string?   Username     { get; set; }

        [Required]
        public string    FullName     { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string    Email        { get; set; } = string.Empty;

        public string    Gender       { get; set; } = string.Empty;
        public string    Address      { get; set; } = string.Empty;
        public string?   ProfileImage { get; set; }
        public DateTime? DateOfBirth  { get; set; }
        public DateTime  CreatedDate  { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate  { get; set; }
        public bool?     IsActive     { get; set; }
        public bool      IsDeleted    { get; set; } = false;

        public bool EmailConfirmed { get; set; } = true;

        public ICollection<string> Roles { get; set; } = Array.Empty<string>();
    }
}
