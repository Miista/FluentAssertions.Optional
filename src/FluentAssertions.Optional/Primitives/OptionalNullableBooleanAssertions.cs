using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalNullableBooleanAssertions : NullableBooleanAssertions, IOptionAssertions<bool?, NullableBooleanAssertions>
    {
        public new Option<bool?> Subject { get; }

        public NullableBooleanAssertions ContinuedAssertions => new NullableBooleanAssertions(Subject.ValueOrDefault());

        public OptionalNullableBooleanAssertions(Option<bool?> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}