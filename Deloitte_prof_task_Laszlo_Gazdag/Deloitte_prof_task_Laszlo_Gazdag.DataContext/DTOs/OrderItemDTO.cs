using Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }        
        public int ProductId { get; set; }        
        public decimal ItemTotal => Quantity * UnitPrice;
    }

    public class OrderItemCreateDTO
    {        
        public int Quantity { get; set; }          
        public int ProductId { get; set; }        
    }
}
