using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Deloitte_prof_task_Laszlo_Gazdag.DataContext.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Category { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public bool IsHazardous { get; set; }
        public bool IsDiscountEligible { get; set; }
        public bool IsFragile { get; set; }
    }
}
