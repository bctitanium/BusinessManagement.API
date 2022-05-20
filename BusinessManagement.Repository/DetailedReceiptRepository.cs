using BusinessManagement.Contract;
using BusinessManagement.Core.Database;
using BusinessManagement.Core.Entities;

namespace BusinessManagement.Repository
{
    public class DetailedReceiptRepository : BaseRepository<DetailedReceipt>, IDetailedReceiptRepository
    {
        public DetailedReceiptRepository(ApplicationDbContext context) : base(context) { }
    }
}
