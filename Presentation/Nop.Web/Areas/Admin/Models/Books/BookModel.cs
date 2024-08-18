using iTextSharp.text;
using Nop.Core.Domain.Vendors;
using Nop.Web.Areas.Admin.Models.Vendors;
using Nop.Web.Areas.Admin.Validators.Book;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nop.Web.Areas.Admin.Models.Books
{
    public class BookModel : BaseNopEntityModel, ILocalizedModel<BookLocalizedModel>
    {
        #region Ctor

        public BookModel()
        {
            if (PageSize < 1)
                PageSize = 5;

            //Address = new AddressModel();
            //VendorAttributes = new List<VendorAttributeModel>();
            Locales = new List<BookLocalizedModel>();
            //AssociatedCustomers = new List<VendorAssociatedCustomerModel>();
            //VendorNoteSearchModel = new VendorNoteSearchModel();
        }

        #endregion

        [CustomerBookValidator("BK-")]
        public string BookName { get; set; }
        public string CreatedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy MMM dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        [NopResourceDisplayName("Admin.Vendors.Fields.PageSize")]
        public int PageSize { get; set; }
        public IList<BookLocalizedModel> Locales { get; set; }
    }

    public partial class BookLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [NopResourceDisplayName("Admin.Vendors.Fields.Name")]
        public string BookName { get; set; }

        [NopResourceDisplayName("Admin.Vendors.Fields.Description")]
        public string CreatedBy { get; set; }

        [NopResourceDisplayName("Admin.Vendors.Fields.MetaKeywords")]
        public DateTime CreatedOn { get; set; }
        
    }
}
