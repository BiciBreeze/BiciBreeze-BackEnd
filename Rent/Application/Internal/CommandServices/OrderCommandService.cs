using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Model.Commands;
using Security.Rent.Domain.Repositories;
using Security.Rent.Domain.Services;
using Security.Shared.Domain.Repositories;

namespace Security.Rent.Application.Internal.CommandServices;

public class OrderCommandService : IOrderCommandService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateOrderCommand command)
    {
        var order = new Order.ConcreteOrder(command.BikeType, command.PickupDate, command.PickupTime, command.DropOffDate, command.DropOffTime, command.PhoneNumber);
        try
        {
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating order: {e.Message}");
        }
    }

    public async Task<Order?> Handle(GetOrderByIdCommand command)
    {
        var order = await _orderRepository.FindByIdAsync(command.OrderId);
        if (order is null)
            throw new Exception($"Order with ID {command.OrderId} not found");
        return order;
    }

    public async Task CreateOrder(Order order)
    {
        try
        {
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating order: {e.Message}");
        }
    }

    public async Task UpdateOrder(Order order)
    {
        try
        {
            _orderRepository.Update(order);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while updating order: {e.Message}");
        }
    }
}