using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.Book.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Endpoint.MVC.Controllers
{
    public class AdminController : Controller
    {

        private readonly IBookAppService _bookAppService;

        public AdminController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllBook()
        {
            var books = _bookAppService.AllBooks();
            return View(books);
        }


        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookAppService.Add(book);
            return View();
        }

        public IActionResult DeleteBook(int id)
        {
            _bookAppService.DeleteById(id);
            return View();
        }

    }
}

