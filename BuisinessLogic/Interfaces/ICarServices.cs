using BuisinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Interfaces
{
    public interface ICarServices
    {
        List<CategoryDto> GetAllCategory();
        List<CarDto> GetAll();
        // List<ProductDto> GetByOrderName();
        List<CarDto> GetByOrderPrice();
        CarDto? Get(int? id);
        EditCarDto? GetEditCarDto(int? id);
        void Creat(CreateCarDto product);
        void Edit(EditCarDto product);
        void Delete(int? id);
    }
}
