using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Books
{
    public class BookSearchModel : BaseSearchModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Books.List.SearchName")]
        public string SearchName { get; set; }

        #endregion
    }
}
