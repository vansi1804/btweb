using ListBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListBooks.Controllers
{
    public class BooksController : Controller
    {
        private List<BookModels> listBooks;

        public BooksController()
        {
            listBooks = new List<BookModels>();
            listBooks.Add(new BookModels()
            {
                Id = 1,
                Title = "Dạy con làm giàu 1",
                Author = "Robert T.Kiyosaki",
                PublicYear = 2001,
                Price = 100000,
                Cover = "Content/images/dayconlamgiau1.jpg"
            });
            listBooks.Add(new BookModels()
            {
                Id = 2,
                Title = "Dạy con làm giàu 2",
                Author = "Robert T.Kiyosaki",
                PublicYear = 2011,
                Price = 200000,
                Cover = "Content/images/dayconlamgiau2.jpg"
            });
            listBooks.Add(new BookModels()
            {
                Id = 3,
                Title = "Dạy con làm giàu 3",
                Author = "Robert T.Kiyosaki",
                PublicYear = 2021,
                Price = 300000,
                Cover = "Content/images/dayconlamgiau3.jpg"
            });
            listBooks.Add(new BookModels()
            {
                Id = 4,
                Title = "Dạy con làm giàu 4",
                Author = "Robert T.Kiyosaki",
                PublicYear = 2021,
                Price = 400000,
                Cover = "Content/images/dayconlamgiau4.jpg"
            });
            listBooks.Add(new BookModels()
            {
                Id = 5,
                Title = "Dạy con làm giàu 5",
                Author = "Robert T.Kiyosaki",
                PublicYear = 2021,
                Price = 500000,
                Cover = "Content/images/dayconlamgiau5.jpg"
            });
        }

        public ActionResult ListBooks()
        {
            ViewBag.TitlePageName = "Book view page";
            return View(listBooks);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            BookModels book = listBooks.Find(f => f.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            BookModels book = listBooks.Find(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookModels book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.PublicYear = book.PublicYear;
                    editBook.Price = book.Price;
                    return View("ListBooks", listBooks);
                }
                catch (Exception)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Input model not valide!");
                return View(book);
            }
        }
    }
}