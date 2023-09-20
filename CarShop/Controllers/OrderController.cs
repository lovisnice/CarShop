using BuisinessLogic.Interfaces;
using BuisinessLogic.Services;
using CarShop.Data;
using CarShop.Entities;
using CarShop.Helper;
using DataAccsess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace CarShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersServices _ordersService;
        private readonly IMailService _mailService;
        public OrderController(IOrdersServices ordersService,IMailService mailService)
        {
            _ordersService = ordersService;
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _ordersService.GetAll(userId);
            return View(orders);
        }

        public IActionResult Create()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            _ordersService.Create(userId, idList);
            HttpContext.Session.Remove("mycart");
            return RedirectToAction(nameof(Index));
        }
    }
}
