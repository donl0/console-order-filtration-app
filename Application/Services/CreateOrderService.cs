using Application.DTO;
using Application.Interfaces;
using Domain.Models.Orders;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public sealed class CreateOrderService : ICreateOrederService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ILogger<CreateOrderService> _logger;

        public CreateOrderService(IOrderRepository orderRepository, IDistrictRepository districtRepository, ILogger<CreateOrderService> logger)
        {
            _orderRepository = orderRepository;
            _districtRepository = districtRepository;
            _logger = logger;
        }

        public async Task<long> CreateAsync(CreateOrderDTO createOrderDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting order creation with number: {UniqueNumber}", createOrderDto.UniqueNumber);

            District district;

            if (await _districtRepository.CheckIfExistAsync(createOrderDto.DistrictName) == false)
            {
                district = new District(createOrderDto.DistrictName);

                await _districtRepository.CreateAsync(district, cancellationToken);
            }
            else
            {
                district = await _districtRepository.GetByNameAsync(createOrderDto.DistrictName);
            }

            DateTime utfTime = DateTime.SpecifyKind(createOrderDto.DeliveryTime, DateTimeKind.Utc);

            Order order = new Order(createOrderDto.UniqueNumber, createOrderDto.Weight, utfTime, district);

            await _orderRepository.CreateAsync(order, cancellationToken);

            _logger.LogInformation("Order created with ID: {OrderId}", order.Id);

            return order.Id;
        }
    }
}
