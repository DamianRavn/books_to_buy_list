using System;
using System.Collections.Generic;
using System.Linq;
using BookSite.Data;

namespace BookSite.Services;
public class BookService : IBookService
{
    private readonly BookSiteDbContext _db;

    public BookService(BookSiteDbContext db)
    {
        _db = db;
    }


    public async Task<List<Book>> GetAllBooks()
    {
        return await Task.Run(() => _db.Books.ToList());
    }

    public async Task<Book> GetBook(int bookId)
    {
        return await _db.Books.FindAsync(bookId);
    }

    public async Task<Book> AddBook(Book book)
    {
        var addedBook = await _db.AddAsync(book);
        await _db.SaveChangesAsync();

        return addedBook.Entity;
    }

    public async Task DeleteBook(int bookId)
    {
        var bookToDelete = await _db.Books.FindAsync(bookId);
        if (bookToDelete != null)
        {
            _db.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException(
                    "Can't delete book that doesn't exist"
                );
        }
    }
}
