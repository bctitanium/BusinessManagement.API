using Microsoft.AspNetCore.Identity;

namespace BusinessManagement.Core.UserIdentify
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}
