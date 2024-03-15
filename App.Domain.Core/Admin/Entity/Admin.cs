using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Admin.Entity
{
	public class Admin
	{
		public Admin()
		{
		}

		[Key]
		public int Id { get; set; }

		public string Username { get; set; }
		public string Password { get; set; }
	}
}

