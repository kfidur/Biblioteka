using Biblioteka.Data;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Biblioteka.Logic
{
    public class ReaderManager : IReaderManager
    {
        private BibliotekaContext context;
        public ReaderManager(BibliotekaContext context)
        {
            this.context = context;
        }

        public IReaderManager Add(Reader reader)
        {
            context.Readers.Add(reader);
            context.SaveChanges();
            return this;
        }

        public Reader Get(int id)
        {
            return context.Readers
                .Include(r => r.CurrentlyBorrowed)
                .Where(r => r.ReaderId == id)
                .First();
        }

        public IList<Reader> GetAll()
        {
            return context.Readers.ToList();
        }

        public IReaderManager Remove(int id)
        {
            Reader reader = Get(id);
            foreach (var book in reader.CurrentlyBorrowed)
            {
                book.CopiesInLibrary += 1;
            }
            context.Readers.Remove(reader);
            context.SaveChanges();
            return this;
        }

        public IReaderManager Update(Reader reader)
        {
            context.Update(reader);
            context.SaveChanges();
            return this;
        }
    }
}
