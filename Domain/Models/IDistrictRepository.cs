namespace Domain.Models
{
    public interface IDistrictRepository
    {
        public Task CreateAsync(District district);
        public Task<District> GetByNameAsync(string name);
        public Task<bool> CheckIfExistAsync(string name);
    }
}
