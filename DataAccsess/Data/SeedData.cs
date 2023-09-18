using CarShop.Entities;
using System;
using System.Collections.Generic;

namespace CarShop.Data
{
    public static class SeedData
    {
        public static List<Car> GetCars()
        {
            return new List<Car>
            {
                new Car { Id = 1, Manufacturer = "Toyota", CategoryId = 1, Category = null, Color = "Blue", Year = 2022, Price = 25000, Description = "Compact sedan", ImagePath = "car1.jpg" },
                new Car { Id = 2, Manufacturer = "Honda", CategoryId = 1, Category = null, Color = "Red", Year = 2021, Price = 22000, Description = "Family sedan", ImagePath = "car2.jpg" },
                new Car { Id = 3, Manufacturer = "Ford", CategoryId = 2, Category = null, Color = "Black", Year = 2023, Price = 30000, Description = "Sporty coupe", ImagePath = "car3.jpg" },
                new Car { Id = 4, Manufacturer = "Chevrolet", CategoryId = 2, Category = null, Color = "Silver", Year = 2022, Price = 28000, Description = "Coupe with advanced features", ImagePath = "car4.jpg" },
                new Car { Id = 5, Manufacturer = "Tesla", CategoryId = 3, Category = null, Color = "White", Year = 2023, Price = 62000, Description = "Electric SUV", ImagePath = "car5.jpg" },
                new Car { Id = 6, Manufacturer = "BMW", CategoryId = 3, Category = null, Color = "Gray", Year = 2021, Price = 45000, Description = "Luxury SUV", ImagePath = "car6.jpg" },
                new Car { Id = 7, Manufacturer = "Audi", CategoryId = 2, Category = null, Color = "Blue", Year = 2020, Price = 35000, Description = "Audi coupe", ImagePath = "car7.jpg" },
                new Car { Id = 8, Manufacturer = "Mercedes-Benz", CategoryId = 1, Category = null, Color = "Black", Year = 2023, Price = 50000, Description = "Elegant sedan", ImagePath = "car8.jpg" },
                new Car { Id = 9, Manufacturer = "Lexus", CategoryId = 3, Category = null, Color = "Silver", Year = 2022, Price = 48000, Description = "Luxury SUV with hybrid technology", ImagePath = "car9.jpg" },
                new Car { Id = 10, Manufacturer = "Hyundai", CategoryId = 1, Category = null, Color = "Red", Year = 2021, Price = 23000, Description = "Affordable compact sedan", ImagePath = "car10.jpg" }
            };

        }

        public static List<Category> GetCategory()
        {
            return new List<Category>()
            {
                new Category(){ Id=1, Name="Cedan", Description="None"},
                new Category(){ Id=2, Name="Coupe", Description="None"},
                new Category(){ Id=3, Name="SVC", Description="None"},
            };
        }

       
    }
}
