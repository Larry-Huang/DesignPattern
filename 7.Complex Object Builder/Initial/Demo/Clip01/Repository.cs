using System.Collections.Generic;

namespace Demo.Clip01
{
    public class Repository
    {
        public IEnumerable<(int id, string name, int? parentId)> Categories => new (int, string, int?)[]
        {
            (22, "Poetry", 17),
            (14, "ALL", null),
            (17, "Fiction", 14),
            (19, "Computers & Technology", 14),
            (26, "Fables", 17)
        };

        public IEnumerable<(int id, string title, int categoryId)> Books => new (int, string, int)[]
        {
            (3, "Design Patterns", 19),
            (11, "The Little Prince", 26),
            (4, "Object-oriented Software Construction", 19),
            (9, "The Raven", 22)
        };
    }
}
