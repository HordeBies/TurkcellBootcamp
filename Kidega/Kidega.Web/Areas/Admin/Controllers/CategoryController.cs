using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController(ICategoryService categoryService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
            if (ModelState.IsValid)
            {
                await categoryService.CreateCategoryAsync(request);
                TempData["success"] = "Category created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var model = mapper.Map<CategoryUpdateRequest>(await categoryService.GetCategoryAsync(id.Value));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategoryAsync(request);
                TempData["success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await categoryService.DeleteCategoryAsync(id.Value);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> GetAll() // For Datatable ajax call
        {
            return Json(new { data = await categoryService.GetAllCategoriesAsync() });
        }
    }
}
