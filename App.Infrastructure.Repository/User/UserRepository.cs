using System;
using App.Domain.Core.User.Contract;
using App.Infrastructure.Database;

namespace App.Infrastructure.Repository.Ef.User
{
	public class UserRepository : IUserRepository
	{
        
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
		{
            _context = context;
		}

        public List<Domain.Core.User.Entity.User> GetAll()
        {
            return _context.Users.ToList();
        }

        public List<Domain.Core.Book.Entity.Book>? GetListOfUserBook(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).Select(u => u.BorrowedBook)
                .FirstOrDefault();           
        }
    }
}

