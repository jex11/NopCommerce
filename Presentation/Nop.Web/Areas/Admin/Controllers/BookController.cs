using Microsoft.AspNetCore.Mvc;
using Nop.Services.Customers;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;
using Nop.Web.Areas.Admin.Models.Book;

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

        public virtual IActionResult List()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.ManageBooks))
            //    return AccessDeniedView();

            //prepare model
            var model = _bookModelFactory.PrepareBookSearchModel(new BookSearchModel());

            return View(model);
        }
    }
}
