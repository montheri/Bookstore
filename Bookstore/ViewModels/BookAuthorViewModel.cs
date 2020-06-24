using Bookstore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookID { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength=5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public int AuthorID { get; set; }
        public List<Author> Authors { get; set; }

    }
}
