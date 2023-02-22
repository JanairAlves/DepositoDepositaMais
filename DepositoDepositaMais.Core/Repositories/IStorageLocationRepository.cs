using DepositoDepositaMais.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Core.Repositories
{
    public interface IStorageLocationRepository
    {
        Task<List<StorageLocation>> GetAllStorageLocationsAsync();
        Task<StorageLocation> GetStorageLocationByIdAsync(int id);
        Task CreateStorageLocation(StorageLocation storageLocation);
        Task SaveChangesAsync();
    }
}
