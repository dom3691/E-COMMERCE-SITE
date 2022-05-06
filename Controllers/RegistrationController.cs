using Ecomm.Contracts;
using Ecomm.Models;
using Ecomm.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecomm.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(User user)
        {
            if (user == null) ViewBag.InvalidLoginDetails = "Please fill the form";
            else
            {
               bool isuser = await _userService.AddUser(user);
                if(isuser == true)
                {
                    UserProductViewModel productViewModel = new UserProductViewModel();
                    productViewModel.IsSuccess = true;
                    return RedirectToAction("Index", "Home", productViewModel);
                }
            }
            return View();
        }
    }
}
