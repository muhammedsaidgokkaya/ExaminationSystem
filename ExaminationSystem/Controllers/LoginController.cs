using BusinessLayer.Abstract;
using EntityLayer.Entity;
using EntityLayer.Enum;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userservice;

        public LoginController(IUserService userservice)
        {
            _userservice = userservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var login = _userservice.UserLoginControl(user);
            if (login != null)
            {
                var loginControl = login.UserRole.Any(x => x.RoleId == (int)RoleType.Admin);
                var adminRoleId = login.UserRole.Where(x => x.RoleId == (int)RoleType.Admin).FirstOrDefault();
                var userRoleId = login.UserRole.Where(x => x.RoleId == (int)RoleType.Uye).FirstOrDefault();
				if (loginControl)
                {
                    HttpContext.Session.SetInt32("userId", login.Id);
                    HttpContext.Session.SetInt32("roleId", adminRoleId.RoleId);
                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    HttpContext.Session.SetInt32("userId", login.Id);
					HttpContext.Session.SetInt32("roleId", userRoleId.RoleId);
					return RedirectToAction("Index", "Student");
                }
            }
            else
            {
                return View();
            }
        }
    }
}
