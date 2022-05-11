﻿using EcommerceStore.Application.Exceptions;
using EcommerceStore.Application.Interfaces;
using EcommerceStore.Application.Models.InputModels;
using EcommerceStore.Application.Models.ViewModels;
using EcommerceStore.Domain.Entities;
using EcommerceStore.Domain.Interfaces;

namespace EcommerceStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrderAsync(OrderInputModel orderInputModel)
        {
            var order = new Order
            {
                ModifiedDate = orderInputModel.ModifiedDate,
                Status = orderInputModel.Status,
                UserId = orderInputModel.UserId
            };

            await _orderRepository.CreateAsync(order);

            await _orderRepository.SaveChangesAsync();
        }

        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            if (orders is null)
                throw new ValidationException(ExceptionMessages.OrderNotFound);

            var ordersViewModel = orders
                .Where(o => !o.IsDeleted)
                .Select(o => new OrderViewModel
                {
                    ModifiedDate = o.ModifiedDate,
                    Status = o.Status,
                    CustomerFullName = $"{o.User.FirstName}" + " " + $"{o.User.LastName}"
                })
                .ToList();

            return ordersViewModel;
        }

        public async Task<OrderViewModel> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null || order.IsDeleted)
                throw new ValidationException(ExceptionMessages.OrderNotFound, orderId);

            var orderViewModel = new OrderViewModel
            {
                ModifiedDate = order.ModifiedDate,
                Status = order.Status,
                CustomerFullName = $"{order.User.FirstName}" + " " + $"{order.User.LastName}"
            };

            return orderViewModel;
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
                throw new ValidationException(ExceptionMessages.OrderNotFound, orderId);

            order.IsDeleted = true;

            _orderRepository.Update(order);

            await _orderRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int orderId, OrderInputModel orderInputModel)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null || order.IsDeleted)
                throw new ValidationException(ExceptionMessages.OrderNotFound, orderId);

            order.ModifiedDate = orderInputModel.ModifiedDate;
            order.Status = orderInputModel.Status;
            order.UserId = orderInputModel.UserId;

            _orderRepository.Update(order);

            await _orderRepository.SaveChangesAsync();
        }
    }
}