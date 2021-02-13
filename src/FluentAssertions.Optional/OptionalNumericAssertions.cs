using FluentAssertions.Numeric;
using Optional;

namespace FluentAssertions.Optional
{
  public class OptionalNumericAssertions<T> : NullableNumericAssertions<T>, IOptionAssertions<T> where T : struct
  {
    public OptionalNumericAssertions(Option<T> value) : base(value.Match(i => new T?(i), () => (T?) null))
    {
      Subject = value;
    }

    public new Option<T> Subject { get; }
  }
}