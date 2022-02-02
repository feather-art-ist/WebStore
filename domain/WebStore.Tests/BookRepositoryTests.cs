using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Memory;
using Xunit;

namespace WebStore.Tests
{
    public class BookRepositoryTests
    {
        BookRepository repository = new BookRepository();

        [Fact]
        public void GetById_ID2_ReturnBookWith2Id()
        {
            Book actual = repository.GetById(2);

            Assert.Equal(2, actual.Id);
        }

    }
}
