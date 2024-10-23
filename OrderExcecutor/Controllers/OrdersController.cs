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
        public async Task<ActionResult<long>> CreateOrder(Guid uniqueNumber, int weight, DateTime deliveryTime, string districtName, CancellationToken cancellationToken)
        {
            CreateOrderDTO orderDTO = new CreateOrderDTO { UniqueNumber = uniqueNumber, Weight = weight, DeliveryTime = deliveryTime, DistrictName = districtName };

            long id = await _createOrderService.CreateAsync(orderDTO, cancellationToken);

            return Ok(id);
        }
    }
}
