using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var user = _userService.GetActiveList();
            return View(user);
        }

        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(User model)
        {
            if (!ModelState.IsValid)
            {
                var quiz = new User
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Password = model.Password,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true,
                };

                _userService.TAdd(quiz);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UserUpdate(int id)
        {
            var user = _userService.TGetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult UserUpdate(User model)
        {
            if (!ModelState.IsValid)
            {
                var userToUpdate = _userService.TGetById(model.Id);

                if (userToUpdate == null)
                {
                    return NotFound();
                }

                userToUpdate.Name = model.Name;
                userToUpdate.UserName = model.UserName;
                userToUpdate.Password = model.Password;
                userToUpdate.ChangedOn = DateTime.Now;

                _userService.TUpdate(userToUpdate);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UserDelete(int id)
        {
            var user = _userService.TGetById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            user.ChangedOn = DateTime.Now;
            _userService.TUpdate(user);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UserPassive(int id)
        {
            var user = _userService.TGetById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = false;
            user.ChangedOn = DateTime.Now;
            _userService.TUpdate(user);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UserActive(int id)
        {
            var user = _userService.TGetById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = true;
            user.ChangedOn = DateTime.Now;
            _userService.TUpdate(user);

            return Json(new { success = true });
        }
    }
}
