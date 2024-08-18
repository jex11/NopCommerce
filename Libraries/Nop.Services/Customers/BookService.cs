using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain;
using Nop.Core;
using Nop.Core.Domain.Book;
using Nop.Core.Domain.Vendors;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Nop.Data;
using Nop.Services.Events;
using System.Linq;
using iTextSharp.text;
using System.Xml.Linq;
using Nop.Core.Domain.Catalog;
using Nop.Services.Caching.Extensions;

namespace Nop.Services.Customers
{
    public partial class BookService : IBookService
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Book> _bookRepository;

        public BookService(IEventPublisher _eventPublisher, IRepository<Book> bookRepository)
        {
            this._eventPublisher = _eventPublisher;
            _bookRepository = bookRepository;
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Delete(book);

            //event notification
            _eventPublisher.EntityDeleted(book);
        }

        public IPagedList<Book> GetAllBooks(string name = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _bookRepository.Table;
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(v => v.BookName.Contains(name));          

            var books = new PagedList<Book>(query, pageIndex, pageSize);
         
            return books;
        }

        public Book GetBookById(int bookId)
        {
            if (bookId == 0)
                return null;

            return _bookRepository.GetById(bookId);
        }

        public void InsertBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Insert(book);

            //event notification
            _eventPublisher.EntityInserted(book);
        }

        public void UpdateBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _bookRepository.Update(book);

            //event notification
            _eventPublisher.EntityUpdated(book);
        }
    }
}
