using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.Entities
{
    public class Product : BaseEntity
    {
        public string       ProductName         { get; set; } = string.Empty;
        public string ?     ProductDescription  { get; set; }
        public double ?     BuyPrice            { get; set; }
        public double ?     SellPrice           { get; set; }
        public int          Quantity            { get; set; }
        public string ?     ImageFile           { get; set; }
        public string ?     Gender              { get; set; }

    }
}
