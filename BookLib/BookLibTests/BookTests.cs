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
    }
}