using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public class LibraryService
    {
        private readonly ILibraryDatabase _database;

        public LibraryService(ILibraryDatabase database)
        {
            _database = database;
        }

        public bool BorrowBook(string isbn, User user)
        {
            var book = _database.FindBookByIsbn(isbn);
            if (book == null)
                throw new ArgumentException("Book not found.");

            if (!book.IsAvailable)
                return false;

            book.Borrow();
            return true;
        }

        public bool ReturnBook(string isbn, User user)
        {
            var book = _database.FindBookByIsbn(isbn);
            if (book == null)
                throw new ArgumentException("Book not found.");

            if (book.IsAvailable)
                return false;

            book.Return();
            return true;
        }

        public bool UpdateBookStatus(string isbn, bool isAvailable)
        {
            var book = _database.FindBookByIsbn(isbn);
            if (book == null)
                throw new ArgumentException("Book not found.");

            if (isAvailable)
                book.Return();
            else
                book.Borrow();

            return true;
        }
    }

}
