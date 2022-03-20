using BusinessManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.UserIdentify
{
    public class Staff : BaseEntity
    {
        public string   StaffName       { get; set; } = string.Empty;
        public string   StaffPosition   { get; set; } = string.Empty;
    }
}
