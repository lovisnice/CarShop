using AutoMapper;
using BuisinessLogic.DTOs;
using BuisinessLogic.Interfaces;
using CarShop.Entities;
using DataAccsess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Services
{
    public class CarService : ICarServices
    {
        private readonly IRepository<Car> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        //private readonly ShopMVCDbContext _context;

        public CarService(IRepository<Car> productRepo,
                                IRepository<Category> categoryRepo,
                                IMapper mapper,
                                IFileService fileService)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _fileService = fileService;
        }

        public void Creat(CreateCarDto productDto)
        {
            //save image to server
            string path = "/images";
            string imagePath = _fileService.SaveProductImage(productDto.Image).Result;

            Car product = new Car()
            {
                Manufacturer = productDto.Manufacturer,
                Description = productDto.Description,
                Color = productDto.Color,
                Year = productDto.Year,
                Price = productDto.Price,
                ImagePath = imagePath,
                CategoryId = productDto.CategoryId,
            };
            //var product=_mapper.Map<Product>(productDto);    // ProductDto => Product (Entity)
            _productRepo.Insert(product);
            _productRepo.Save();
        }

        public void Delete(int? id)
        {

            var product = _productRepo.GetByID(id);
            _fileService.DeleteProductImage(product.ImagePath);
            if (product != null)
            {
                _productRepo.Delete(product);
                _productRepo.Save();

            }
        }

        public void Edit(EditCarDto productDto)
        {
            //delete oldfile from "images"
            var productOld = Get(productDto.Id);
            if (productOld != null)
            {
                //save new file
                _fileService.DeleteProductImage(productOld.ImagePath);
                //save image to server
                string imagePath = _fileService.UpdateProductImage(productDto.ImagePath, productDto.Image).Result;
                productDto.ImagePath = imagePath;

                var product = _mapper.Map<Car>(productDto);
                _productRepo.Update(product);
                _productRepo.Save();
            }
        }

        public CarDto? Get(int? id)
        {
            // return _productRepo.GetByID(id);
            //return GetAll().FirstOrDefault(x => x.Id == id);
            //return _productRepo.Get(includeProperties: new[] { "Category" }).Where(p=>p.Id==id).SingleOrDefault();
            // return _productRepo.Get(filter:x=>x.Id==id, includeProperties: new[] { "Category" }).SingleOrDefault();
            //return _productRepo.Get(filter: x => x.Id == id, includeProperties: new[] { "Category" }).SingleOrDefault();

            //using custom mapping object Product =>object  ProductDto
            //get from DB with Repository
            var product = _productRepo.Get(filter: x => x.Id == id, includeProperties: new[] { "Category" }).SingleOrDefault();
            //ProductDto productDto = new ProductDto()
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    ImagePath = product.ImagePath,
            //    CategoryId = product.CategoryId,
            //    CategoryName=product.Category.Name
            //};
            return _mapper.Map<CarDto>(product);
        }

        public List<CarDto> GetAll()
        {   //include properties: LEFT JOIN in SQL
            //return _productRepo.Get(includeProperties: new[] { "Category"}).ToList();

            var products = _productRepo.Get(includeProperties: new[] { "Category" }).ToList();

            //return products.Select(product => new ProductDto
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description,
            //    Price = product.Price,
            //    ImagePath = product.ImagePath,
            //    CategoryId = product.CategoryId,
            //    CategoryName = product.Category.Name
            //}).ToList();

            return _mapper.Map<List<CarDto>>(products);
        }

        public List<CategoryDto> GetAllCategory()
        {
            //return _context.Categories.ToList();
            //return _categoryRepo.Get().ToList();
            var categories = _categoryRepo.Get();
            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            }).ToList();
        }

        public List<CarDto> GetByOrderPrice()
        {
            var products = _productRepo.Get(orderBy: q => q.OrderBy(p => p.Price), includeProperties: new[] { "Category" }).ToList();

            return products.Select(product => new CarDto
            {
                Id = product.Id,
                Manufacturer = product.Manufacturer,
                Color = product.Color,
                Year = product.Year,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            }).ToList();
        }

        public EditCarDto? GetEditCarDto(int? id)
        {
            var product = Get(id);

            return new EditCarDto()
            {
                Id = product.Id,
                Manufacturer = product.Manufacturer,
                Color = product.Color,
                Year= product.Year,
                Description = product.Description,
                Price = product.Price,
                ImagePath = product.ImagePath,
                CategoryId = product.CategoryId,
            };
        }
    }
}
