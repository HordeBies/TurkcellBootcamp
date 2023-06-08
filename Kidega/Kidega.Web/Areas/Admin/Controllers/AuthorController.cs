using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AuthorController(IAuthorService authorService, IMapper mapper) : Controller
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
        public async Task<IActionResult> Create(AuthorAddRequest request)
        {
            if (ModelState.IsValid)
            {
                await authorService.CreateAuthorAsync(request);
                TempData["success"] = "Author added successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var model = mapper.Map<AuthorUpdateRequest>(await authorService.GetAuthorAsync(id.Value));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                await authorService.UpdateAuthorAsync(request);
                TempData["success"] = "Author updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await authorService.DeleteAuthorAsync(id.Value);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> GetAll() // For Datatable ajax call
        {
            return Json(new { data = await authorService.GetAllAuthorsAsync() });
        }
    }
}
