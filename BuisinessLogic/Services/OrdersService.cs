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
        private readonly IMailService _mailService;
        public OrdersService(CarShopContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
        }
        public async Task Create(string userId, List<int> idList)
        {
            List<Car> products = idList.Select(id => _context.Car.Find(id)).ToList();
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                IdsCars = JsonSerializer.Serialize(idList),
                TotalPrice = (decimal)products.Sum(p => p.Price),
                CustomUserId = userId
            };
            string productsInfo = "";
            foreach (var id in products)
            {
                productsInfo += $"<li>{id.Manufacturer} - {id.Price}<li>";
            }
            

            string body = "<h1>Вітаємо!</h1>\r\n\r\n" +
                "<p>Ваше замовлення було успішно оформлено. Нижче наведена інформація про ваше замовлення:</p>\r\n\r\n  " +
                " <ul>\r\n" +
                $"<li>Номер замовлення: {newOrder.Id}</li>\r\n" +
                $"<li>Дата замовлення: {newOrder.OrderDate}</li>\r\n" +
                $"<li>Загальна сума: {newOrder.TotalPrice}</li>\r\n" +
                "</ul>\r\n\r\n" +
                "<h2>Список товарів:</h2>\r\n" +
                "<ul>\r\n" +
                $"{productsInfo}"+
                "</ul>\r\n\r\n" +
                "<p>Будь ласка, перевірте інформацію про ваше замовлення та зв'яжіться з нами, якщо є будь-які питання або потреба в додатковій інформації.</p>\r\n\r\n" +
                "<p>Дякуємо за ваше замовлення!</p>\r\n\r\n" +
                "<p>З найкращими побажаннями," +
                "<br>Команда CarShop</p>";
            //EMAIL from______________________________________________
            await _mailService.SendMailAsync("Order", body, "vovaprorok29@gmail.com", "vovaprorok29@gmail.com");

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
