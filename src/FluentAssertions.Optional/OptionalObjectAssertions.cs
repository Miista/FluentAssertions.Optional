using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
  public class OptionalObjectAssertions : ObjectAssertions, IOptionAssertions<object>
  {
    public OptionalObjectAssertions(Option<object> actualValue) : base(actualValue.ValueOrDefault())
    {
      Subject = actualValue;
    }

    public new Option<object> Subject { get; }
  }
}