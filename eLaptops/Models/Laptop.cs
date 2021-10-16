using eLaptops.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Models
{
    public class Laptop : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ImageURL { get; set; }
        int IEntityBase.ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
