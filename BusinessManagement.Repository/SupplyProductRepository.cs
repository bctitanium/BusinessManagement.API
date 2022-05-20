using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class SupplyProductRepository : BaseRepository<SupplyProduct>, ISupplyProductRepository
    {
        public SupplyProductRepository(ApplicationDbContext context) : base(context) { }
    }
}
