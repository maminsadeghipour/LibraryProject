using System;
namespace App.Domain.Core.Book.Contract
{
	public interface IBookService
	{

        public Core.Book.Entity.Book GetById(int Id);

        void Add(Entity.Book book);

        void DeleteById(int BookId);

        List<Entity.Book> AllBooks();

        List<Entity.Book> AllUnborrowedBooks();

        void BorrowBook(int bookId, int userId);

        void ReturnBook(int bookId);

        void Update(Entity.Book book);
    }
}

