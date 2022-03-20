using BusinessManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.UserIdentify
{
    public class Customer : BaseEntity
    {
        public string   CustomerName { get; set; } = string.Empty;
        public string   CustomerPhone { get; set; } = string.Empty;
        public string?  CustomerUsername { get; set; }
        public string?  CustomerPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool?    IsActive { get; set; }
        public bool     IsDeleted { get; set; } = false;
    }
}
