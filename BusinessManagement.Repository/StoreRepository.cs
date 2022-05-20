using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;
using BusinessManagement.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public override async Task<Store?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
            => await FindAll(s => s.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public override IQueryable<Store> FindAll(Expression<Func<Store, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!)
                .Include(p => p.Products);
    }
}
