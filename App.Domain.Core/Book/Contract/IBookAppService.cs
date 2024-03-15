using System;
namespace App.Domain.Core.Book.Contract
{
	public interface IBookAppService
	{
        void Add(Entity.Book book);

        void DeleteById(int BookId);

        List<Entity.Book> AllBooks();

        List<Entity.Book> AllUnborrowedBooks();

        void BorrowBook(int bookId, int userId);

        void ReturnBook(int bookId);
    }
}

