using System;
using App.Domain.Core.Book.Contract;
using App.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository.Ef.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }

    }
	public class BookRepository : IBookRepository
    {


		private readonly AppDbContext _context = new();

        public BookRepository()
		{
		}

        public void Add(Domain.Core.Book.Entity.Book book)
        {
            try
            {                
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public void DeleteById(int BookId)
        {
            try
            {

                var book = _context.Books.FirstOrDefault(b => b.Id == BookId);

                _context.Books.Remove(book);

                _context.SaveChanges();
            }
            catch(Exception ex) { throw ex; }
        }

        public List<Domain.Core.Book.Entity.Book> AllBooks()
        {
            var q = _context.Books.ToQueryString();

            var  books =  _context.Books.Select(p => new BookDto
            {
                Id = p.Id,
                //Title = p.Title,
                //IsBorrowed = p.IsBorrowed,
                //UserId = p.UserId
                
            }).ToList();

            return _context.Books.ToList();
        }

        public List<Domain.Core.Book.Entity.Book>? AllUnborrowedBooks()
        {
            return _context.Books.Where(b => !b.IsBorrowed).ToList();
        }

        public void Update(Domain.Core.Book.Entity.Book book)
        {
            try
            {

                var oldBook = _context.Books.FirstOrDefault(b => b.Id == book.Id);

                oldBook.IsBorrowed = book.IsBorrowed;

                _context.SaveChanges();
               
            }
            catch (Exception ex) { throw ex; }
        }

        public Domain.Core.Book.Entity.Book GetById(int Id)
        {
            try
            {
                return _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == Id);               
            }
            catch (Exception ex) { throw ex; }
        }


    }
}

