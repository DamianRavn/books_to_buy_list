using System;
using System.Collections.Generic;
using System.Linq;
using BookSite.Data;

namespace BookSite.Services;
public class BookService : IBookService {
        private readonly BookSiteDbContext _db;

        public BookService(BookSiteDbContext db) {
            _db = db;
        }

        public List<Book> GetAllBooks() {
            return _db.Books.ToList();
        }

        public Book GetBook(int bookId) {
            return _db.Books.Find(bookId);
        }

        public void AddBook(Book book) {
            _db.Add(book);
            _db.SaveChanges();
        }

        public void DeleteBook(int bookId) {
            var bookToDelete = _db.Books.Find(bookId);
            if (bookToDelete != null) {
                _db.Remove(bookToDelete);
            }

                throw new InvalidOperationException(
                    "Can't delete book that doesn't exist"
                );
        }
    }
