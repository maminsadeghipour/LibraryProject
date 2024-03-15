using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.User.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Endpoint.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly int onlineUserId = 1;
        private readonly IBookAppService _bookAppService;
        private readonly IUserAppService _userAppService;

        public UserController(IBookAppService bookAppService, IUserAppService userAppService)
        {
            _bookAppService = bookAppService;
            _userAppService = userAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllBooks()
        {
            var books = _bookAppService.AllUnborrowedBooks();
            return View(books);
        }

        public IActionResult UserBooks()
        {
            var userBooks = _userAppService.GetListOfUserBook(onlineUserId);
            return View(userBooks);

        }

        public IActionResult BorrowBook(int id)
        {
            _bookAppService.BorrowBook(id,onlineUserId);
            return RedirectToAction("AllBooks");

        }

        public IActionResult ReturnBook(int id)
        {
            _bookAppService.ReturnBook(id);
            return RedirectToAction("AllBooks");

        }
    }
}

