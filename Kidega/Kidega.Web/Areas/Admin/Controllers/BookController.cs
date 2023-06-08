using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Core.Services;
using Kidega.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kidega.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [NonAction]
        private async Task<BookCreateVM> GetBookCreateVM(BookAddRequest data)
        {
            var authors = await authorService.GetAllAuthorsAsync();
            var categories = await categoryService.GetAllCategoriesAsync();
            return new BookCreateVM
            {
                Book = data,
                AuthorList = authors.Select(author => new SelectListItem
                {
                    Text = author.Name,
                    Value = author.Id.ToString()
                }),
                CategoryList = categories.Select(category => new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                })
            };
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await GetBookCreateVM(new());
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM request)
        {
            if (ModelState.IsValid)
            {
                await bookService.CreateBookAsync(request.Book);
                TempData["success"] = "Book added successfully";
                return RedirectToAction(nameof(Index));
            }
            var model = await GetBookCreateVM(request.Book);
            return View(model);
        }
        [NonAction]
        private async Task<BookUpdateVM> GetBookUpdateVM(BookUpdateRequest data)
        {
            var authors = await authorService.GetAllAuthorsAsync();
            var categories = await categoryService.GetAllCategoriesAsync();
            return new BookUpdateVM
            {
                Book = data,
                AuthorList = authors.Select(author => new SelectListItem
                {
                    Text = author.Name,
                    Value = author.Id.ToString()
                }),
                CategoryList = categories.Select(category => new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                })
            };
        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var data = mapper.Map<BookUpdateRequest>(await bookService.GetBookAsync(id.Value));
            var model = await GetBookUpdateVM(data);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(BookUpdateVM request)
        {
            if (ModelState.IsValid)
            {
                await bookService.UpdateBookAsync(request.Book);
                TempData["success"] = "Book updated successfully";
                return RedirectToAction(nameof(Index));
            }
            var model = await GetBookUpdateVM(request.Book);
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await bookService.DeleteBookAsync(id.Value);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> GetAll() // For Datatable ajax call
        {
            return Json(new { data = await bookService.GetAllBooksAsync() });
        }
    }
}
