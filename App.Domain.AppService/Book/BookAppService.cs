using System;
using App.Domain.Core.Admin.Contract;
using App.Domain.Core.Book.Contract;

namespace App.Domain.AppService.Book
{
	public class BookAppService : IBookAppService
	{
        private readonly IBookService _bookService;

        public BookAppService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void Add(Core.Book.Entity.Book book)
        {
            _bookService.Add(book);
        }

        public void DeleteById(int BookId)
        {
            _bookService.DeleteById(BookId);
        }


        public List<Core.Book.Entity.Book> AllBooks()
        {
            return _bookService.AllBooks();
        }

        public List<Core.Book.Entity.Book> AllUnborrowedBooks()
        {
            return _bookService.AllUnborrowedBooks();
        }

        public void BorrowBook(int bookId, int userId)
        {
            _bookService.BorrowBook(bookId,userId);
        }

        public void ReturnBook(int bookId)
        {
            _bookService.ReturnBook(bookId);
        }

        public Core.Book.Entity.Book GetById(int Id)
        {
            return _bookService.GetById(Id);
        }
    }
}

