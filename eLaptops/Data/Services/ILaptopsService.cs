using eLaptops.Data.Base;
using eLaptops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Data.Services
{
    public interface ILaptopsService : IEntityBaseRepository<Laptop>
    {
        Task<Laptop> GetLaptopByIdAsync(int id);
        Task AddNewLaptopAsync(NewLaptopVM data);

        Task UpdateLaptopAsync(NewLaptopVM data);
    }
}
