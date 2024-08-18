using Nop.Core.Domain;
using Nop.Core.Domain.Book;
using Nop.Services.Customers;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.Book;
using Nop.Web.Framework.Models.Extensions;
using System;
using System.Linq;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial class BookModelFactory : IBookModelFactory
    {
        private readonly IBookService _bookService;

        public BookModelFactory(IBookService bookService)
        {
            _bookService = bookService;
        }

        public virtual BookSearchModel PrepareBookSearchModel(BookSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        public BookListModel PrepareBookListModel(BookSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get books
            var books = _bookService.GetAllBooks(pageIndex: searchModel.Page - 1, pageSize: searchModel.PageSize);

            //prepare list model
            var model = new BookListModel().PrepareToGrid(searchModel, books, () =>
            {
                //fill in model values from the entity
                return books.Select(book =>
                {
                    var bookModel = book.ToModel<BookModel>();
                    //bookModel.SeName = _urlRecordService.GetSeName(vendor, 0, true, false);

                    return bookModel;
                });
            });

            return model;
        }

        public BookModel PrepareBookModel(BookModel model, Book book, bool excludeProperties = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
