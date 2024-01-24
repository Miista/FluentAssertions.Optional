using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalBooleanAssertions : BooleanAssertions, IOptionAssertions<bool, BooleanAssertions>
    {
        public new Option<bool> Subject { get; }

        public BooleanAssertions ContinuedAssertions => new BooleanAssertions(Subject.ValueOrDefault());

        public OptionalBooleanAssertions(Option<bool> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}