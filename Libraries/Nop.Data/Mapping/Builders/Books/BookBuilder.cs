using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Book;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Books
{
    public partial class BookBuilder : NopEntityBuilder<Book>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Book.BookName)).AsString(400).NotNullable()
                .WithColumn(nameof(Book.CreatedOn)).AsDateTime().NotNullable()
                .WithColumn(nameof(Book.CreatedBy)).AsString(400).NotNullable();
        }

        #endregion
    }
}
