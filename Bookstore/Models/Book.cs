using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Descriptiopn { get; set; }
        public Author Author { get; set; }
    }
}
