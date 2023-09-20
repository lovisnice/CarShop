using DataAccsess.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using CarShop.Entities;
using BuisinessLogic.DTOs;

namespace BusinessLogic.Helpers
{
    public class MapperProfile : Profile //AutoMapper
    {
        public MapperProfile()
        {
            //map Product=> ProductDto
            CreateMap<Car, CarDto>()
             .ForMember(productDto => productDto.CategoryName, opt => opt.MapFrom(product => product.Category.Name));

            CreateMap<Category, CategoryDto>().ReverseMap();
            //map ProductDto=>Product
            CreateMap<CarDto, Car>();

            CreateMap<Car, EditCarDto>()
           .ForMember(productDto => productDto.CategoryName, opt => opt.MapFrom(product => product.Category.Name));

            CreateMap<Car, EditCarDto>()
          .ForMember(productDto => productDto.Image, opt => opt.Ignore());
            //.ForMember(productDto => productDto.Id, opt => opt.Ignore());
            //map ProductDto=>Product
            CreateMap<EditCarDto, Car>();
        }
    }
}