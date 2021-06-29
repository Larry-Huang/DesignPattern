using System;

namespace Demo.Clip01
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new ArgumentException();
            this.Amount = amount;
            this.Currency = currency;
        }

        public virtual Money Add(Money other) =>
            this + other;

        public static Money operator *(Money amount, decimal factor) =>
            new Money(amount.Amount * factor, amount.Currency);

        public Money Scale(decimal factor) => this * factor;

        public static Money operator *(decimal factor, Money amount) =>
            new Money(amount.Amount * factor, amount.Currency);

        public static Money operator /(Money amount, decimal factor) =>
            new Money(amount.Amount / factor, amount.Currency);

        public static decimal operator / (Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount / b.Amount
            : RaiseCurrencyError<decimal>("divide", a, b);

        public static Money operator +(Money a, Money b) =>
            a.Currency == b.Currency ? new Money(a.Amount + b.Amount, a.Currency)
            : RaiseCurrencyError<Money>("add", a, b);

        public static Money operator -(Money a, Money b) =>
            a >= b ? new Money(a.Amount - b.Amount, a.Currency)
            : throw new ArgumentException("Not enough funds");

        public static bool operator ==(Money a, Money b) =>
            a?.Equals(b) ?? b is null;

        public static bool operator !=(Money a, Money b) =>
            !(a == b);

        public static bool operator >(Money a, Money b ) =>
            a.Currency == b.Currency ? a.Amount > b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator <(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount < b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator >=(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount >= b.Amount
            : RaiseCurrencyComparisonError(a, b);

        public static bool operator <=(Money a, Money b) =>
            a.Currency == b.Currency ? a.Amount <= b.Amount
            : RaiseCurrencyComparisonError(a, b);

        private static bool RaiseCurrencyComparisonError(Money a, Money b) =>
            RaiseCurrencyError<bool>("compare", a, b);

        private static T RaiseCurrencyError<T>(string operation, Money a, Money b) =>
            throw new ArgumentException($"Cannot {operation} {a.Currency} and {b.Currency}");

        public override string ToString() =>
            $"{this.Amount:0.00} {this.Currency}";

        public bool Equals(Money other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Amount == other.Amount && Equals(Currency, other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Amount.GetHashCode() * 397) ^ (Currency != null ? Currency.GetHashCode() : 0);
            }
        }
    }
}
