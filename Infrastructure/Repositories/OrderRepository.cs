using Domain.Models;
using Infrastructure.Db.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _dbContext;

        public OrderRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Order order, CancellationToken cancellationToken)
        {
            await _dbContext.Orders.AddAsync(order);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetCloseOrdersInHalfHourAsync(DateTime deliveryTime, string districtName)
        {
            var startTime = deliveryTime;
            var endTime = deliveryTime.AddMinutes(30);

            return await _dbContext.Orders
                .Where(order => order.DeliveryTime >= startTime
                             && order.DeliveryTime <= endTime
                             && order.District.Name == districtName)
                .ToListAsync();
        }
    }
}
