using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void ValidateNameNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Book() { Title = null, Price = 100 }.Validate());
        }
        [TestMethod()]
        public void ValidateNameTooShort()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Book() {  Title = "ab", Price = 100 }.Validate());
        }
        [TestMethod()]
        public void ValidatePriceLessThanZero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Book() { Title = "abc", Price = -1 }.Validate());
        }
        [TestMethod()]
        public void ValidatePriceGreatherThan1200()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Book() { Title = "abc", Price = 1201 }.Validate());
        }
        [TestMethod()]
        public void BookToStringTest()
        {
            Book book = new Book();
            book.Id = 1;
            book.Title = "abc";
            book.Price = 100;

            Assert.AreEqual("Id: 1 Title: abc Price: 100",book.ToString());
        }
        [TestMethod()]
        public void ValidateBook()
        {
            Book book = new Book();
            book.Id = 1;
            book.Title = "abc";
            book.Price = 100;

            Assert.AreEqual(1,book.Id);
        }
        [TestMethod()]
        public void ValidateGetById()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(1, booksRepository.GetById(1).Id);
        }
        [TestMethod()]
        public void ValidateGetByIdNull()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.IsNull(booksRepository.GetById(10000));
        }
        [TestMethod()]
        public void ValidateAddBook()
        {
            Book book = new Book();
            book.Title = "new title";
            book.Price = 100;
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(6, booksRepository.Add(book).Id);
        }
        [TestMethod()]
        public void ValidateDeletebook()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(5, booksRepository.Delete(5).Id);
        }
        [TestMethod()]
        public void ValidateDeleteBookNull()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.IsNull(booksRepository.Delete(10000));
        }
        [TestMethod()]
        public void ValidateUpdateBook()
        {
            Book book = new Book();
            book.Title = "Updated title";
            book.Price = 1000;
            BooksRepository booksRepository = new BooksRepository();
            Book? updatedBook = booksRepository.Update(2, book);
            Assert.AreEqual(2, updatedBook.Id);
            Assert.AreEqual("Updated title", updatedBook.Title);
            Assert.AreEqual(1000, updatedBook.Price);
        }
        [TestMethod()]
        public void ValidateUpdateBookNull() 
        {
            Book book = new Book();
            book.Title = "Updated title";
            book.Price = 1000;
            BooksRepository booksRepository = new BooksRepository();
            Assert.IsNull(booksRepository.Update(1000,book));
        }
        [TestMethod()]
        public void ValidateGetPriceLessThan()
        {
            BooksRepository booksRepository= new BooksRepository();
            Assert.AreEqual(1, booksRepository.Get(120).Count());
        }
        [TestMethod()]
        public void ValidateGetPriceGreaterThan()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(2, booksRepository.Get(null,200).Count());
        }
        [TestMethod()]
        public void ValidateGetSortByTitle()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(1, booksRepository.Get(null, null, "title").FirstOrDefault().Id);
        }
        [TestMethod()]
        public void ValidateGetSortByTitleDesc()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(2, booksRepository.Get(null, null, "title_desc").FirstOrDefault().Id);
        }
        [TestMethod()]
        public void ValidateGetSortByPrice()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(3, booksRepository.Get(null, null, "price").FirstOrDefault().Id);
        }
        [TestMethod()]
        public void ValidateGetSortByPriceDesc()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(4, booksRepository.Get(null, null, "price_desc").FirstOrDefault().Id);
        }
        [TestMethod()]
        public void ValidateGetSortByDefault()
        {
            BooksRepository booksRepository = new BooksRepository();
            Assert.AreEqual(1, booksRepository.Get(null, null, "lorem ipsum").FirstOrDefault().Id);
        }
    }
}