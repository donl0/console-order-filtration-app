using Application.DTO;
using Application.Interfaces;
using Domain.Models.FilteredOrders;
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

        [HttpPost("initialize")]
        public async Task<ActionResult<List<Order>>> InitializeFilteringAsync([FromBody] FilterOrdersDTO dto, CancellationToken cancellationToken)
        {
            List<Order> orders = await _filterOrdersServise.Filter(dto, cancellationToken);

            return Ok(orders);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllFilteredResults()
        {
            List<FilteredResult> results = await _filterOrdersServise.GetAllAsync();
            return Ok(results);
        }
    }
}
