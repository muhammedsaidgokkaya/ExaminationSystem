using BusinessLayer.Abstract;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
    [AdminLoginControl]
    public class AnswerValueController : Controller
    {
        private readonly IAnswerValueService _answerValueService;

        public AnswerValueController(IAnswerValueService answerValueService)
        {
            _answerValueService = answerValueService;
        }

        public IActionResult Index(int id)
        {
            var answerValue = _answerValueService.GetAnswerValuesByQuestionId(id);
            return View(answerValue);
        }

        public IActionResult AnswerValue(int id)
        {
            var model = new AnswerValue
            {
                QuestionId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AnswerValueAdd(AnswerValue model)
        {
            if (!ModelState.IsValid)
            {
                var answerValue = new AnswerValue
                {
                    ValueName = model.ValueName,
                    IsTrue = model.IsTrue,
                    QuestionId = model.QuestionId,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                };

                _answerValueService.TAdd(answerValue);
                return RedirectToAction("Index", "Quiz");
            }

            return View(model);
        }

        public IActionResult AnswerValueUpdate(int id)
        {
            var answerValue = _answerValueService.TGetById(id);

            if (answerValue == null)
            {
                return NotFound();
            }

            return View(answerValue);
        }

        [HttpPost]
        public IActionResult AnswerValueUpdate(AnswerValue model)
        {
            if (!ModelState.IsValid)
            {
                var answerValueToUpdate = _answerValueService.TGetById(model.Id);

                if (answerValueToUpdate == null)
                {
                    return NotFound();
                }

                answerValueToUpdate.ValueName = model.ValueName;
                answerValueToUpdate.ChangedOn = DateTime.Now;

                _answerValueService.TUpdate(answerValueToUpdate);

                return RedirectToAction("Index", "Quiz");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AnswerValueDelete(int id)
        {
            var answerValue = _answerValueService.TGetById(id);
            if (answerValue == null)
            {
                return NotFound();
            }

            answerValue.IsDeleted = true;
            answerValue.ChangedOn = DateTime.Now;
            _answerValueService.TUpdate(answerValue);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AnswerValuePassive(int id)
        {
            var answerValue = _answerValueService.TGetById(id);
            if (answerValue == null)
            {
                return NotFound();
            }

            answerValue.IsActive = false;
            answerValue.ChangedOn = DateTime.Now;
            _answerValueService.TUpdate(answerValue);

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult AnswerValueActive(int id)
        {
            var answerValue = _answerValueService.TGetById(id);
            if (answerValue == null)
            {
                return NotFound();
            }

            answerValue.IsActive = true;
            answerValue.ChangedOn = DateTime.Now;
            _answerValueService.TUpdate(answerValue);

            return Json(new { success = true });
        }
    }
}
