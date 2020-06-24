using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {
        public int id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 5)]
        public string Descriptiopn { get; set; }

        [Required]
        public Author Author { get; set; }
    }
}
