using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BookController : ControllerBase
{

    [HttpGet("api/books")]
    public IActionResult GetBooks()
    {
        return Ok("Books!");
    }
}
