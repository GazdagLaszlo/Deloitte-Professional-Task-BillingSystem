using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }        
        public decimal TotalAmount { get; set; }
    }

    public class OrderCreateDTO
    {        
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemCreateDTO> OrderItems { get; set; } = new List<OrderItemCreateDTO>();
    }
}
