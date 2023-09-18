using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarShop.Entities;
using CarShop.Data;
using Microsoft.AspNetCore.Authorization;
using static ShopMVC.Seeder;
using BuisinessLogic.Interfaces;
using BuisinessLogic.Services;
using BuisinessLogic.DTOs;

namespace CarShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarsController : Controller
    {
        private readonly ICarServices _carService;

        public CarsController(ICarServices carsServices)
        {
            _carService = carsServices;
        }


        // GET: Cars
        [AllowAnonymous]
        public IActionResult Index(string sort)
        {
            var cars = _carService.GetAll();


            return View(cars);
        }

        // GET: Cars/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null || _carService.GetAll() == null)
            {
                return NotFound();
            }

            var car = _carService.Get(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _carService.GetAllCategory();
            ViewBag.ListCategory = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(CreateCarDto car)
        {
            if (!ModelState.IsValid)
            {
                var categories = _carService.GetAllCategory();
                ViewBag.ListCategory = new SelectList(categories, "Id", "Name");
                return View(car);
            }
            _carService.Creat(car);
            return RedirectToAction("Index");

        }

        // GET: Cars/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var product = _carService.GetEditCarDto(id);

            if (product != null)
            {
                var categories = _carService.GetAllCategory();
                ViewBag.ListCategory = new SelectList(categories, "Id", "Name", product.CategoryId);
                return View(product);

            }
            return NotFound();
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCarDto car)
        {
            _carService.Edit(car);
            return RedirectToAction("Index");
        }
        
        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
