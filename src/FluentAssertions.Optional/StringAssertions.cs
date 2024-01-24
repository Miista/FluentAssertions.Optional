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
            this StringAssertions self,
            Option<string> expected,
            string because = "",
            params object[] becauseArgs)
        {
            return self.Be(expected.ValueOr(alternative: null), because, becauseArgs);
        }
        
        [CustomAssertion]
        public static AndConstraint<StringAssertions> NotBe(
            this StringAssertions self,
            Option<string> option,
            string because = "",
            params object[] becauseArgs)
        {
            return self.NotBe(option.ValueOrDefault(), because, becauseArgs);
        }
    }
}