using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository
    {
        public List<Book> books = new List<Book>
        {
            new Book() { Id = 1, Title = "1984", Price = 150},
            new Book() { Id = 2, Title = "Fahrenheit 451", Price = 160},
            new Book() { Id = 3, Title = "Brave New World", Price = 100},
            new Book() { Id = 4, Title = "Da Vinci Code", Price = 299},
            new Book() { Id = 5, Title = "Angels and Demons", Price = 250}
        };
        public List<Book> Get(int? priceLessThan = null, int? priceGreaterThan = null, string? sortBy = null)
        {
            List<Book> bookList = new List<Book>(books);
            return bookList;
        }
        public Book? GetById(int id)
        {
            return books.FirstOrDefault(book =>  book.Id == id);
        }
    }
}
