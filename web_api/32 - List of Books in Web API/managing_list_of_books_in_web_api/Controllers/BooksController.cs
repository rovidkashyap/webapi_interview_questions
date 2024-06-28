using managing_list_of_books_in_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managing_list_of_books_in_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", ISBN = "0451524934" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "0061120081" }
        };

        // GET: api/Books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(Books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var books = Books.FirstOrDefault(b => b.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            book.Id = Books.Max(b => b.Id) + 1;
            Books.Add(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api//Books/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;

            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            Books.Remove(book);

            return NoContent();
        }
    }
}
