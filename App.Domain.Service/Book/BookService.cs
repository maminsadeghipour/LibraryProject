using System;
using App.Domain.Core.Admin.Contract;
using App.Domain.Core.Book.Contract;

namespace App.Domain.Service.Book
{
	public class BookService : IBookService
	{
        private readonly IBookRepository _bookRepository;

        


        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Core.Book.Entity.Book GetById(int Id)
        {
            return _bookRepository.GetById(Id);
        }
        
        public void Add(Core.Book.Entity.Book book)
        {
            _bookRepository.Add(book);
        }


        public void DeleteById(int BookId)
        {
            _bookRepository.DeleteById(BookId);
        }


        public List<Core.Book.Entity.Book> AllBooks()
        {
            return _bookRepository.AllBooks();
        }

        public List<Core.Book.Entity.Book> AllUnborrowedBooks()
        {
            return _bookRepository.AllUnborrowedBooks();
        }

        public void BorrowBook(int bookId, int userId)
        {
            var book = _bookRepository.GetById(bookId);
            book.IsBorrowed = true;
            book.UserId = userId;
            _bookRepository.Update(book);

        }

        public void ReturnBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            book.IsBorrowed = false;
            book.UserId = null;
            _bookRepository.Update(book);
        }

        public void Update(Core.Book.Entity.Book book)
        {
            _bookRepository.Update(book);
        }
    }
}

