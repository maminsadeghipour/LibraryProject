using System;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.User.Contract;

namespace App.Domain.AppService.User
{
	public class UserAppService : IUserAppService
	{
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public List<Core.User.Entity.User> GetAll()
        {
            return _userService.GetAll();
        }

        public List<Core.Book.Entity.Book>? GetListOfUserBook(int userId)
        {
            return _userService.GetListOfUserBook(userId);
        }
    }
}

