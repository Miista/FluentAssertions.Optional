using Optional;

namespace FluentAssertions.Optional
{
    public interface IOptionAssertions<TSubject, TAssertions>
    {
        Option<TSubject> Subject { get; }
        TAssertions ContinuedAssertions { get; }
    }
}