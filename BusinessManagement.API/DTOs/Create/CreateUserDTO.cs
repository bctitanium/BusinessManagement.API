using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.API.DTOs.Create
{
    public class CreateUserDTO
    {
        [Required]
        public string   Username    { get; set; } = string.Empty;

        [Required]
        public string   Password    { get; set; } = string.Empty;

        [Required]
        public string   FullName    { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string   Email       { get; set; } = string.Empty;
        [Required]
        public string   Address     { get; set; } = string.Empty;

        public IList<string> Roles { get; set; } = Array.Empty<string>();
    }
}
