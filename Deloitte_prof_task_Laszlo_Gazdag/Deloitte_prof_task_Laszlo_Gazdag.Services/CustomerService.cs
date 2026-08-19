using AutoMapper;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Context;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs;
using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;

namespace Deloitte_prof_task_Laszlo_Gazdag.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto);
    }

    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> CreateCustomerAsync(CustomerCreateDTO customerCreateDto)
        {
            var customer = _mapper.Map<Customer>(customerCreateDto);

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}