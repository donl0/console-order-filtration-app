namespace Domain.Models
{
    internal interface IOrderRepository
    {
        public void CreateAsync(Order order);
        public IEnumerable<Order> GetCloseOrdersInHalfHourAsync(DateTime deliveryTime, string districtName);
    }
}
