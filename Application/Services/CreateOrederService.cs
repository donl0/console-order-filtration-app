using Application.DTO;
using Application.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public sealed class CreateOrederService : ICreateOrederService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDistrictRepository _districtRepository;

        public CreateOrederService(IOrderRepository orderRepository, IDistrictRepository districtRepository)
        {
            _orderRepository = orderRepository;
            _districtRepository = districtRepository;
        }

        public async Task<long> CreateAsync(CreateOrderDTO createOrderDto)
        {
            District district;

            if (await _districtRepository.CheckIfExistAsync(createOrderDto.DistrictName) == false)
            {
                district = new District(createOrderDto.DistrictName);

                await _districtRepository.CreateAsync(district);
            }
            else
            {
                district = await _districtRepository.GetByNameAsync(createOrderDto.DistrictName);
            }

            Order order = new Order(createOrderDto.UniqueNumber, createOrderDto.Weight, createOrderDto.DeliveryTime, district);

            await _orderRepository.CreateAsync(order);

            return order.Id;
        }
    }
}
