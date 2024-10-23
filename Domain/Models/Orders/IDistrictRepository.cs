namespace Domain.Models.Orders
{
    public interface IDistrictRepository
    {
        public Task CreateAsync(District district, CancellationToken cancellationToken);
        public Task<District> GetByNameAsync(string name);
        public Task<bool> CheckIfExistAsync(string name);
    }
}
