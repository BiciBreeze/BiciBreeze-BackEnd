using Microsoft.AspNetCore.Mvc;
using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Model.Commands;
using Security.Rent.Domain.Model.Queries;
using Security.Rent.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetOrderByIdQuery = Security.Rent.Domain.Services.GetOrderByIdQuery;

namespace Security.Rent.Interfaces.REST.Transform
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IOrderCommandService _orderCommandService;

        public OrderController(IOrderQueryService orderQueryService, IOrderCommandService orderCommandService)
        {
            _orderQueryService = orderQueryService;
            _orderCommandService = orderCommandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var orders = await _orderQueryService.Handle(query);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery { OrderId = id };
            var order = await _orderQueryService.Handle(query);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            await _orderCommandService.Handle(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = command.OrderId }, command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _orderCommandService.UpdateOrder(order);
            return NoContent();
        }
    }
}