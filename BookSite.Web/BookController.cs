using BookSite.Data;
using BookSite.Services;
using Microsoft.AspNetCore.Mvc;


namespace BookSite.Web;

[ApiController]
public class BooksController : ControllerBase {

    private readonly ILogger<BooksController> _logger;
    private readonly IBookService _bookService;

    public BooksController(ILogger<BooksController> logger, IBookService bookService) {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet("/api/books")]
    public async Task<ActionResult> GetBooksAsync() {
        var books = await _bookService.GetAllBooks();
        return Ok(books);
    }


    [HttpGet("/api/books/{id}")]
    public async Task<ActionResult> GetBook(int id)
    {
        var book = await _bookService.GetBook(id);

        return Ok(book);
    }

    [HttpPost("/api/books")]
    public async Task<ActionResult> CreateBookAsync([FromBody] NewBookRequest bookRequest) {
        if(!ModelState.IsValid)
        {
            return BadRequest("ModelState is not valid");
        }
        var now = DateTime.UtcNow;

        var book = new Book {
            CreatedOn = now,
            UpdatedOn = now,
            Title = bookRequest.Title ?? "Unknown Title",
            Author = bookRequest.Author ?? "Unknown Author"
        };

        var addedBook = await _bookService.AddBook(book);

        return Ok(addedBook);
    }


    [HttpDelete("/api/books/{id}")]
    public async Task<ActionResult> DeleteBookAsync(int id)
    {
        await _bookService.DeleteBook(id);

        return Ok($"Book deleted with id: {id}");
    }
}
