using System.Text.RegularExpressions;

namespace WebStore;
public class Book
{
    public int Id { get; }

    public string Title { get; }

    public string Author { get; }

    public string Description { get; }

    public decimal Price { get; }

    public string Isbn { get; }

    public Book(int id, string title, string author, string isbn, string description, decimal price)
    {
        Id = id;
        Title = title;
        Author = author;
        Isbn = isbn;
        Description = description;
        Price = price;
    }

    internal static bool IsIsbn(string isbn)
    {
        if(isbn == null)
        {
            return false;
        }

        isbn = isbn.Replace("-", "")
            .Replace(" ", "")
            .ToUpper();

        return Regex.IsMatch(isbn, "^ISBN\\d{13}$");
    }
}
