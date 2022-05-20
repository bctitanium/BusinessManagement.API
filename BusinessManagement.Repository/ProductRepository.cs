using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;
using BusinessManagement.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessManagement.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<Product?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
            => await FindAll(p => p.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

        public override IQueryable<Product> FindAll(Expression<Func<Product, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!)
                .Include(s => s.Stores);
    }
}
