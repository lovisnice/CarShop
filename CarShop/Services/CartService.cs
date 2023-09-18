using BuisinessLogic.DTOs;
using BuisinessLogic.Interfaces;
using CarShop.Helper;

namespace CarShop.Services
{
    public class CartService : ICartService
    {
        private readonly HttpContext? _httpContext;
        private readonly ICarServices _productsService;

        public CartService(IHttpContextAccessor httpContextAccessor, ICarServices productsService)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _productsService = productsService;
        }
        public IEnumerable<CarDto> GetProducts()
        {
            List<int> idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            List<CarDto> products = idList.Select(id => _productsService.Get(id)).ToList();
            return products;
        }
        public void Add(int id)
        {
            if (_productsService.Get(id) == null) return;
            List<int>? idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            idList.Add(id); //add id of product to cart
            _httpContext.Session.SetObject<List<int>>("mycart", idList);
        }

        public void Remove(int id)
        {
            if (_productsService.Get(id) == null) return;
            List<int>? idList = _httpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            idList.Remove(id); //delete id of product to cart
            _httpContext.Session.SetObject<List<int>>("mycart", idList);
        }
    }
}
