using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public class OptionalAssertions<T> : OptionContinuedAssertions<T, OptionalAssertions<T>, ObjectAssertions>
    {
        public OptionalAssertions(Option<T> subject) : base(subject, new ObjectAssertions(subject.ValueOrDefault()))
        {
        }
    }
}