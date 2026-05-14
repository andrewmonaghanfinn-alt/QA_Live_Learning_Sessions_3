using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryService.Tests
{

    [TestClass]
    public class LibraryServiceTests
    {
        private LibraryDatabaseStub _db;
        private LibraryService _service;
        private User _user;

        [TestInitialize]
        public void Setup()
        {
            _db = new LibraryDatabaseStub();
            _service = new LibraryService(_db);
            _user = new User("Alice", 1);

            _db.AddBook(new Book("Test Book", "123"));
        }

        [TestMethod]
        public void BorrowBook_WhenAvailable_ShouldSucceed()
        {
            var result = _service.BorrowBook("123", _user);

            Assert.IsTrue(result);
            Assert.IsFalse(_db.FindBookByIsbn("123").IsAvailable);
        }

        [TestMethod]
        public void BorrowBook_WhenAlreadyOnLoan_ShouldFail()
        {
            _service.BorrowBook("123", _user);

            var result = _service.BorrowBook("123", _user);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ReturnBook_WhenOnLoan_ShouldSucceed()
        {
            _service.BorrowBook("123", _user);

            var result = _service.ReturnBook("123", _user);

            Assert.IsTrue(result);
            Assert.IsTrue(_db.FindBookByIsbn("123").IsAvailable);
        }

        [TestMethod]
        public void ReturnBook_WhenNotOnLoan_ShouldFail()
        {
            var result = _service.ReturnBook("123", _user);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateBookStatus_ShouldChangeAvailability()
        {
            _service.UpdateBookStatus("123", false);

            Assert.IsFalse(_db.FindBookByIsbn("123").IsAvailable);

            _service.UpdateBookStatus("123", true);

            Assert.IsTrue(_db.FindBookByIsbn("123").IsAvailable);
        }
    }

}