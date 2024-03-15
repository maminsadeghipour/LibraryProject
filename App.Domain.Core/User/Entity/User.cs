using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.User.Entity
{
	public class User
	{
		public User()
		{
		}

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public List<Book.Entity.Book>? BorrowedBook { get; set; } = new();
    }

}

