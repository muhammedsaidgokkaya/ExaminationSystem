using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class QuizUserController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;
        private readonly IUserService _userService;
        private readonly IQuizUserService _quizUserService;

        public QuizUserController(ICategoryService categoryService, IQuizService quizService, IQuestionService questionService, IUserService userService, IQuizUserService quizUserService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
            _questionService = questionService;
            _userService = userService;
            _quizUserService = quizUserService;
        }

        public IActionResult Index()
        {
            var quizUser = _quizUserService.GetActiveQuizUserList();
            ViewBag.Quizs = _quizService.GetActiveList();
            ViewBag.Users = _userService.GetActiveList();
            return View(quizUser);
        }

        public IActionResult QuizUser(int id)
        {
            var quizUser = _quizUserService.GetQuizByUserId(id);
            return View(quizUser);
        }

        public IActionResult QuizUserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuizUserAdd(QuizUser model)
        {
            if (!ModelState.IsValid)
            {
                var quizUser = new QuizUser
                {
                    StartQuiz = model.StartQuiz,
                    FinishQuiz = model.FinishQuiz,
                    UserScore = 0,
                    QuizId = model.QuizId,
                    UserId = model.UserId,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true,
                    IsFinished = false,
                };

                _quizUserService.TAdd(quizUser);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult QuizUserDelete(int id)
        {
            var quizUser = _quizUserService.TGetById(id);
            if (quizUser == null)
            {
                return NotFound();
            }

            quizUser.IsDeleted = true;
            quizUser.ChangedOn = DateTime.Now;
            _quizUserService.TUpdate(quizUser);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuizUserPassive(int id)
        {
            var quizUser = _quizUserService.TGetById(id);
            if (quizUser == null)
            {
                return NotFound();
            }

            quizUser.IsActive = false;
            quizUser.ChangedOn = DateTime.Now;
            _quizUserService.TUpdate(quizUser);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuizUserActive(int id)
        {
            var quizUser = _quizUserService.TGetById(id);
            if (quizUser == null)
            {
                return NotFound();
            }

            quizUser.IsActive = true;
            quizUser.ChangedOn = DateTime.Now;
            _quizUserService.TUpdate(quizUser);

            return Json(new { success = true });
        }
    }
}
