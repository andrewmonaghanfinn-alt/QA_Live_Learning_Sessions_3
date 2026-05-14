using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
    public class Book
    {
        public string Title { get; }
        public string Isbn { get; }
        public bool IsAvailable { get; private set; }

        public Book(string title, string isbn)
        {
            Title = title;
            Isbn = isbn;
            IsAvailable = true;
        }

        public void Borrow()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Book is already on loan.");

            IsAvailable = false;
        }

        public void Return()
        {
            if (IsAvailable)
                throw new InvalidOperationException("Book was not on loan.");

            IsAvailable = true;
        }
    }

}
