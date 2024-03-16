using System;
using System.Data.SqlClient;
using App.Domain.Core.Book.Contract;
using App.Domain.Core.Book.Entity;
using Dapper;

namespace App.Infrastructure.Repository.Dapper
{
	public class BookRepository : IBookRepository
	{

        private readonly string _stringConnection = @"Data Source=127.0.0.1,1433;Initial Catalog=LibraryProject;User ID=sa;Password=user@2023;TrustServerCertificate=True;Encrypt=True";


        public BookRepository()
		{
		}

        public void Add(Book book)
        {
            using SqlConnection connection = new(_stringConnection);

            var q = "INSERT INTO [dbo].[Books] " +
                "(" +
                " [Title],[IsBorrowed] " +
                " ) " +
                "VALUES " +
                " ( " +
                " @Title , @IsBorrowed " +
                " )"
                ;

            CommandDefinition command = new(q, new {Title = book.Title, IsBorrowed = book.IsBorrowed});

            connection.Execute(command);

        }

        public List<Book> AllBooks()
        {
            using SqlConnection cn = new(_stringConnection);

            var sql = $"SELECT * FROM Books";

            CommandDefinition command = new(sql);

            var result = cn.Query<Book>(command).ToList();

            return result;
        }

        public List<Book>? AllUnborrowedBooks()
        {
            using SqlConnection cn = new(_stringConnection);

            var sql = $"SELECT * FROM Books as b\nWHERE b.IsBorrowed = 0 ";

            CommandDefinition command = new(sql);

            var result = cn.Query<Book>(command).ToList();

            return result;

        }


        public void DeleteById(int BookId)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

