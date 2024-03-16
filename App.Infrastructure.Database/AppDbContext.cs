using App.Domain.Core.Book.Entity;
using App.Domain.Core.Admin.Entity;
using App.Domain.Core.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1,1433;Initial Catalog=LibraryProject;User ID=sa;Password=user@2023;TrustServerCertificate=True;Encrypt=True");
    //    base.OnConfiguring(optionsBuilder);
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
        .HasOne(b => b.User)
        .WithMany(u => u.BorrowedBook)
        .HasForeignKey(b => b.UserId)
        .OnDelete(DeleteBehavior.SetNull).IsRequired(false); // تنظیم حذف برای آنکه کتاب‌ها با تغییر درجه اولیه کاربران حذف نشوند

        modelBuilder.Entity<User>()
            .HasMany(u => u.BorrowedBook)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfiguration(new BookConfiguration());
    //    base.OnModelCreating(modelBuilder);
    //}

    public DbSet<Book> Books { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }


}

