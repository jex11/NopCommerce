using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Domain;
using Nop.Core;
using Nop.Core.Domain.Book;

namespace Nop.Services.Customers
{
    public partial interface IBookService
    {
        /// <summary>
        /// Inserts a book
        /// </summary>
        /// <param name="book">Book</param>
        void InsertBook(Book book);

        /// <summary>
        /// Gets a book by book identifier
        /// </summary>
        /// <param name="bookId">Book identifier</param>
        /// <returns>Book</returns>
        Book GetBookById(int bookId);

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <param name="name">Book name</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        IPagedList<Book> GetAllBooks(string name = "", int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="book">Book</param>
        void UpdateBook(Book book);

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="book">Book</param>
        void DeleteBook(Book book);
    }
}
