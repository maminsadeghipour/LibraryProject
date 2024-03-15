using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Book.Entity
{
	public class Book
	{
		public Book()
		{
		}

        [Key]
        public int Id { get; set; }

		public string Title { get; set; }

		public bool IsBorrowed { get; set; }

		[ForeignKey("User")]
		public int? UserId { get; set; }

		public User.Entity.User User { get; set; }
	}
}

