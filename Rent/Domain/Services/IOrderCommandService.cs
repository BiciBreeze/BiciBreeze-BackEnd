using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Rent.Domain.Model.Commands;
using Security.Rent.Domain.Model.Queries;

namespace Security.Rent.Domain.Services
{
    public class OrderQueryService : IOrderQueryService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueryService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order?> Handle(GetOrderByIdQuery query)
        {
            return await _orderRepository.FindByIdAsync(query.OrderId);
        }
    }

    public class GetAllOrdersQuery
    {
    }

    public class GetOrderByIdQuery
    {
        public int OrderId { get; set; }
    }

    public interface IOrderCommandService
    {
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
        Task Handle(CreateOrderCommand command);
    }
}