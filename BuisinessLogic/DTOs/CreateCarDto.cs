using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.DTOs
{
    public class CreateCarDto
    {
        public string Manufacturer { get; set; }
        public string Color { get; set; }
        
        public int Year { get; set; }
        public decimal Price { get; set; }
       
        public string Description { get; set; }
        //_______________________________________
        public IFormFile Image { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
