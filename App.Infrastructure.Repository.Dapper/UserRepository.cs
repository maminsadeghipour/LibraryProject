using System;
using System.Data.SqlClient;
using App.Domain.Core.Book.Entity;
using App.Domain.Core.User.Contract;
using App.Domain.Core.User.Entity;
using Dapper;

namespace App.Infrastructure.Repository.Dapper
{
	public class UserRepository : IUserRepository
	{
        private readonly string _stringConnection = @"Data Source=127.0.0.1,1433;Initial Catalog=LibraryProject;User ID=sa;Password=user@2023;TrustServerCertificate=True;Encrypt=True";

        public UserRepository()
		{
		}

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Book>? GetListOfUserBook(int userId)
        {
            using SqlConnection cn = new(_stringConnection);

            var sql = $"SELECT * FROM Users as u " +
                $"LEFT JOIN Books as b ON u.Id = b.UserId " +
                $"WHERE u.Id = @Id ";

            CommandDefinition command = new(sql, new {Id = userId});

            var result = cn.Query<Book>(command).ToList();
            

            return result;
        }
    }
}

