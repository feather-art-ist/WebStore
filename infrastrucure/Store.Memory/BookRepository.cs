namespace WebStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
         new Book(1, "Совершенный код", "Стив Макконнелл", "ISBN 123-123-123-1234"),
         new Book(2, "Ecma-335", "Anders Helsberg", "ISBN 123-123-123-1345"),
         new Book(3, "Ecma-334", "Anders Helsberg", "ISBN 123-123-123-1456"),
        };


        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            throw new NotImplementedException();

            //Hack: end a logic
        }

        public Book[] GetByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn.Contains(isbn)).ToArray();

            //TODO: invariant to UperCase and LowerCase
        }
    }
}