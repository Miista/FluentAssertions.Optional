using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class NumericalAssertionExtensions
    {
        [CustomAssertion]
        public static AndConstraint<NumericAssertions<T>> Be<T>(
            this NumericAssertions<T> self,
            Option<T> expected,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return self.Be(expected.ToNullable(), because, becauseArgs);
        }
        
        [CustomAssertion]
        public static AndConstraint<NumericAssertions<T>> NotBe<T>(
            this NumericAssertions<T> self,
            Option<T> option,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return self.NotBe(option.ToNullable(), because, becauseArgs);
        }
    }
}