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
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book (1, "", "", "")});

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);

            var validIsbn = "ISBN 123-123-123-1234";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WidthAuthorOrTitle_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();

            bookRepositoryStub.Setup(x => x.GetByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositoryStub.Object);

            var validAuthor = "Anders";

            var actual = bookService.GetAllByQuery(validAuthor);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
