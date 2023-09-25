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
            if(priceLessThan != null)
            {
                bookList.Where(b => b.Price < priceLessThan);
            }
            if(priceGreaterThan != null)
            {
                bookList.Where(b => b.Price > priceGreaterThan);
            }
            if(sortBy != null)
            {
                switch(sortBy.ToLower())
                {
                    case "title":
                    case "title_asc":
                        bookList.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        bookList.OrderByDescending(b => b.Title);
                        break;
                    case "price":
                    case "price_asc":
                        bookList.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        bookList.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break;
                }
            }
            return bookList;
        }
        public Book? GetById(int id)
        {
            return books.FirstOrDefault(book =>  book.Id == id);
        }
        public Book Add(Book book)
        {
            book.Validate();
            int currentMaxId = books.Select(b => b.Id).Max();
            book.Id = currentMaxId++;
            books.Add(book);
            return book;
        }
        public Book? Delete(int id) 
        {
            Book? bookToDelete = GetById(id);
            if(bookToDelete == null)
            {
                return null;
            }
            books.Remove(bookToDelete);
            return bookToDelete;
        }
        public Book? Update(int id, Book values)
        {
            values.Validate();
            Book? bookToUpdate = GetById(id);
            if (bookToUpdate == null)
            {
                return null;
            }
            bookToUpdate.Title = values.Title;
            bookToUpdate.Price = values.Price;
            return bookToUpdate;
        }
    }
}
