using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string ?     Type    { get; set; }
        public int          Size    { get; set; }
    }
}
