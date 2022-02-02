using Xunit;

namespace WebStore.Tests
{
    public class BookTests
    {
        
        [Fact]
        public void IsIsbn_WithBlankStrings_ReturnFalse()
        {
            bool actual = Book.IsIsbn("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBN 123");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithCorrectIsbn_ReturnTrue()
        {
            bool actual = Book.IsIsbn("ISBN 123-233-232-2345");

            Assert.True(actual);
        }
    }
}