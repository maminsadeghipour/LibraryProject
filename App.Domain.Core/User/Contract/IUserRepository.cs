using System;
namespace App.Domain.Core.User.Contract
{
	public interface IUserRepository
	{
		List<Book.Entity.Book>? GetListOfUserBook(int userId);

        List<Entity.User> GetAll();
    }
}

