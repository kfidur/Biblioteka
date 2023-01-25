using Biblioteka.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteka.Models;

namespace Biblioteka.Controllers
{
    public class BorrowController : Controller
    {
        private IBorrowManager borrowManager;
        private IBookManager bookManager;
        public BorrowController(IBorrowManager borrowManager, IBookManager bookManager)
        {
            this.borrowManager = borrowManager;
            this.bookManager = bookManager;
        }

        [HttpGet]
        public IActionResult Borrow(int bookId)
        {
            var book = bookManager.Get(bookId);
            var readersThatCanBorrow = borrowManager.GetPotentialBorrowers(bookId);
            return View(new BorrowChoseReaderViewModel(book, readersThatCanBorrow));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Borrow([FromForm] int bookId, [FromForm] int readerId)
        {
            try
            {
                borrowManager.Borrow(bookId, readerId);
            } catch (Exception)
            {

            }
            return RedirectToAction("Index", "Book");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Return([FromForm] int readerId, [FromForm] int bookId)
        {
            borrowManager.Return(bookId, readerId);
            return RedirectToAction("Edit", "Reader", new { id = readerId });
        }
    }
}
