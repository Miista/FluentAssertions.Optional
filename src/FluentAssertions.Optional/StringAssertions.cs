using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class StringAssertionExtensions
    {
        [CustomAssertion]
        public static AndConstraint<StringAssertions> Be(
            this StringAssertions @this,
            Option<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return @this.Be(expected.ValueOr(alternative: null), because, becauseArgs);
        }
        
        [CustomAssertion]
        public static AndConstraint<StringAssertions> NotBe(
            this StringAssertions assertions,
            Option<string> option,
            string because = "",
            params object[] becauseArgs)
        {
            return assertions.NotBe(option.ValueOrDefault(), because, becauseArgs);
        }
    }
}