using Application.DTO;
using Application.Interfaces;
using Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace OrderExcecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteredResultsController : ControllerBase
    {
        private readonly IFilterOrdersServise _filterOrdersServise;

        public FilteredResultsController(IFilterOrdersServise filterOrdersServise)
        {
            _filterOrdersServise = filterOrdersServise;
        }

        [HttpGet()]
        public async Task<ActionResult<List<Order>>> Get(DateTime timeAfterFirstOrder, string districtName, CancellationToken cancellationToken)
        {
            FilterOrdersDTO dto = new FilterOrdersDTO { TimeAfterFirstOrder = timeAfterFirstOrder, DistrictName = districtName };
            List<Order> orders = await _filterOrdersServise.Filter(dto, cancellationToken);

            return Ok(orders);
        }
    }
}
