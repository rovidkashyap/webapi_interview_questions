using dependency_injection_in_web_api.Models;

namespace dependency_injection_in_web_api.Interfaces
{
    public class BookService : IBookService
    {
        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", ISBN = "0451524934" },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "0061120081" }
        };

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            return Task.FromResult((IEnumerable<Book>)Books);
        }

        public Task<Book> GetBookAsync(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task<Book> AddBookAsync(Book book)
        {
            book.Id = Books.Max(b => b.Id) + 1;
            Books.Add(book);
            return Task.FromResult(book);
        }

        public Task<bool> UpdateBookAsync(int id, Book book)
        {
            var existingBook = Books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return Task.FromResult(false);
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteBookAsync(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return Task.FromResult(false);
            }

            Books.Remove(book);
            return Task.FromResult(true);
        }
    }
}
