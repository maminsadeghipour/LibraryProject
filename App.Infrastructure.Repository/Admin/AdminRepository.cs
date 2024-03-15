using System;
using App.Domain.Core.Admin.Contract;
using App.Infrastructure.Database;

namespace App.Infrastructure.Repository.Ef.Admin
{
	public class AdminRepository : IAdminRepository
    {

		private readonly AppDbContext _context = new();

		public AdminRepository()
		{
		}
	}
}

