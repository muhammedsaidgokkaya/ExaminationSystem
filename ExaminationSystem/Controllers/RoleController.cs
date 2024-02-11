using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class RoleController : Controller
	{
        private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerTypeService _answerTypeService;
        private readonly IAnswerValueService _answerValueService;
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;

        public RoleController(ICategoryService categoryService, IQuizService quizService, IQuestionService questionService, IAnswerTypeService answerTypeService, IAnswerValueService answerValueService, IUserRoleService userRoleService, IRoleService roleService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
            _questionService = questionService;
            _answerTypeService = answerTypeService;
            _answerValueService = answerValueService;
            _userRoleService = userRoleService;
            _roleService = roleService;
        }

        public IActionResult Index(int id)
        {
            var user = _userRoleService.GetUserRoleByUserId(id);
            return View(user);
        }

        public IActionResult UserRole(int id)
        {
            var model = new UserRole
            {
                UserId = id
            };
            ViewBag.Roles = _roleService.GetActiveList();
            return View(model);
        }

        [HttpPost]
        public IActionResult UserRoleAdd(UserRole model)
        {
            if (!ModelState.IsValid)
            {
                var userRole = new UserRole
                {
                    UserId = model.UserId,
                    RoleId = model.RoleId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                };

                _userRoleService.TAdd(userRole);
                return RedirectToAction("Index", "User");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult UserRoleDelete(int id)
        {
            var userRole = _userRoleService.TGetById(id);
            if (userRole == null)
            {
                return NotFound();
            }

            userRole.IsDeleted = true;
            userRole.ChangedOn = DateTime.Now;
            _userRoleService.TUpdate(userRole);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UserRolePassive(int id)
        {
            var userRole = _userRoleService.TGetById(id);
            if (userRole == null)
            {
                return NotFound();
            }

            userRole.IsActive = false;
            userRole.ChangedOn = DateTime.Now;
            _userRoleService.TUpdate(userRole);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UserRoleActive(int id)
        {
            var userRole = _userRoleService.TGetById(id);
            if (userRole == null)
            {
                return NotFound();
            }

            userRole.IsActive = true;
            userRole.ChangedOn = DateTime.Now;
            _userRoleService.TUpdate(userRole);

            return Json(new { success = true });
        }
    }
}
