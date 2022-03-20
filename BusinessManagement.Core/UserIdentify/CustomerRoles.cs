﻿using BusinessManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.UserIdentify
{
    public class CustomerRoles
    {
        public virtual Customer? Staff { get; set; }
        public virtual Role? Role { get; set; }
    }
}
