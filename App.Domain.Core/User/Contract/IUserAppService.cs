using System;
namespace App.Domain.Core.User.Contract
{
	public interface IUserAppService
	{
        List<Book.Entity.Book>? GetListOfUserBook(int userId);
    }
}

