using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string CoverUrl { get; set; }
        [Range(0, int.MaxValue)]
        public int CopiesInLibrary { get; set; }

        public virtual ICollection<Reader> CurrentlyBorrowing { get; set; }
    }
}
