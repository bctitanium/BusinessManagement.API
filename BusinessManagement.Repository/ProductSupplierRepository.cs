using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class ProductSupplierRepository : BaseRepository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(ApplicationDbContext context) : base(context) { }
    }
}
