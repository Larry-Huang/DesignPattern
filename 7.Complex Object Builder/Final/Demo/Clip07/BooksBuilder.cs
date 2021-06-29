using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Demo.Clip07.Data;

namespace Demo.Clip07
{
    public class BooksBuilder
    {
        private ImmutableDictionary<int, DbCategory> CategoryRecords { get; }

        private ImmutableList<DbBook> BookRecords { get; }

        public BooksBuilder()
            : this(ImmutableDictionary<int, DbCategory>.Empty, ImmutableList<DbBook>.Empty)
        {
        }

        private BooksBuilder(
            ImmutableDictionary<int, DbCategory> categories, ImmutableList<DbBook> books)
        {
            this.CategoryRecords = categories;
            this.BookRecords = books;
        }

        public BooksBuilder WithCategories(IEnumerable<DbCategory> rows) =>
            new BooksBuilder(
                this.CategoryRecords.AddRange(
                    rows.Select(row => KeyValuePair.Create(row.Id, row))),
                this.BookRecords);

        public BooksBuilder WithBooks(IEnumerable<DbBook> rows) => 
            new BooksBuilder(this.CategoryRecords, this.BookRecords.AddRange(rows));

        public IEnumerable<Book> Build() =>
            this.Build(new Dictionary<int, Category>());
        
        private IEnumerable<Book> Build(IDictionary<int, Category> cache) =>
            this.BookRecords.Select(record =>
                new Book(record.Id, record.Title, this.GetCategory(record.CategoryId, cache)));

        private Category GetCategory(int id, IDictionary<int, Category> cache) =>
            cache.TryGetValue(id, out Category existing) ? existing
            : this.CreateCategory(id, cache);

        private Category CreateCategory(int id, IDictionary<int, Category> cache)
        {
            DbCategory category = this.CategoryRecords[id];

            Category result = category.ParentId.HasValue 
                ? this.GetCategory(category.ParentId.Value, cache).Subcategory(id, category.Name)
                : Category.CreateRoot(id, category.Name);

            cache[id] = result;
            return result;
        }
    }
}