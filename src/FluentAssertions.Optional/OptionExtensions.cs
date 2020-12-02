using FluentAssertions.Optional;
using Optional;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class OptionExtensions
    {
        public static OptionAssertions<T> Should<T>(this Option<T> instance) => new OptionAssertions<T>(instance);
        
        public static OptionEitherAssertions<T, TException> Should<T, TException>(this Option<T, TException> instance) => new OptionEitherAssertions<T, TException>(instance);
    }
}