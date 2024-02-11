using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class QuizController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;

        public QuizController(ICategoryService categoryService, IQuizService quizService, IQuestionService questionService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            var quiz = _quizService.GetActiveCategoryList();
            ViewBag.Categories = _categoryService.GetActiveList();
            return View(quiz);
        }

        public IActionResult QuizAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuizAdd(Quiz model)
        {
            if (!ModelState.IsValid)
            {
                var quiz = new Quiz
                {
                    QuizName = model.QuizName,
                    QuizDescription = model.QuizDescription,
                    QuizDuration = model.QuizDuration,
                    QuizScore = model.QuizScore,
                    CategoryId = model.CategoryId,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true,
                };

                _quizService.TAdd(quiz);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult QuizUpdate(int id)
        {
            var quiz = _quizService.TGetById(id);

            if (quiz == null)
            {
                return NotFound();
            }
            ViewBag.Categories = _categoryService.GetActiveList();
            return View(quiz);
        }

        [HttpPost]
        public IActionResult QuizUpdate(Quiz model)
        {
            if (!ModelState.IsValid)
            {
                var quizToUpdate = _quizService.TGetById(model.Id);

                if (quizToUpdate == null)
                {
                    return NotFound();
                }

                quizToUpdate.QuizName = model.QuizName;
                quizToUpdate.QuizDescription = model.QuizDescription;
                quizToUpdate.QuizDuration = model.QuizDuration;
                quizToUpdate.QuizScore = model.QuizScore;
                quizToUpdate.CategoryId = model.CategoryId;
                quizToUpdate.ChangedOn = DateTime.Now;

                _quizService.TUpdate(quizToUpdate);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult QuizDelete(int id)
        {
            var quiz = _quizService.TGetById(id);
            if (quiz == null)
            {
                return NotFound();
            }

            quiz.IsDeleted = true;
            quiz.ChangedOn = DateTime.Now;
            _quizService.TUpdate(quiz);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuizPassive(int id)
        {
            var quiz = _quizService.TGetById(id);
            if (quiz == null)
            {
                return NotFound();
            }

            quiz.IsActive = false;
            quiz.ChangedOn = DateTime.Now;
            _quizService.TUpdate(quiz);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuizActive(int id)
        {
            var quiz = _quizService.TGetById(id);
            if (quiz == null)
            {
                return NotFound();
            }

            quiz.IsActive = true;
            quiz.ChangedOn = DateTime.Now;
            _quizService.TUpdate(quiz);

            return Json(new { success = true });
        }
    }
}
