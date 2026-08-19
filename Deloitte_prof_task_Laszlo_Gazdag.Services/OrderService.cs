using AutoMapper;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Context;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreateDto);
        Task<IList<OrderDTO>> GetAllAsync();
        Task<OrderDetailedDTO> GetByIdAsync(int id);
    }
    public class OrderService: IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreateDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == orderCreateDto.CustomerId);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with id - {orderCreateDto.CustomerId} not found");
            }

            if (orderCreateDto.OrderItems is null || !orderCreateDto.OrderItems.Any())
            {
                throw new ValidationException("Order must contain at least one item");
            }

            var productIds = orderCreateDto.OrderItems.Select(x => x.ProductId).Distinct().ToList();
            var products = await _context.Products
                .Where(x => productIds.Contains(x.Id))
                .ToListAsync();
            
            var missingIds = productIds.Except(products.Select(x => x.Id)).ToList();
            if (missingIds.Any())
                throw new KeyNotFoundException($"Product(s) not found with id(s): {string.Join(", ", missingIds)}");

            if (orderCreateDto.OrderItems.Any(x => x.Quantity <= 0))
                throw new ValidationException("Quantity must be greater than zero");

            var orderItems = orderCreateDto.OrderItems.Select(itemDto =>
            {
                var product = products.First(p => p.Id == itemDto.ProductId);
                return new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    UnitPrice = product.UnitPrice
                };
            }).ToList();

            var order = new Order
            {
                Customer = customer,
                CustomerId = customer.Id,
                OrderDate = DateTime.UtcNow,
                OrderItems = orderItems
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IList<OrderDTO>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(x => x.OrderItems)
                .ToListAsync();

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<OrderDetailedDTO> GetByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                throw new KeyNotFoundException($"Order with id - {id} not found!");
            }

            return _mapper.Map<OrderDetailedDTO>(order);
        }
    }
}
