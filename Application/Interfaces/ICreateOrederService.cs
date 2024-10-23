using Application.DTO;

namespace Application.Interfaces
{
    public interface ICreateOrederService
    {
        Task<long> CreateAsync(CreateOrderDTO createOrderDto, CancellationToken cancellationToken);
    }
}