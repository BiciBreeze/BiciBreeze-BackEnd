using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Model.Queries;
using Security.Rent.Domain.Repositories;
using Security.Rent.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using GetOrderByIdQuery = Security.Rent.Domain.Services.GetOrderByIdQuery;

namespace Security.Rent.Application.Internal.QueryServices
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

        public Task<Order?> Handle(GetOrderByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> Handle(Security.Rent.Domain.Model.Queries.GetOrderByIdQuery query)
        {
            return await _orderRepository.FindByIdAsync(query.OrderId);
        }
    }
}