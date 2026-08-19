using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
