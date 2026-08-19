using AutoMapper;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Context;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.Services
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync(ProductCreateDTO productCreateDto);
    }
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductCreateDTO productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
