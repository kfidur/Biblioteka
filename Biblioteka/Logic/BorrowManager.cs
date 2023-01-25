using Biblioteka.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteka.Models;

namespace Biblioteka.Logic
{
    public class BorrowManager : IBorrowManager
    {
        private BibliotekaContext context;
        private IReaderManager readerManager;
        public BorrowManager(BibliotekaContext context, IReaderManager readerManager)
        {
            this.context = context;
            this.readerManager = readerManager;
        }

        public IBorrowManager Borrow(int bookId, int readerId)
        {
            Book book = context.Books
                .Include(b => b.CurrentlyBorrowing
                    .Where(r => r.ReaderId == readerId))
                .Where(b => b.BookId == bookId).FirstOrDefault();
            if (book is null || book.CurrentlyBorrowing.Count != 0)
            {
                throw new ArgumentException($"Reader ID={readerId} already borrows ID={bookId} or specified book does not exist");
            }
            if (book.CopiesInLibrary <= 0)
            {
                throw new InvalidOperationException("Book has no copies in library, cannot borrow");
            }
            var reader = readerManager.Get(readerId);
            book.CurrentlyBorrowing.Add(reader);
            reader.CurrentlyBorrowed.Add(book);
            book.CopiesInLibrary -= 1;
            context.SaveChanges();
            return this;
        }

        public IList<Reader> GetPotentialBorrowers(int bookId)
        {
            return context.Readers
                .Where(r => !r.CurrentlyBorrowed
                    .Any(b => b.BookId == bookId)
                ).ToList();
        }

        public IBorrowManager Return(int bookId, int readerId)
        {
            Book book = context.Books
                .Include(b => b.CurrentlyBorrowing
                    .Where(r => r.ReaderId == readerId))
                .Where(b => b.BookId == bookId).FirstOrDefault();
            if (book is null || book.CurrentlyBorrowing.Count == 0)
            {
                throw new ArgumentException($"There is no borrow for reader ID={readerId} and book ID={bookId}");
            }
            book.CurrentlyBorrowing.Clear();
            book.CopiesInLibrary += 1;
            context.SaveChanges();
            return this;
        }
    }
}
