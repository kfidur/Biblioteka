using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Logic
{
    public interface IBorrowManager
    {
        public IBorrowManager Borrow(int bookId, int readerId);
        public IBorrowManager Return(int bookId, int readerId);

        public IList<Reader> GetPotentialBorrowers(int bookId);
    }
}
