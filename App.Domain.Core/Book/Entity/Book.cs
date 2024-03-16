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


        public int Id { get; set; }

		[MaxLength(50,ErrorMessage ="Max Length 50")]
		[Required]
		public string Title { get; set; }

		public bool IsBorrowed { get; set; }

		public int? UserId { get; set; }

		public User.Entity.User? User { get; set; }
	}
}

