using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using System;
using System.Collections.Generic;

namespace BookStore.Data
{
    public class BookContext : IdentityDbContext<ApplicationUser>
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the model if needed
            modelBuilder.Entity<Book>().Property(b => b.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Owner)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.OwnerId);
        }
        /*
        public void SeedData()
        {
            // Add some test books
            var books = new List<Book>
            {
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", Price = 10.99m },
                new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian", Price = 8.99m },
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic", Price = 12.50m },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", Price = 9.75m },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Coming-of-age", Price = 11.25m },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Price = 14.99m },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", Genre = "Science Fiction", Price = 10.25m },
                new Book { Title = "Moby-Dick", Author = "Herman Melville", Genre = "Adventure", Price = 13.49m },
                new Book { Title = "Frankenstein", Author = "Mary Shelley", Genre = "Gothic", Price = 9.99m },
                new Book { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Genre = "Fantasy", Price = 19.99m }
                // Add more books as needed
            };

            // Add books to the context
            foreach (var book in books)
            {
                Books.Add(book);
            }

            SaveChanges();
        }
        */
    }
}
