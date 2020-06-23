using Bookstore.Models;
using System.Collections.Generic;

namespace Bookstore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorID { get; set; }
        public List<Author> Authors { get; set; }

    }
}
