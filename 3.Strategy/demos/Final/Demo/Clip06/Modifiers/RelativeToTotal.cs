using System;
using Demo.Common;

namespace Demo.Clip06.Modifiers
{
    public class RelativeToTotal : IDeduction
    {
        private decimal Factor { get; }

        public RelativeToTotal(decimal factor)
        {
            this.Factor = 0 <= factor && factor <= 1 ? factor : throw new ArgumentException(nameof(factor));
        }

        public Money From(Money a, Money b) =>
            this.Factor * (a + b);
    }
}
