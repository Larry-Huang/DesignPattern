using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip01
{
    public abstract class Category
    {
        public int Id { get; }
        public string Name { get; }
     
        protected Category(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public static Category CreateRoot(int id, string name) =>
            new RootCategory(id, name);

        public Category Subcategory(int id, string name) =>
            new InnerCategory(id, name, this);

        public override string ToString() =>
            string.Join(" > ", this.Path.Select(cat => cat.Name).ToArray());

        private IEnumerable<Category> Path =>
            this.NestingSequence().Reverse().DefaultIfEmpty(this);

        private IEnumerable<Category> NestingSequence()
        {
            Category current = this;
            yield return current;
            while (current is InnerCategory inner)
            {
                current = inner.Parent;
                yield return current;
            }
        }
    }
}