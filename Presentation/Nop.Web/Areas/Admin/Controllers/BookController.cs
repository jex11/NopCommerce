using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Domain.Vendors;
using Nop.Services.Customers;
using Nop.Services.Security;
using Nop.Services.Vendors;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Books;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Core.Domain.Book;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class BookController : BaseAdminController
    {
        private readonly IBookService _bookService;
        private readonly IPermissionService _permissionService;
        private readonly IBookModelFactory _bookModelFactory;

        public BookController(IBookService bookService, IPermissionService permissionService, IBookModelFactory bookModelFactory)
        {
            _bookService = bookService;
            _permissionService = permissionService;
            _bookModelFactory = bookModelFactory;
        }

        public virtual IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public virtual IActionResult Create()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();

            //prepare model
            var model = _bookModelFactory.PrepareBookModel(new BookModel(), new Core.Domain.Book.Book());

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        [FormValueRequired("save", "save-continue")]
        public virtual IActionResult Create(BookModel model, bool continueEditing, IFormCollection form)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();


            if (ModelState.IsValid)
            {
                var book = model.ToEntity<Book>();
                book.CreatedBy = "SYSTEM";
                book.CreatedOn = DateTime.UtcNow;
                _bookService.InsertBook(book);                

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = book.Id });
            }

            //prepare model
            model = _bookModelFactory.PrepareBookModel(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        public virtual IActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();

            //prepare model
            var model = _bookModelFactory.PrepareBookSearchModel(new BookSearchModel());

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult List(BookSearchModel searchModel)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedDataTablesJson();

            //prepare model
            var model = _bookModelFactory.PrepareBookListModel(searchModel);

            return Json(model);
        }

        public virtual IActionResult Edit(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();

            //try to get a book with the specified id
            var book = _bookService.GetBookById(id);
            if (book == null)
                return RedirectToAction("List");

            //prepare model
            var model = _bookModelFactory.PrepareBookModel(null, book);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public virtual IActionResult Edit(BookModel model, bool continueEditing, IFormCollection form)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();

            //try to get a vendor with the specified id
            var book = _bookService.GetBookById(model.Id);
            if (book == null)
                return RedirectToAction("List");            

            if (ModelState.IsValid)
            {
                var prevPictureId = book.BookName;
                book = model.ToEntity(book);
                book.CreatedBy = "SYSTEM";
                book.CreatedOn = DateTime.UtcNow;

                _bookService.UpdateBook(book);                

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = book.Id });
            }

            //prepare model
            model = _bookModelFactory.PrepareBookModel(model, book, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
                return AccessDeniedView();

            //try to get a vendor with the specified id
            var book = _bookService.GetBookById(id);
            if (book == null)
                return RedirectToAction("List");

            _bookService.DeleteBook(book);

            //can use NLog to log activity

            return RedirectToAction("List");
        }
    }
}
