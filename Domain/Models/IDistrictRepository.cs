namespace Domain.Models
{
    public interface IDistrictRepository
    {
        public void CreateAsync(District district);
        public District GetByNameAsync(string name);
        public bool CheckIfExist(string name);
    }
}
