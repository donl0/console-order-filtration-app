namespace Domain.Models
{
    internal interface IOrderRepository
    {
        public void AddAsync(Order order);
        public IEnumerable<Order> GetCloseOrdersInHalfHourAsync(DateTime deliveryTime, string districtName);
    }
}
