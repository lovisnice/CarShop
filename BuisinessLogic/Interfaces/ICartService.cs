using BuisinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Interfaces
{
    public interface ICartService
    {
        IEnumerable<CarDto> GetProducts();
        void Add(int id);
        void Remove(int id);
    }
}
