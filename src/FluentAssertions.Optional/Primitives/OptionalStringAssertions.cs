using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public interface IOptionAssertions<TSubject, TAssertions>
    {
        Option<TSubject> Subject { get; }
        TAssertions ContinuedAssertions { get; }
    }
    
    public class OptionalStringAssertions : StringAssertions, IOptionAssertions<string, StringAssertions>
    {
        public new Option<string> Subject { get; }

        public StringAssertions ContinuedAssertions => new StringAssertions(Subject.ValueOrDefault());

        public OptionalStringAssertions(Option<string> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}