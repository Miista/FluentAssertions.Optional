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
            this NumericAssertions<T> @this,
            Option<T> expected,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return @this.Be(expected.ToNullable(), because, becauseArgs);
        }
        
        [CustomAssertion]
        public static AndConstraint<NumericAssertions<T>> NotBe<T>(
            this NumericAssertions<T> assertions,
            Option<T> option,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return assertions.NotBe(option.ToNullable(), because, becauseArgs);
        }
    }
}