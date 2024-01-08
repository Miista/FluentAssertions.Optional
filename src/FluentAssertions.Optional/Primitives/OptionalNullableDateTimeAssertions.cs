using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
  public class OptionalNullableDateTimeAssertions : DateTimeAssertions, IOptionAssertions<DateTime?, NullableDateTimeAssertions>
  {
    public new Option<DateTime?> Subject { get; }

    public NullableDateTimeAssertions ContinuedAssertions => new NullableDateTimeAssertions(Subject.ValueOrDefault());

    public OptionalNullableDateTimeAssertions(Option<DateTime?> value) : base(value.ValueOrDefault())
    {
      Subject = value;
    }
  }
}