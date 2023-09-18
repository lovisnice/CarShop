using BuisinessLogic.Interfaces;
using CarShop.Data;
using CarShop.Entities;
using CarShop.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            return View(_cartService.GetProducts());
        }

        public IActionResult Add(int id)
        {
            _cartService.Add(id);
            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult Remove(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
