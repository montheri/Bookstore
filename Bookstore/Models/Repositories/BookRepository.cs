using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Models.Repositories
{
    public class BookRepository : IBookstoreRepository<Book>
    {
        List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    id=1, Title = "C# Programming Language", Descriptiopn = "the Language of C#"
                },
                new Book
                {
                    id=2, Title = "Java Programming Language", Descriptiopn = "what you need to know of Java programming language"
                },
                new Book
                {
                    id=3, Title = "Python Programming Language", Descriptiopn = "the new way of programming"
                }
            };
        }

        public void Add(Book entity)
        {
            entity.id = books.Max(b => b.id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book entity)
        {
            var book = Find(id);

            book.Title = entity.Title;
            book.Descriptiopn = entity.Descriptiopn;
            book.Author = entity.Author;
        }
    }
}
