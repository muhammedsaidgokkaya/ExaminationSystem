using BusinessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer.Entity;
using ExaminationSystem.LoginControl;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationSystem.Controllers
{
	[AdminLoginControl]
	public class TeacherController : Controller
    {
		private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;

        public TeacherController(ICategoryService categoryService, IQuizService quizService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
        }

        public IActionResult Index()
        {
			var categories = _categoryService.GetActiveList();
			return View(categories);
		}

		public IActionResult CategoryAdd()
		{
			return View();
		}

		[HttpPost]
        public IActionResult CategoryAdd(Category model)
        {
            if (!ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true,
                };

                _categoryService.TAdd(category);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult CategoryUpdate(int id)
        {
            var category = _categoryService.TGetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category model)
        {
            if (!ModelState.IsValid)
            {
                var categoryToUpdate = _categoryService.TGetById(model.Id);

                if (categoryToUpdate == null)
                {
                    return NotFound();
                }

                categoryToUpdate.CategoryName = model.CategoryName;
                categoryToUpdate.ChangedOn = DateTime.Now;

                _categoryService.TUpdate(categoryToUpdate);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryDelete(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            category.ChangedOn = DateTime.Now;
            _categoryService.TUpdate(category);

            return Json(new { success = true });
        }
        
        [HttpPost]
        public IActionResult CategoryPassive(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsActive = false;
            category.ChangedOn = DateTime.Now;
            _categoryService.TUpdate(category);

            return Json(new { success = true });
        }
        
        [HttpPost]
        public IActionResult CategoryActive(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsActive = true;
            category.ChangedOn = DateTime.Now;
            _categoryService.TUpdate(category);

            return Json(new { success = true });
        }
	}
}
