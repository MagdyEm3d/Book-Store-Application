using BookStoreApplication.Models;
using BookStoreApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public ActorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(s => s.AuthorName.Contains(searchString));
            }

            var authorsList = authors.ToList();

            if (!authorsList.Any())
            {
                return View("Error");
            }

            return View(authorsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.CreateAuthorAsync(author);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        public async Task<IActionResult> Edit(int id = 1)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return View("Error");
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                await _authorService.UpdateAuthorAsync(author);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return View("Error");
            return View(author);
        }

        public async Task<IActionResult> Delete(int id = 1)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
                return View("Error");
            await _authorService.DeleteAuthorAsync(id);
            return RedirectToAction("Index");
        }
    }
}
