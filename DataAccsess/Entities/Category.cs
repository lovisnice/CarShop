﻿using System.ComponentModel.DataAnnotations;

namespace CarShop.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Car> Cars { get; } = new List<Car>();
    }
}
