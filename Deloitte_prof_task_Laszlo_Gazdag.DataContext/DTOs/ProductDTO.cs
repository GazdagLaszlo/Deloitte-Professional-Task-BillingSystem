using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.DataContext.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public bool IsHazardous { get; set; }
        public bool IsDiscountEligible { get; set; }
        public bool IsFragile { get; set; }
    }
    public class ProductCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public bool IsHazardous { get; set; }
        public bool IsDiscountEligible { get; set; }
        public bool IsFragile { get; set; }
    }
}
