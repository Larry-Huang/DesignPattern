using System;

namespace Demo.Clip01
{
    public class Currency : IEquatable<Currency>
    {
        private string Symbol { get; }

        public Currency(string symbol)
        {
            this.Symbol = symbol;
        }

        public Money Zero => 
            new Money(0, this);

        public Money Of(decimal amount) =>
            new Money(amount, this);

        public Money MinPositiveValue =>
            new Money(.01M, this);

        public override string ToString() =>
            this.Symbol;

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Symbol, other.Symbol);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return (Symbol != null ? Symbol.GetHashCode() : 0);
        }

        public static bool operator ==(Currency a, Currency b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(Currency a, Currency b) =>
            !(a == b);
    }
}