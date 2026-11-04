using Microsoft.EntityFrameworkCore;

namespace BookSite.Data;
public class BookSiteDbContext : DbContext {
        public BookSiteDbContext(DbContextOptions<BookSiteDbContext> options) : base(options) { }

        public virtual DbSet<Book> Books { get; set; }
    }
