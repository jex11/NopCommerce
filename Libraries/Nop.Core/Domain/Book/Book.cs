using System;
using System.Collections.Generic;
using System.Text;

namespace Nop.Core.Domain.Book
{
    public partial class Book : BaseEntity
    {
        public string BookName { get; set; }        
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
