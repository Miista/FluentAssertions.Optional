using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalSimpleTimeSpanAssertions : SimpleTimeSpanAssertions, IOptionAssertions<TimeSpan, SimpleTimeSpanAssertions>
    {
        public new Option<TimeSpan> Subject { get; }

        public SimpleTimeSpanAssertions ContinuedAssertions => new SimpleTimeSpanAssertions(Subject.ToNullable());

        public OptionalSimpleTimeSpanAssertions(Option<TimeSpan> value) : base(value.ToNullable())
        {
            Subject = value;
        }
    }
}