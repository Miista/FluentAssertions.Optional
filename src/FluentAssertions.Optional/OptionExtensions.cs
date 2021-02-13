using FluentAssertions.Optional;
using Optional;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class OptionExtensions
    {
        public static OptionalNumericAssertions<int> Should(this Option<int> instance) => new OptionalNumericAssertions<int>(instance);
        public static OptionalStringAssertions Should(this Option<string> instance) => new OptionalStringAssertions(instance);
        public static OptionalObjectAssertions Should<T>(this Option<T> actualValue) => new OptionalObjectAssertions(actualValue.Map(v => (object) v));
        public static OptionalObjectAssertions Should(this Option<object> actualValue) => new OptionalObjectAssertions(actualValue);
    }
}