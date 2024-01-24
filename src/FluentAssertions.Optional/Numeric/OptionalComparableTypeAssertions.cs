using System;
using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Numeric
{
    public class OptionalComparableTypeAssertions<T> : ComparableTypeAssertions<T>, IOptionAssertions<IComparable<T>, ComparableTypeAssertions<T>>
    {
        public new Option<IComparable<T>> Subject { get; }

        public ComparableTypeAssertions<T> ContinuedAssertions => new ComparableTypeAssertions<T>(Subject.ValueOrDefault());

        public OptionalComparableTypeAssertions(Option<IComparable<T>> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}