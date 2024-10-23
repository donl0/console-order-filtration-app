using Domain.Models;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly IDbContext _dbContext;
        private readonly CancellationToken _token;

        public DistrictRepository(IDbContext dbContext, CancellationToken token)
        {
            _dbContext = dbContext;
            _token = token;
        }

        public async Task<bool> CheckIfExistAsync(string name)
        {
            return await _dbContext.Districts.AnyAsync(d => d.Name == name);
        }

        public async Task CreateAsync(District district)
        {
            await _dbContext.Districts.AddAsync(district);
            await _dbContext.SaveChangesAsync(_token);
        }

        public async Task<District> GetByNameAsync(string name)
        {
            return await _dbContext.Districts.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
