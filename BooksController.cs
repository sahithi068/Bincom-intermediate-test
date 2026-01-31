using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            return book;
        }

        // POST: api/Books
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize]
        [HttpGet("grouped-by-author")]
        public IActionResult GetBooksGroupedByAuthor()
        {
            var result = _context.Books
                .GroupBy(b => b.Author)
                .Select(g => new
                {
                    Author = g.Key,
                    Books = g.Select(b => new
                    {
                        b.Title,
                        b.ISBN,
                        b.CopiesAvailable
                    })
                })
                .ToList();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("top-borrowed")]
        public IActionResult GetTopBorrowedBooks()
        {
            var result = _context.Books
                .OrderByDescending(b => b.BorrowCount)
                .Take(3)
                .Select(b => new
                {
                    b.Title,
                    b.Author,
                    b.BorrowCount
                })
                .ToList();

            return Ok(result);
        }

        // GET: api/Books/external/{id}
        [HttpGet("external/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBookFromExternalApi(int id)
        {
            // Simulate external API delay
            await Task.Delay(1500);

            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound("Book not found from external source");

            return Ok(new
            {
                Source = "External API (simulated)",
                book.Id,
                book.Title,
                book.Author,
                book.ISBN,
                book.CopiesAvailable
            });
        }

    }
}
