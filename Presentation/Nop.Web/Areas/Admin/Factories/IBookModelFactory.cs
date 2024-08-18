using Nop.Core.Domain;
using Nop.Core.Domain.Book;
using Nop.Web.Areas.Admin.Models.Book;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial interface IBookModelFactory
    {
        /// <summary>
        /// Prepare vendor search model
        /// </summary>
        /// <param name="searchModel">Vendor search model</param>
        /// <returns>Vendor search model</returns>
        BookSearchModel PrepareBookSearchModel(BookSearchModel searchModel);

        /// <summary>
        /// Prepare paged vendor list model
        /// </summary>
        /// <param name="searchModel">Vendor search model</param>
        /// <returns>Vendor list model</returns>
        BookListModel PrepareBookListModel(BookSearchModel searchModel);

        /// <summary>
        /// Prepare vendor model
        /// </summary>
        /// <param name="model">Vendor model</param>
        /// <param name="vendor">Vendor</param>
        /// <param name="excludeProperties">Whether to exclude populating of some properties of model</param>
        /// <returns>Vendor model</returns>
        BookModel PrepareBookModel(BookModel model, Book book, bool excludeProperties = false);

        /// <summary>
        /// Prepare paged vendor note list model
        /// </summary>
        /// <param name="searchModel">Vendor note search model</param>
        /// <param name="vendor">Vendor</param>
        /// <returns>Vendor note list model</returns>
        //VendorNoteListModel PrepareVendorNoteListModel(VendorNoteSearchModel searchModel, Vendor vendor);
    }
}
