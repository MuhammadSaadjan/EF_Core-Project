using EF_Core_DataAccess.Data;
using EF_Core_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new())
//{ 
//context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0)
//    { 
//        context.Database.Migrate();
//    }
//}

//GetAllBooks();

//GetBook();

//UpdateBook();

DeleteBook();

void DeleteBook()
{
    using var context = new ApplicationDbContext();
    var book = context.Books.Find(7);
        context.Books.Remove(book);
    context.SaveChanges();
}


//AddBooks();
void GetAllBooks ()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach (var book in books)
    { 
        Console.WriteLine(book.Title+ " "+ book.ISBN);
    }
}

void  GetBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        //var book = context.Books.FirstOrDefault(u => u.Title == "The Da Vinci Code"); 
        //var books = context.Books.Where(u => u.ISBN.Contains("123"));
        //var books = context.Books.Where(u => EF.Functions.Like(u.ISBN, "12%"));
        //var book = context.Books.Find(1); 
        //Console.WriteLine(book.Title + " " + book.ISBN);

        //var books = context.Books.Where(u=>u.Price>10).OrderBy(u=>u.Title).ThenByDescending(u=>u.ISBN);

        var books = context.Books.Skip(0).Take(2);

        foreach (var book in books)
        {
            Console.WriteLine(book.Title + " " + book.ISBN);
        }

        books = context.Books.Skip(4).Take(1);

        foreach (var book in books)
        {
            Console.WriteLine(book.Title + " " + book.ISBN);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException?.Message);
    }

}

void UpdateBook()
{
    try
    {
        using var context = new ApplicationDbContext();
        var books = context.Books.Find(3);
        books.ISBN = "123B12-Updated";
        context.SaveChanges();
    }

    catch (Exception e) 
    {
    
    }
}

void AddBooks()
{
    Book book = new() { Title = "New Ef Core Book", ISBN = "999", Price = 10.93m, Publisher_Id = 1 };
    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}