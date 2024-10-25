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
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ICreateOrederService createOrderService, ILogger<OrdersController> logger)
        {
            _createOrderService = createOrderService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateOrder([FromBody] CreateOrderDTO orderDTO, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateOrder request received with data: {@OrderDto}", orderDTO);

            long id = await _createOrderService.CreateAsync(orderDTO, cancellationToken);

            return Ok(id);
        }
    }
}
