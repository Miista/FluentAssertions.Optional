using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
  public class OptionalDateTimeAssertions : DateTimeAssertions, IOptionAssertions<DateTime, DateTimeAssertions>
  {
    public new Option<DateTime> Subject { get; }

    public DateTimeAssertions ContinuedAssertions => new DateTimeAssertions(Subject.ValueOrDefault());

    public OptionalDateTimeAssertions(Option<DateTime> value) : base(value.ValueOrDefault())
    {
      Subject = value;
    }
  }
}