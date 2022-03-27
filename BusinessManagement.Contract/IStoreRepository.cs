using BusinessManagement.Core.Entities;

namespace BusinessManagement.Contract
{
    public interface IStoreRepository : IBaseRepository<Store>
    {
        Task<Store?> FindByStore(string store, CancellationToken cancellationToken = default);
    }
}
