using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
  public class OptionalStringAssertions : StringAssertions, IOptionAssertions<string>
  {
    public OptionalStringAssertions(Option<string> value) : base(value.ValueOrDefault())
    {
      Subject = value;
    }

    public new Option<string> Subject { get; }
  }
}