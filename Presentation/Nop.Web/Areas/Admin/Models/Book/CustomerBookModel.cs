using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Book
{
    public partial class CustomerBookModel : BaseNopModel
    {
        #region Ctor

        public CustomerBookModel()
        {
            Book = new BookModel();
        }

        #endregion

        #region Properties

        public int CustomerId { get; set; }

        public BookModel Book { get; set; }

        #endregion
    }
}
