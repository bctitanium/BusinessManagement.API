using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
