using BusinessLayer.Abstract;
using EntityLayer.EF;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Controllers
{
    [UyeLoginControl]
    public class StudentController : Controller
    {
        private readonly IQuizUserService _quizUserService;
        private readonly IQuestionService _questionService;

        public StudentController(IQuizUserService quizUserService, IQuestionService questionService)
        {
            _quizUserService = quizUserService;
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var quizUser = _quizUserService.GetQuizByUyeUserId(userId);
            return View(quizUser);
        }

        public IActionResult SuccessQuiz()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            var quizUser = _quizUserService.GetQuizBySuccessUyeUserId(userId);
            return View(quizUser);
        }

        public IActionResult Quiz(int id)
        {
            using (var c = new Context())
            {
                var quiz = c.QuizUser
                    .Include(q => q.Quiz)
                        .ThenInclude(q => q.Question)
                        .ThenInclude(q => q.AnswerValue)
                        .FirstOrDefaultAsync(q => q.Id == id);

                if (quiz == null)
                {
                    return NotFound();
                }

                return View(quiz.Result);
            }
        }

        [HttpPost]
        public ActionResult QuizFinished(QuizUser quizUser, int trueAnswerCount)
        {
            using (var c = new Context())
            {
                var quizQuestionCount = c.Question.Where(q => q.QuizId == quizUser.QuizId).ToList().Count;
                var sonuc = 100 / quizQuestionCount;
                var score = sonuc * trueAnswerCount;
                if (!ModelState.IsValid)
                {
                    var quizUserToUpdate = _quizUserService.TGetById(quizUser.Id);

                    if (quizUserToUpdate == null)
                    {
                        return NotFound();
                    }

                    quizUserToUpdate.UserScore = score;
                    quizUserToUpdate.IsFinished = true;
                    quizUserToUpdate.ChangedOn = DateTime.Now;

                    _quizUserService.TUpdate(quizUserToUpdate);

                    return RedirectToAction("Index", "Student");
                }
            }
            return View(quizUser);
        }
    }
}