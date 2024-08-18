using Nop.Web.Areas.Admin.Validators.Book;
using Nop.Web.Framework.Models;
using System;

namespace Nop.Web.Areas.Admin.Models.Book
{
    public class BookModel : BaseNopEntityModel
    {
        [CustomerBookValidator("BK-")]
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
