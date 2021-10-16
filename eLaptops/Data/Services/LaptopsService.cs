using eLaptops.Data.Base;
using eLaptops.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Data.Services
{
    public class LaptopsService : EntityBaseRepository<Laptop>, ILaptopsService
    {

        private readonly AppDbContext _context;
        public LaptopsService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewLaptopAsync(NewLaptopVM data)
        {
            var newLaptop = new Laptop()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                Quantity = data.Quantity,
                ImageURL = data.ImageURL
            };
            await _context.Laptops.AddAsync(newLaptop);
            await _context.SaveChangesAsync();
        }

        public async Task<Laptop> GetLaptopByIdAsync(int id)
        {
            var laptopDetails = await _context.Laptops.FirstOrDefaultAsync(n => n.Id == id);
            return laptopDetails;
        }

        public async Task UpdateLaptopAsync(NewLaptopVM data)
        {
            var dbLaptop = await _context.Laptops.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbLaptop != null)
            {
                dbLaptop.Name = data.Name;
                dbLaptop.Description = data.Description;
                dbLaptop.Price = data.Price;
                dbLaptop.Quantity = data.Quantity;
                dbLaptop.ImageURL = data.ImageURL;
                await _context.SaveChangesAsync();
            }


        }
    }
}
