using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Logic
{
    public interface IReaderManager
    {
        IList<Reader> GetAll();
        Reader Get(int id);
        IReaderManager Add(Reader reader);
        IReaderManager Remove(int id);
        IReaderManager Update(Reader reader);
    }
}
