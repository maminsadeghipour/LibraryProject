using App.Domain.Core.Book.Entity;
using App.Domain.Core.Admin.Entity;
using App.Domain.Core.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Database;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1,1433;Initial Catalog=LibraryProject;User ID=sa;Password=user@2023;TrustServerCertificate=True;Encrypt=True");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }


}

