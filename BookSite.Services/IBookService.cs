using BookSite.Data;

namespace BookSite.Services
{
    public interface IBookService
    {
		public Task<List<Book>> GetAllBooks();
        public Task<Book> GetBook(int bookId);
        public Task<Book> AddBook(Book book);
        public Task DeleteBook(int bookId);
    }
}
