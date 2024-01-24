using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalNullableSimpleTimeSpanAssertions : SimpleTimeSpanAssertions, IOptionAssertions<TimeSpan?, SimpleTimeSpanAssertions>
    {
        public new Option<TimeSpan?> Subject { get; }

        public SimpleTimeSpanAssertions ContinuedAssertions => new SimpleTimeSpanAssertions(Subject.ValueOrDefault());

        public OptionalNullableSimpleTimeSpanAssertions(Option<TimeSpan?> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}