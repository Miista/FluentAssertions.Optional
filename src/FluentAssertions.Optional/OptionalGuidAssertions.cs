using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public class OptionalGuidAssertions : OptionContinuedAssertions<Guid, OptionalGuidAssertions, GuidAssertions>
    {
        public OptionalGuidAssertions(Option<Guid> subject) : base(subject, new GuidAssertions(subject.ValueOrDefault()))
        {
        }
    }
}