using Biblioteka.Logic;
using Biblioteka.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka.Controllers
{
    public class ReaderController : Controller
    {
        private IReaderManager readerManager;
        public ReaderController(IReaderManager readerManager)
        {
            this.readerManager = readerManager;
        }
        // GET: ReaderController
        public ActionResult Index()
        {
            return View(readerManager.GetAll());
        }

        // GET: ReaderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReaderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReaderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] [Bind("FirstName", "LastName", "PhoneNumber")]Reader reader)
        {
            try
            {
                readerManager.Add(reader);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReaderController/Edit/5
        public ActionResult Edit(int id)
        {
            var reader = readerManager.Get(id);
            return View(reader);
        }

        // POST: ReaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm]Reader reader)
        {
            try
            {
                readerManager.Update(reader);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReaderController/Delete/5
        public ActionResult Delete(int id)
        {
            var reader = readerManager.Get(id);
            return View(reader);
        }

        // POST: ReaderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection _)
        {
            try
            {
                readerManager.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
