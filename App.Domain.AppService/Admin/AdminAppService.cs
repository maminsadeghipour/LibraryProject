using System;
using App.Domain.Core.Admin.Contract;
using App.Domain.Core.Book.Contract;

namespace App.Domain.AppService.Admin
{
	public class AdminAppService : IAdminAppService
	{
		private readonly IAdminService _adminService;
        private readonly IBookService _bookService;

        public AdminAppService(IAdminService adminService, IBookService bookService)
		{
			_adminService = adminService;
            _bookService = bookService;
        }


        public bool AllocateBookToUser(int userId, int BookId)
        {
            var book = _bookService.GetById(BookId);

            if (!book.IsBorrowed)
            {
                book.IsBorrowed = true;
                book.UserId = userId;
                _bookService.Update(book);

                return true;
            }

            return false;
        }
    }
}

