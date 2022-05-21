using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }
    }
}
