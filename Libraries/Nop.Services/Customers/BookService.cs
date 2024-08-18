using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain;
using Nop.Core;
using Nop.Core.Domain.Book;

namespace Nop.Services.Customers
{
    public partial class BookService : IBookService
    {
        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Book> GetAllBooks(string name = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public void InsertBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
