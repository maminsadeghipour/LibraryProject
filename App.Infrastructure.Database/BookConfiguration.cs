using System;
using App.Domain.Core.Book.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Database
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
		public BookConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.UserId).IsRequired(false);


            builder.HasOne(p => p.User)
                .WithMany(p => p.BorrowedBook)
                .HasForeignKey(p => p.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

