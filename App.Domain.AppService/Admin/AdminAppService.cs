using System;
using App.Domain.Core.Admin.Contract;

namespace App.Domain.AppService.Admin
{
	public class AdminAppService : IAdminAppService
	{
		private readonly IAdminService _adminService;

		public AdminAppService(IAdminService adminService)
		{
			_adminService = adminService;
		}
	}
}

