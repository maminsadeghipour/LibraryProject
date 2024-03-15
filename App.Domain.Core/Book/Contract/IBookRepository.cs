using System;
using App.Domain.Core.Book.Entity;
namespace App.Domain.Core.Book.Contract
{
	public interface IBookRepository
	{

		void Add(Entity.Book book);

		void DeleteById(int BookId);

		List<Entity.Book> AllBooks();

        List<Entity.Book>? AllUnborrowedBooks();

		void Update(Entity.Book book);

		Entity.Book GetById(int Id);
    }

}

