using DataAccsess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogic.Interfaces
{
    public interface IOrdersServices
    {
        IEnumerable<Order> GetAll(string userId);
        //Order GetById(int id, string userId);
        void Create(string userId, List<int> idList);
    }
}
