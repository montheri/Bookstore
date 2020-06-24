using Bookstore.Models;
using Bookstore.Models.Repositories;
using Bookstore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookstoreRepository<Book> bookRepository;

        public IBookstoreRepository<Author> AuthorRepository { get; }

        public BookController(IBookstoreRepository<Book> bookRepository, IBookstoreRepository<Author> authorRepository)
        {
            this.bookRepository = bookRepository;
            AuthorRepository = authorRepository;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.List();
            
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View(getAllBooksAuthors());
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (model.AuthorID == -1)
                    {
                        ViewBag.Message = "Please, select an Author from Author list ... ";

                        var vmodel = new BookAuthorViewModel
                        {
                            Authors = fillSelectList()
                        };

                        return View(vmodel);
                    };

                    var author = AuthorRepository.Find(model.AuthorID);
                    Book book = new Book
                    {
                        id = model.BookID,
                        Title = model.Title,
                        Descriptiopn = model.Description,
                        Author = author
                    };

                    bookRepository.Add(book);

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }

            }
            else
            {
                ModelState.AddModelError("", "please, you have to fill all requered fields!");
                return View(getAllBooksAuthors());
            }
          
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepository.Find(id);
            var authorID = book.Author != null ? book.Author.id : 0;

            var viewModel = new BookAuthorViewModel
            {
                BookID = book.id,
                Title = book.Title,
                Description = book.Descriptiopn,
                AuthorID = authorID,
                Authors = AuthorRepository.List().ToList()

            };
            
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAuthorViewModel viewModel)
        {
            try
            {
                var author = AuthorRepository.Find(viewModel.AuthorID);
                Book book = new Book
                {
                    Title = viewModel.Title,
                    Descriptiopn = viewModel.Description,
                    Author = author
                };

                bookRepository.Update(viewModel.BookID, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepository.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Book book)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        List<Author> fillSelectList()
        {
            var author = AuthorRepository.List().ToList();
            author.Insert(0, new Author { id = -1, FullName = "... Please select an Author ..." });

            return author;
        }

        BookAuthorViewModel getAllBooksAuthors()
        {
            var model = new BookAuthorViewModel
            {
                Authors = fillSelectList()
            };
            return model;
        }

    }
}
