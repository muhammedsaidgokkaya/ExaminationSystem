using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class QuestionController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;
        private readonly IQuestionService _questionService;
        private readonly IAnswerTypeService _answerTypeService;
        private readonly IAnswerValueService _answerValueService;

        public QuestionController(ICategoryService categoryService, IQuizService quizService, IQuestionService questionService, IAnswerTypeService answerTypeService, IAnswerValueService answerValueService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
            _questionService = questionService;
            _answerTypeService = answerTypeService;
            _answerValueService = answerValueService;
        }

        public IActionResult Index(int id)
        {
            var question = _questionService.GetQuestionsByQuizId(id);
            return View(question);
        }

        public IActionResult Question(int id)
        {
            var model = new Question
            {
                QuizId = id
            };
            ViewBag.AnswerType = _answerTypeService.GetActiveList();
            return View(model);
        }

        [HttpPost]
        public IActionResult QuestionAdd(Question model)
        {
            if (!ModelState.IsValid)
            {
                var question = new Question
                {
                    QuestionName = model.QuestionName,
                    AnswerTypeId = model.AnswerTypeId,
                    QuizId = model.QuizId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                };

                _questionService.TAdd(question);
                return RedirectToAction("Index", "Quiz");
            }

            return View(model);
        }

        public IActionResult QuestionUpdate(int id)
        {
            var question = _questionService.TGetById(id);

            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        [HttpPost]
        public IActionResult QuestionUpdate(Question model)
        {
            if (!ModelState.IsValid)
            {
                var questionToUpdate = _questionService.TGetById(model.Id);

                if (questionToUpdate == null)
                {
                    return NotFound();
                }

                questionToUpdate.QuestionName = model.QuestionName;
                questionToUpdate.ChangedOn = DateTime.Now;

                _questionService.TUpdate(questionToUpdate);

                return RedirectToAction("Index", "Quiz");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult QuestionDelete(int id)
        {
            var question = _questionService.TGetById(id);
            if (question == null)
            {
                return NotFound();
            }

            question.IsDeleted = true;
            question.ChangedOn = DateTime.Now;
            _questionService.TUpdate(question);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuestionPassive(int id)
        {
            var question = _questionService.TGetById(id);
            if (question == null)
            {
                return NotFound();
            }

            question.IsActive = false;
            question.ChangedOn = DateTime.Now;
            _questionService.TUpdate(question);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult QuestionActive(int id)
        {
            var question = _questionService.TGetById(id);
            if (question == null)
            {
                return NotFound();
            }

            question.IsActive = true;
            question.ChangedOn = DateTime.Now;
            _questionService.TUpdate(question);

            return Json(new { success = true });
        }
    }
}
