using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Core.Admin.Contract;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.Book.Entity;
using App.Domain.Core.User.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Endpoint.MVC.Controllers
{
    public class AdminController : Controller
    {

        private readonly IBookAppService _bookAppService;
        private readonly IUserAppService _userAppService;
        private readonly IAdminAppService _adminAppService;

        public AdminController(IBookAppService bookAppService,
            IUserAppService userAppService, IAdminAppService adminAppService )
        {
            _bookAppService = bookAppService;
            _userAppService = userAppService;
            _adminAppService = adminAppService;
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
            if (ModelState.IsValid)
            {
                _bookAppService.Add(book);
                return RedirectToAction("AllBook");

            }
            return View(book);
        }

        public IActionResult DeleteBook(int id)
        {
            _bookAppService.DeleteById(id);
            return RedirectToAction("AllBook");
        }

        public IActionResult AllocatingBookToUser(int id)
        {
            var book = _bookAppService.GetById(id);
            ViewBag.Users = _userAppService.GetAll();

            return View(book);
        }
        [HttpPost]
        public IActionResult AllocatingBookToUser(Book book)
        {
            var flag = _adminAppService.AllocateBookToUser((int)book.UserId, book.Id);
            if (flag)
                return RedirectToAction("AllBook");

            return View(book);
        }

    }
}

