namespace Domain.Models
{
    public interface IOrderRepository
    {
        public Task CreateAsync(Order order, CancellationToken cancellationToken);
        public Task<IEnumerable<Order>> GetCloseOrdersInHalfHourAsync(DateTime deliveryTime, string districtName);
    }
}
