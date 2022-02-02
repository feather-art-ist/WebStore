namespace WebStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Code Complete", "Steve McConnell", "ISBN 123-123-123-1234",
                "Widely considered one of the best practical guides to programming, " +
                "Steve McConnell’s original code complete has been helping " +
                "developers write better software for more than a decade. " +
                "Now this classic book has been fully updated and revised" +
                " with leading-edge practices—and" +
                " hundreds of new code samples—illustrating the art and science of " +
                "software construction.", 5m),

            new Book(2, "Ecma-335", "Anders Helsberg", "ISBN 123-123-123-1345",
                "This Standard defines the Common Language Infrastructure " +
                "(CLI) in which applications written in multiple high-level " +
                "languages can be executed in different system environments" +
                " without the need to rewrite " +
                "those applications to take into consideration the unique" +
                " characteristics of those environments", 10m),

            new Book(3, "Ecma-334", "Anders Helsberg", "ISBN 123-123-123-1456",
                "This specification describes the form and establishes the interpretation " +
                "of programs written in the C# programming language.", 12m)

        };


        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            if(titleOrAuthor == "all books")
            {
                return books;
            }

            return books.Where(book => book.Author.Contains(titleOrAuthor)
                    || book.Title.Contains(titleOrAuthor)).ToArray();

            //TODO: Add check on uppercase and lower
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
    }
}