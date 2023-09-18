using BuisinessLogic.Interfaces;
using CarShop.Data;
using CarShop.Entities;
using DataAccsess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BuisinessLogic.Services
{
    public class OrdersService : IOrdersServices
    {
        private readonly CarShopContext _context;
        public OrdersService(CarShopContext context)
        {
            _context = context;
        }
        public void Create(string userId, List<int> idList)
        {
            List<Car> products = idList.Select(id => _context.Car.Find(id)).ToList();
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                IdsCars = JsonSerializer.Serialize(idList),
                TotalPrice = (decimal)products.Sum(p => p.Price),
                CustomUserId = userId
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll(string userId)
        {
            return _context.Orders.Where(o => o.CustomUserId == userId).ToList();
        }

        //public Order GetById(int id, string userId)
        //{

        //}
    }
}
