using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace OrderExcecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrederService _createOrderService;

        public OrdersController(ICreateOrederService createOrderService)
        {
            _createOrderService = createOrderService;
        }

        [HttpPost]
        public async Task<ActionResult<long>> Post([FromBody] CreateOrderDTO createOrderDto)
        {
            long id = await _createOrderService.CreateAsync(createOrderDto);

            return Ok(id);
        }
    }
}
