using System.Collections.Generic;

namespace LibraryService
{

    public class LibraryDatabaseStub : ILibraryDatabase
    {
        private readonly Dictionary<string, Book> _books = new Dictionary<string, Book>();

        public void AddBook(Book book)
        {
            _books[book.Isbn] = book;
        }

        public Book FindBookByIsbn(string isbn)
        {
            _books.TryGetValue(isbn, out var book);
            return book;
        }
    }

}
