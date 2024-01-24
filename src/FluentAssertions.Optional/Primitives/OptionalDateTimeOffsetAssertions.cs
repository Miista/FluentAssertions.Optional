using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalDateTimeOffsetAssertions : DateTimeOffsetAssertions, IOptionAssertions<DateTimeOffset, DateTimeOffsetAssertions>
    {
        public new Option<DateTimeOffset> Subject { get; }

        public DateTimeOffsetAssertions ContinuedAssertions => new DateTimeOffsetAssertions(Subject.ValueOrDefault());

        public OptionalDateTimeOffsetAssertions(Option<DateTimeOffset> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}