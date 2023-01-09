using EXERCICE3.Services;
using Microsoft.AspNetCore.Mvc;

namespace EXERCICE3.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetUserInfoService _service1,_service2;

        public UserController(IGetUserInfoService service1, IGetUserInfoService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }

        public IActionResult Index()
        {
            string username = _service1.GetUserName("ayoub");
            string hashed_password = _service2.GetPasswordHash("mypassword");

            ViewBag.username = username;
            ViewBag.hashed_password = hashed_password;   
            return View();
        }
    }
}
