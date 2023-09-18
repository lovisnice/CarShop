using CarShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        //_______________________________________
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
