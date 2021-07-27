using System;
using FluentAssertions.Optional;
using FluentAssertions.Optional.Numeric;
using FluentAssertions.Optional.Primitives;
using Optional;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class OptionExtensions
    {
        public static OptionalAssertions<T> Should<T>(this Option<T> instance) => new OptionalAssertions<T>(instance);
        
        public static OptionalGuidAssertions Should(this Option<Guid> instance) => new OptionalGuidAssertions(instance);
        
        public static OptionalDateTimeAssertions Should(this Option<DateTime> instance) => new OptionalDateTimeAssertions(instance);
        
        public static OptionalStringAssertions Should(this Option<string> instance) => new OptionalStringAssertions(instance);
        
        public static OptionalNumericAssertions<int> Should(this Option<int> instance) => new OptionalNumericAssertions<int>(instance);
        
        public static OptionalNumericAssertions<double> Should(this Option<double> instance) => new OptionalNumericAssertions<double>(instance);
        
        public static OptionalNumericAssertions<decimal> Should(this Option<decimal> instance) => new OptionalNumericAssertions<decimal>(instance);
        
        public static OptionEitherAssertions<T, TException> Should<T, TException>(this Option<T, TException> instance) => new OptionEitherAssertions<T, TException>(instance);
    }
}