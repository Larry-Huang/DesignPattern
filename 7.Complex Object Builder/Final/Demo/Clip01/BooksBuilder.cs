using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip01
{
    public class BooksBuilder
    {
        private IEnumerable<(int id, string title, int categoryId)> BookRecords { get; set; } =
            Enumerable.Empty<(int, string, int)>();

        private IDictionary<int, Category> Categories { get; } = 
            new Dictionary<int, Category>();

        private IDictionary<int, (int id, string name, int? parentId)> CategoryRecords { get; set; } =
            new Dictionary<int, (int, string, int?)>();

        public BooksBuilder WithCategories(IEnumerable<(int id, string name, int? parentId)> rows)
        {
            this.CategoryRecords = rows.ToDictionary(row => row.id);
            return this;
        }

        public BooksBuilder WithBooks(IEnumerable<(int id, string title, int categoryId)> rows)
        {
            this.BookRecords = rows.ToList();
            return this;
        }

        public IEnumerable<Book> Build() =>
            this.BookRecords.Select(record =>
                new Book(record.id, record.title, this.GetCategory(record.categoryId)));

        private Category GetCategory(int id) =>
            this.Categories.TryGetValue(id, out Category existing) ? existing
            : this.CreateCategory(id);

        private Category CreateCategory(int id)
        {
            (int _, string name, int? parentId) = this.CategoryRecords[id];
            Category result =
                parentId.HasValue ? this.GetCategory(parentId.Value).Subcategory(id, name)
                : Category.CreateRoot(id, name);
            this.Categories[id] = result;
            return result;
        }
    }
}