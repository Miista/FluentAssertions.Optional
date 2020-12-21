using System;
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

    public class OptionalGuidAssertions : OptionContinuedAssertions<Guid, OptionalGuidAssertions, GuidAssertions>
    {
        public OptionalGuidAssertions(Option<Guid> subject) : base(subject, new GuidAssertions(subject.ValueOrDefault()))
        {
        }
    }
}