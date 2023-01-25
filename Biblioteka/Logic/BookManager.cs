using Biblioteka.Data;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Logic
{
    public class BookManager : IBookManager
    {
        private BibliotekaContext context;
        public BookManager(BibliotekaContext context)
        {
            this.context = context;
        }

        public IBookManager Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return this;
        }

        public Book Get(int id)
        {
            return context.Books
                .Include(b => b.CurrentlyBorrowing)
                .Where(b => b.BookId == id)
                .First();
        }

        public IList<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public IBookManager Remove(int id)
        {
            Book book = new() { BookId = id };
            context.Books.Attach(book);
            context.Books.Remove(book);
            context.SaveChanges();
            return this;
        }

        public IBookManager Update(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
            return this;
        }
    }
}
