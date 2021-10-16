using eLaptops.Data;
using eLaptops.Data.Services;
using eLaptops.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLaptops.Controllers
{
    public class LaptopsController : Controller
    {

        private readonly ILaptopsService _service;

        public LaptopsController(ILaptopsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allLaptops = await _service.GetAllAsync();
            return View(allLaptops);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allLaptops = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allLaptops.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allLaptops);
        }

        //GET: Laptops/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var laptopDetail = await _service.GetLaptopByIdAsync(id);
            return View(laptopDetail);
        }

        //GET: Laptops/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our Store";

            ViewBag.Description = "This is the store description";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewLaptopVM laptop)
        {
            if (!ModelState.IsValid)
            {
                return View(laptop);
            }

            await _service.AddNewLaptopAsync(laptop);
            return RedirectToAction(nameof(Index));
        }


        //GET: Laptops/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var laptopDetails = await _service.GetLaptopByIdAsync(id);

            if (laptopDetails == null) return View("NotFound");

            var response = new NewLaptopVM()
            {
                Id = laptopDetails.Id,
                Name = laptopDetails.Name,
                Description = laptopDetails.Description,
                Price = laptopDetails.Price,
                Quantity = laptopDetails.Quantity,
                ImageURL = laptopDetails.ImageURL

            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewLaptopVM laptop)
        {

            if (id != laptop.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(laptop);
            }

            await _service.UpdateLaptopAsync(laptop);
            return RedirectToAction(nameof(Index));
        }

    }
}
