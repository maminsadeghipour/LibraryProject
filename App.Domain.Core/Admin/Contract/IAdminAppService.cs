using System;
namespace App.Domain.Core.Admin.Contract
{
	public interface IAdminAppService
	{
        public bool AllocateBookToUser(int userId, int BookId);
    }
}

