using DepositoDepositaMais.Core.Entities;
using DepositoDepositaMais.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepositoDepositaMais.Infrastructure.Persistence.Repositories
{
    public class StorageLocationRepository : IStorageLocationRepository
    {
        private readonly DepositoDepositaMaisDbContext _dbContext;
        public StorageLocationRepository(DepositoDepositaMaisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StorageLocation>> GetAllStorageLocationsAsync()
        {
            return await _dbContext.StorageLocations.ToListAsync();
        }

        public async Task<StorageLocation> GetStorageLocationByIdAsync(int id)
        {
            return await _dbContext.StorageLocations
                .Include(sl => sl.Deposit)
                .SingleOrDefaultAsync(ol => ol.Id == id);
        }

        public async Task CreateStorageLocation(StorageLocation storageLocation)
        {
            await _dbContext.StorageLocations.AddAsync(storageLocation);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
