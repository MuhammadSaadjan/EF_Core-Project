using EF_Core_DataAccess.FluentConfig;
using EF_Core_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_DataAccess.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories{ get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }

        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }



        //rename to Fluent_BookDetail
        public DbSet<Fluent_BookDetail> BookDetail_Fluent { get; set; }

        public DbSet<Fluent_Book> Fluent_Book { get; set; }

        public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }

        public DbSet<Fluent_Author> Fluent_Author{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
            options.UseSqlServer("Server=SAAD-DESKTOP\\SQLEXPRESS; Database=Bookstore; Trusted_Connection=true; TrustServerCertificate=true;").LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name}, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());



            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { Book_Id=1, Title="Spider without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id = 1 },
                new Book { Book_Id = 2, Title = "Fortune of Time", ISBN = "12123B12", Price = 11.99m, Publisher_Id = 1 }
                );
            var bookList = new Book[]
                {
                    new Book { Book_Id=3, Title="The Lost Symbol", ISBN = "123B12", Price = 10.99m, Publisher_Id = 2}, 
                    new Book { Book_Id=4, Title="The Da Vinci Code", ISBN = "123B13", Price = 12.99m, Publisher_Id = 3 },
                    new Book { Book_Id=5, Title="The Harriet Beecher Stowe Chronicles", ISBN = "123B14", Price = 13.99m, Publisher_Id = 3 }
                };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData
                (
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
                ); 
        }
    }
}
