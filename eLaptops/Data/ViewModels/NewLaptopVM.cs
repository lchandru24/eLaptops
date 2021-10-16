using eLaptops.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Models
{
    public class NewLaptopVM
    {

        public int Id { get; set; }

        [Display(Name = "Laptop Name")]
        [Required(ErrorMessage ="Name is required")]

        public string Name { get; set; }

        [Display(Name = "Specifications")]
        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        [Display(Name = "Price in INR")]
        [Required(ErrorMessage = "PRice is required")]

        public double Price { get; set; }

        [Display(Name = "Quantity Available")]
        [Required(ErrorMessage = "Quantity is required")]

        public int Quantity { get; set; }

        [Display(Name = "ImageURL")]
        [Required(ErrorMessage = "ImageURL is required")]

        public string ImageURL { get; set; }
        
    }
}
