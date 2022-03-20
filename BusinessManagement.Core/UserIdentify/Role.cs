using BusinessManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.UserIdentify
{
    public class Role : BaseEntity
    {
        public virtual ICollection<StaffRole> StaffRoles { get; } = new HashSet<StaffRole>();
        public virtual ICollection<CustomerRoles> CustomerRoles { get; } = new HashSet<CustomerRoles>();
    }
}
