using FluentAssertions.Numeric;
using FluentAssertions.Optional.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Numeric
{
    public class OptionalNumericAssertions<T> : NumericAssertions<T>, IOptionAssertions<T, NumericAssertions<T>> where T : struct
    {
        public new Option<T> Subject { get; }

        public NumericAssertions<T> ContinuedAssertions => new NumericAssertions<T>(Subject.ValueOrDefault());

        public OptionalNumericAssertions(Option<T> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}