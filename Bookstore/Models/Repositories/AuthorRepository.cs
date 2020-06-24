using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author {id=1, FullName="Khaled Essaadani"},
                new Author {id=2, FullName="Monther Idkaidke"},
                new Author {id=3, FullName="Saddam Hjiji"}
            };
        }
        
        public void Add(Author entity)
        {
            entity.id = authors.Max(a => a.id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a => a.id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);

            author.FullName = entity.FullName;
        }
    }
}
