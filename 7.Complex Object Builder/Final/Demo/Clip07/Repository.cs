using System.Collections.Generic;
using Demo.Clip07.Data;

namespace Demo.Clip07
{
    public class Repository
    {
        public IEnumerable<DbCategory> Categories => new[]
        {
            new DbCategory() { Id = 22, Name = "Poetry", ParentId = 17 },
            new DbCategory() { Id = 14, Name = "ALL", ParentId = null },
            new DbCategory() { Id = 17, Name = "Fiction", ParentId = 14 },
            new DbCategory() { Id = 19, Name = "Computers & Technology", ParentId = 14 },
            new DbCategory() { Id = 26, Name = "Fables", ParentId = 17 }
        };

        public IEnumerable<DbBook> Books => new[]
        {
            new DbBook() {Id = 3, Title = "Design Patterns", CategoryId = 19 },
            new DbBook() {Id = 11, Title = "The Little Prince", CategoryId = 26 },
            new DbBook() {Id = 4, Title = "Object-oriented Software Construction", CategoryId = 19 },
            new DbBook() {Id = 9, Title = "The Raven", CategoryId = 22 }
        };
    }
}