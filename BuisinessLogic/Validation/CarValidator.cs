using BuisinessLogic.DTOs;
using CarShop.Entities;
using FluentValidation;

namespace CarShop.Validation
{
    public class CarValidator:AbstractValidator<CarDto>
    {
        public CarValidator()
        {
            RuleFor(car => car.Manufacturer).NotEmpty().WithMessage("Manufacturer is required.");
            RuleFor(car => car.CategoryId).LessThan(3).WithMessage("CategoryId must be less than 3.");
            RuleFor(car => car.Color).NotEmpty().WithMessage("Color is required.");
            RuleFor(car => car.Price).NotEmpty().GreaterThan(0).WithMessage("Price must be not empty or greater than 0");
            RuleFor(car => car.Year).InclusiveBetween(1900, DateTime.Now.Year).WithMessage($"Invalid year. {{PropertyName}} must be between 1900 & {DateTime.Now.Year}");
        }
    }
}
