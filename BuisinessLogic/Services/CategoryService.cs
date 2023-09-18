using BuisinessLogic.Interfaces;
using CarShop.Data;
using CarShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CarShopContext _context;
        public CategoryService(CarShopContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        public void Edit(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
        }

        public bool ExistCategory(int id)
        {
            return (_context.Category?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int? id)
        {
            return _context.Category.FirstOrDefault(m => m.Id == id);
        }

        public void Remove(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();

        }
    }

}
