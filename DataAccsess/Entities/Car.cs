using CarShop.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Entities
{
    // Car.cs
    [EntityTypeConfiguration(typeof(CarConfiguration))]
    public class Car
    {

        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public int CategoryId { get; set; }
        //navigation property
        public Category? Category { get; set; }
        public string Color { get; set; }

        public int Year { get; set; }
        public decimal Price { get; set; }
        //_______________________________________
        public string? Description { get; set; }
        public string? ImagePath { get; set; }

    }

}
