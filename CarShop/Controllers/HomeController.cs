using BuisinessLogic.Interfaces;
using BuisinessLogic.Services;
using CarShop.Data;
using CarShop.Entities;
using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq; // Add this using statement for LINQ

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarServices _carService;

        public HomeController(ICarServices carService)
        {
            _carService = carService;
        }

        public IActionResult Index(string sort)
        {

            var cars = _carService.GetAll();
            //sort = HttpContext.Session.GetString("sort");
            


            return View(cars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
