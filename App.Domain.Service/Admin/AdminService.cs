using System;
using App.Domain.Core.Admin.Contract;

namespace App.Domain.Service.Admin
{
	public class AdminService : IAdminService
	{

		private readonly IAdminRepository _adminRepository;

		public AdminService(IAdminRepository adminRepository)
		{
			_adminRepository = adminRepository;
		}
	}
}

