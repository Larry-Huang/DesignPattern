using System;

namespace Demo.Clip07
{
    sealed class InnerCategory : Category
    {
        public Category Parent { get; }

        public InnerCategory(int id, string name, Category parent) : base(id, name)
        {
            this.Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }
    }
}