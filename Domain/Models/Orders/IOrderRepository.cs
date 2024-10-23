namespace Domain.Models.Orders
{
    public interface IOrderRepository
    {
        public Task CreateAsync(Order order, CancellationToken cancellationToken);
        public Task<List<Order>> GetCloseOrdersInHalfHourAsync(DateTime deliveryTime, string districtName);
    }
}
