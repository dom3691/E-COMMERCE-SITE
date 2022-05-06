using Ecomm.Contracts;
using Ecomm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecomm.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILatestNews _latestNewsService;
        private static int _productId;
        public ProductController(IProductService productService, ILatestNews latestNewsService)
        {
            _productService = productService;
            _latestNewsService = latestNewsService;
        }
        public async Task<IActionResult> Index(int id)
        {
            if(id > 0)
            {
                _productId = id;
            }
            UserProductViewModel userProductViewModel = new UserProductViewModel();
            userProductViewModel.Product = await _productService.GetProductById(_productId);
            userProductViewModel.Products = await _productService.GetAllProducts();
            return View(userProductViewModel);
        }
        
    }
}
