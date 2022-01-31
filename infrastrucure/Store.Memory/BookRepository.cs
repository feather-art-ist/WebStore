using System.Linq;

namespace WebStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
         new Book(1, "Совершенный код"),
         new Book(2, "Ecma-335"),
         new Book(3, "Ecma-334"),
        };

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart))   
                .ToArray(); //TODO: invariant to UperCase and LowerCase
        }
    }
}