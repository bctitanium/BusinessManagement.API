using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationDbContext context) : base(context) { }
    }
}
