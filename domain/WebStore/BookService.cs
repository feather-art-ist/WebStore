using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebStore
{
    public class BookService
    {
        private IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (IsIsbn(query))
                return bookRepository.GetByIsbn(query);
           
            return bookRepository.GetAllByTitleOrAuthor(query);
        }

        internal static bool IsIsbn(string isbn)
        {
            if (isbn == null)
            {
                return false;
            }

            isbn = isbn.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(isbn, "^ISBN\\d{13}$");
        }
    }
}
