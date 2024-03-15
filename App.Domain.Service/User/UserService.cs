using System;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.User.Contract;

namespace App.Domain.Service.User
{
	public class UserService : IUserService
	{
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Core.Book.Entity.Book>? GetListOfUserBook(int userId)
        {
            return _userRepository.GetListOfUserBook(userId);
        }
    }
}

