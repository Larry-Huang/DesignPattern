using System.Collections.Generic;
using System.Linq;
using Demo.Clip07.Data;

namespace Demo.Clip07
{
    public class BooksBuilder
    {
        private IDictionary<int, DbCategory> CategoryRecords { get; set; } = 
            new Dictionary<int, DbCategory>();

        private IEnumerable<DbBook> BookRecords { get; set; } =
            Enumerable.Empty<DbBook>();

        private IDictionary<int, Category> Categories { get; } = new Dictionary<int, Category>();

        public BooksBuilder WithCategories(IEnumerable<DbCategory> rows)
        {
            this.CategoryRecords = rows.ToDictionary(row => row.Id);
            return this;
        }

        public BooksBuilder WithBooks(IEnumerable<DbBook> rows)
        {
            this.BookRecords = rows.ToList();
            return this;
        }

        public IEnumerable<Book> Build() =>
            this.BookRecords.Select(record =>
                new Book(record.Id, record.Title, this.GetCategory(record.CategoryId)));

        private Category GetCategory(int id) =>
            this.Categories.TryGetValue(id, out Category existing) ? existing
            : this.CreateCategory(id);

        private Category CreateCategory(int id)
        {
            DbCategory category = this.CategoryRecords[id];

            Category result = category.ParentId.HasValue 
                ? this.GetCategory(category.ParentId.Value).Subcategory(id, category.Name)
                : Category.CreateRoot(id, category.Name);

            this.Categories[id] = result;
            return result;
        }
    }
}