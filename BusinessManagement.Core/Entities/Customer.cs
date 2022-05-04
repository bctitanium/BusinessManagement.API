using BusinessManagement.Core.UserIdentify;

namespace BusinessManagement.Core.Entities
{
    public class Customer : User
    {
        public bool IsMembership { get; set; } = false;

        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
