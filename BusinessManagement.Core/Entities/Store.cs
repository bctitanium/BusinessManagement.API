using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Core.Entities
{
    public class Store : BaseEntity
    {
        public string   StoreName       { get; set; } = string.Empty;
        public string   StoreAddress    { get; set; } = string.Empty;
        public string   StorePhone      { get; set; } = string.Empty;
    }
}
