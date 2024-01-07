using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Numeric
{
    public class OptionalNullableNumericAssertions<TSubject>
        : NullableNumericAssertions<TSubject>, IOptionAssertions<TSubject?, NullableNumericAssertions<TSubject>>
        where TSubject : struct
    {
        public new Option<TSubject?> Subject { get; }

        public NullableNumericAssertions<TSubject> ContinuedAssertions => new NullableNumericAssertions<TSubject>(Subject.ValueOrDefault());

        public OptionalNullableNumericAssertions(Option<TSubject?> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}