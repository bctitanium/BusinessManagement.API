using BusinessManagement.Core.UserIdentify;

namespace BusinessManagement.Core.Entities
{
    public class Customer : User
    {
        public bool IsMembership { get; set; } = false;
    }
}
