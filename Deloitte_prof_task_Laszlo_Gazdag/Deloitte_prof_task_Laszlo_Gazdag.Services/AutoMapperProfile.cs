using AutoMapper;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom(src => src.OrderItems.Sum(x => x.UnitPrice * x.Quantity)));
            CreateMap<Order, OrderDetailedDTO>()
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom(src => src.OrderItems.Sum(x => x.UnitPrice * x.Quantity)));

            CreateMap<OrderItemCreateDTO, OrderItem>();
            CreateMap<OrderItem, OrderItemDTO>();

            CreateMap<ProductCreateDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
