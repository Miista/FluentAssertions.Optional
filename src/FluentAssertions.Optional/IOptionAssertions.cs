using Optional;

namespace FluentAssertions.Optional
{
  public interface IOptionAssertions<TType>
  {
    Option<TType> Subject { get; }
  }
}