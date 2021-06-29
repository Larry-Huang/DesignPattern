using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip04
{
    class KeywordsRepository
    {
        public IEnumerable<string> FindFor(string videoHandle) =>
            videoHandle == "karamazov-brothers" ? new [] {"karamazov", "brothers"}
            : Enumerable.Empty<string>();
    }
}
