using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalNullableDateTimeOffsetAssertions : NullableDateTimeOffsetAssertions, IOptionAssertions<DateTimeOffset?, NullableDateTimeOffsetAssertions>
    {
        public new Option<DateTimeOffset?> Subject { get; }

        public NullableDateTimeOffsetAssertions ContinuedAssertions => new NullableDateTimeOffsetAssertions(Subject.ValueOrDefault());

        public OptionalNullableDateTimeOffsetAssertions(Option<DateTimeOffset?> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}