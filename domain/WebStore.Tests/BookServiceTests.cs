using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebStore.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WidthIsbn_CallsGetByIsbn()
        {
            const int ID_FOR_ISBN_BOOK = 1;
            const int ID_FOR_TITLE_OR_AUTHOR_BOOK = 2;

            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book (ID_FOR_ISBN_BOOK, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(ID_FOR_TITLE_OR_AUTHOR_BOOK, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);

            var validIsbn = "ISBN 123-123-123-1234";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(ID_FOR_ISBN_BOOK , book.Id));
        }

        [Fact]
        public void GetAllByQuery_WidthAuthorOrTitle_CallsGetAllByTitleOrAuthor()
        {
            const int ID_FOR_ISBN_BOOK = 1;
            const int ID_FOR_TITLE_OR_AUTHOR_BOOK = 2;

            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(ID_FOR_ISBN_BOOK, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(ID_FOR_TITLE_OR_AUTHOR_BOOK, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);

            var validAuthor = "Anders";

            var actual = bookService.GetAllByQuery(validAuthor);

            Assert.Collection(actual, book => Assert.Equal(ID_FOR_TITLE_OR_AUTHOR_BOOK, book.Id));
        }
    }
}
