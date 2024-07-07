using BookStoreApplication.Data;
using BookStoreApplication.Models;
using BookStoreApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(string searchString, Genre? genre)
        {
            var books = await _bookService.GetAllBooksAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookTitle.Contains(searchString));
            }

            if (genre.HasValue)
            {
                books = books.Where(x => x.BookGenre == genre);
            }

            var booksList = books.ToList();

            if (!booksList.Any())
            {
                return View("Error");
            }

            return View(booksList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBookAsync(book);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        public async Task<IActionResult> Edit(int id = 1)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return View("Error");
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(book);
                return RedirectToAction("Index");
            }
            return View("Error");
        }

        public async Task<IActionResult> Details(int id = 1)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return View("Error");
            return View(book);
        }

        public async Task<IActionResult> Delete(int id = 1)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return View("Error");
            await _bookService.DeleteBookAsync(id);
            return RedirectToAction("Index");
        }
    }
}
