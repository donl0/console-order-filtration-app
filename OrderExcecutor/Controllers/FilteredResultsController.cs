using Application.DTO;
using Application.Interfaces;
using Domain.Models.FilteredOrders;
using Domain.Models.Orders;
using Infrastructure.Repositories;
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
        public async Task<ActionResult<List<Order>>> InitializeFilteringAsync(DateTime timeAfterFirstOrder, string districtName, CancellationToken cancellationToken)
        {
            FilterOrdersDTO dto = new FilterOrdersDTO { TimeAfterFirstOrder = timeAfterFirstOrder, DistrictName = districtName };
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
