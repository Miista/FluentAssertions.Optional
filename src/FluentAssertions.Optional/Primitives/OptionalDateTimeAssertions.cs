using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalDateTimeAssertions : OptionContinuedAssertions<DateTime, OptionalDateTimeAssertions, DateTimeAssertions>
    {
        public OptionalDateTimeAssertions(Option<DateTime> subject) : base(subject, new DateTimeAssertions(subject.ValueOrDefault()))
        {
        }
    }
}