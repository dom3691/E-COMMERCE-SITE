using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ecomm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ILatestNews _latestNewsService;
        public HomeController(ILogger<HomeController> logger, IProductService productService, ILatestNews latestNewsService)
        {
            _logger = logger;
            _productService = productService;
            _latestNewsService = latestNewsService;
        }
        public async Task<IActionResult> Index(UserProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                productViewModel.Products = await _productService.GetAllProducts();
                productViewModel.LatestNews = await _latestNewsService.GetAllLatestNews();
                return View(productViewModel);
            }
            return View(productViewModel);
        }     
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> LoadMore(int page=1)
        {
            UserProductViewModel productViewModel = new UserProductViewModel();
            productViewModel.Products = await _productService.GetAllProducts();
            productViewModel.IsSuccess = true;
            productViewModel.ProductPerPage = 5;
            productViewModel.CurrentPage = page;
            return View(productViewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
