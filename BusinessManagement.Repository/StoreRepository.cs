using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Store?> FindByStore(string store, CancellationToken cancellationToken = default)
            => await FindAll()
                .Where(b => b.StoreName == store)
                .Include(s => s.Products)
                .FirstOrDefaultAsync(cancellationToken);
    }
}
