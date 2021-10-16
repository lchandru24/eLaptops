using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public int LaptopId { get; set; }

        public Laptop Laptop { get; set;  }

        public int OrderId { get; set; }

        public Order Order { get; set; }


    }
}
