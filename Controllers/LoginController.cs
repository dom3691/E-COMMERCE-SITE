using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecomm.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthentication _authService;
        public LoginController(IAuthentication authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(User user)
        {
            user = await _authService.Login(user.Email, user.Password);
            if (user == null) ViewBag.InvalidLoginDetails = "Invalid Credentials";
            else
            {
                UserProductViewModel productViewModel = new UserProductViewModel();
                productViewModel.IsSuccess = true;
                return RedirectToAction("Index", "Home", productViewModel);
            }
            return View();
        }
    }
}
