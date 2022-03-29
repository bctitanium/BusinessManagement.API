using Microsoft.AspNetCore.Identity;

namespace BusinessManagement.Core.UserIdentify
{
    public class User : IdentityUser
    {
        public string     Guid         { get; set; } = null!;
        public string     FullName     { get; set; } = string.Empty;
        public string     Gender       { get; set; } = string.Empty;
        public string   ? ProfileImage { get; set; }
        public DateTime ? DateOfBirth  { get; set; }
        public DateTime ? CreatedDate  { get; set; }
        public DateTime ? UpdatedDate  { get; set; }
        public bool     ? IsActive { get; set; }
        public bool       IsDeleted { get; set; } = false;

        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}
