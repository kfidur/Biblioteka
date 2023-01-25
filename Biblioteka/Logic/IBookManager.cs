using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Logic
{
    public interface IBookManager
    {
        IList<Book> GetAll();
        Book Get(int id);
        IBookManager Add(Book book);
        IBookManager Remove(int id);
        IBookManager Update(Book book);
    }
}
