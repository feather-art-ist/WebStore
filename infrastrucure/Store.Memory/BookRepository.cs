namespace WebStore.Memory
{
    public class BookRepository : IBookRepository
    {
        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Books.Where(book => book.Author.Contains(titleOrAuthor)
                    || book.Title.Contains(titleOrAuthor)).ToArray();
            }

            //TODO: Add check on uppercase and lower
        }


        public Book GetById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Books.Single(book => book.Id == id);
            }
        }

        public Book[] GetByIsbn(string isbn)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Books.Where(book => book.Isbn == isbn).ToArray();
            }
        }
    }
}