using BusinessManagement.Core.UserIdentify;

namespace BusinessManagement.Core.Entities
{
    public class Staff : User
    {
        public int  StoreId { get; set; }
        public bool IsHead  { get; set; } = false;

        public virtual Store? Stores { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
