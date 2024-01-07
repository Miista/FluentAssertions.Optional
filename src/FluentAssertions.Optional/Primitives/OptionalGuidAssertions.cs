using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalGuidAssertions : GuidAssertions, IOptionAssertions<Guid, GuidAssertions>
    {
        public new Option<Guid> Subject { get; }

        public GuidAssertions ContinuedAssertions => new GuidAssertions(Subject.ValueOrDefault());

        public OptionalGuidAssertions(Option<Guid> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}