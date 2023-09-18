using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string IdsCars { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string CustomUserId { get; set; } = string.Empty;
    }
}
