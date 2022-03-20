using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.Entities
{
    public class Receipt : BaseEntity
    {
        public DateTime? ReceiptDate { get; set; }
        public double   ReceiptAmount { get; set; }
    }
}
