using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Models
{
    public class BorrowChoseReaderViewModel
    {
        public Book Book { get; }
        public IList<Reader> Readers { get; }
        public BorrowChoseReaderViewModel(Book book, IList<Reader> readers)
        {
            Book = book;
            Readers = readers;
        }
    }
}
