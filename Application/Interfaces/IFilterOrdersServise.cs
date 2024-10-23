using Application.DTO;

namespace Application.Interfaces
{
    public interface IFilterOrdersServise
    {
        Task<long> Filter(FilterOrdersDTO filterOrdersDTO, CancellationToken cancellationToken);
    }
}