using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.Entities
{
    public class DetailedReceipts : BaseEntity
    {
        public string   Product { get; set; } = string.Empty;
        public int      Quantity { get; set; }
        public double   Price { get; set; }
    }
}
