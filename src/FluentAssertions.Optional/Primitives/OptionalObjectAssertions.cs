using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalObjectAssertions : ObjectAssertions, IOptionAssertions<object, ObjectAssertions>
    {
        public new Option<object> Subject { get; }

        public ObjectAssertions ContinuedAssertions => new ObjectAssertions(Subject.ValueOrDefault());

        public OptionalObjectAssertions(Option<object> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}