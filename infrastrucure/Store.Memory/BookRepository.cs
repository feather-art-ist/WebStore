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
            return books.Where(book => book.Author.Contains(titleOrAuthor)
                    || book.Title.Contains(titleOrAuthor)).ToArray();

            //TODO: Add check on uppercase and lower
        }

        public Book[] GetByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
    }
}