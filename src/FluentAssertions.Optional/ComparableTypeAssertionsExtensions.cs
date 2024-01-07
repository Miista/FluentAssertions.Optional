using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    // ReSharper disable once UnusedType.Global
    public static class ComparableTypeAssertionsExtensions
    {
        [CustomAssertion]
        public static AndConstraint<ComparableTypeAssertions<T>> Be<T>(
            this ComparableTypeAssertions<T> @this,
            Option<T> expected,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return @this.Be(expected.ValueOrDefault(), because, becauseArgs);
        }
        
        [CustomAssertion]
        public static AndConstraint<ComparableTypeAssertions<T>> NotBe<T>(
            this ComparableTypeAssertions<T> @this,
            Option<T> option,
            string because = "",
            params object[] becauseArgs) where T : struct
        {
            return @this.NotBe(option.ValueOrDefault(), because, becauseArgs);
        }

    }
}