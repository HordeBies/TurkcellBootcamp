using Kidega.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Kidega.Infrastructure.DatabaseContexts
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Classic Literature" },
                new Category { Id = 2, Name = "Adventure" },
                new Category { Id = 3, Name = "Tragedy" },
                new Category { Id = 4, Name = "Gothic Fiction" },
                new Category { Id = 5, Name = "American Literature" },
                new Category { Id = 6, Name = "Historical Fiction" },
                new Category { Id = 7, Name = "Fantasy" },
                new Category { Id = 8, Name = "Dystopian" },
                new Category { Id = 9, Name = "Coming of Age" },
                new Category { Id = 10, Name = "Russian Literature" }
            );
            // Seed Authors
            builder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Jane Austen" },
                new Author { Id = 2, Name = "Mark Twain" },
                new Author { Id = 3, Name = "William Shakespeare" },
                new Author { Id = 4, Name = "Charlotte Bronte" },
                new Author { Id = 5, Name = "F. Scott Fitzgerald" },
                new Author { Id = 6, Name = "Charles Dickens" },
                new Author { Id = 7, Name = "J.R.R. Tolkien" },
                new Author { Id = 8, Name = "George Orwell" },
                new Author { Id = 9, Name = "Harper Lee" },
                new Author { Id = 10, Name = "Leo Tolstoy" }
            );

            // Seed Books
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Pride and Prejudice", Price = 19.99m, CategoryId = 1, AuthorId = 1 },
                new Book { Id = 2, Title = "Adventures of Huckleberry Finn", Price = 14.99m, CategoryId = 2, AuthorId = 2 },
                new Book { Id = 3, Title = "Romeo and Juliet", Price = 9.99m, CategoryId = 3, AuthorId = 3 },
                new Book { Id = 4, Title = "Jane Eyre", Price = 24.99m, CategoryId = 4, AuthorId = 4 },
                new Book { Id = 5, Title = "The Great Gatsby", Price = 12.99m, CategoryId = 5, AuthorId = 5 },
                new Book { Id = 6, Title = "A Tale of Two Cities", Price = 29.99m, CategoryId = 6, AuthorId = 6 },
                new Book { Id = 7, Title = "The Lord of the Rings", Price = 16.99m, CategoryId = 7, AuthorId = 7 },
                new Book { Id = 8, Title = "1984", Price = 11.99m, CategoryId = 8, AuthorId = 8 },
                new Book { Id = 9, Title = "To Kill a Mockingbird", Price = 21.99m, CategoryId = 9, AuthorId = 9 },
                new Book { Id = 10, Title = "War and Peace", Price = 17.99m, CategoryId = 10, AuthorId = 10 }
            );

        }
    }
}