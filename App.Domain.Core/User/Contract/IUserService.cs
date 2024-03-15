using System;
namespace App.Domain.Core.User.Contract
{
	public interface IUserService
	{
        List<Book.Entity.Book>? GetListOfUserBook(int userId);
    }
}

