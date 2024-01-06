using System;
using System.Collections;
using FluentAssertions.Execution;
using FluentAssertions.Optional;
using FluentAssertions.Optional.Collections;
using FluentAssertions.Optional.Numeric;
using FluentAssertions.Optional.Primitives;
using Optional;
using Optional.Unsafe;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class TExt
    {
        /*[CustomAssertion]
        public static void Be<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            Option<TSubject> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(self.Subject == other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, self.Subject);
        }
        
        [CustomAssertion]
        public static AndConstraint<TAssertions> NotBe<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            Option<TSubject> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(self.Subject != other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, self.Subject);
        
            return new AndConstraint<TAssertions>(self.ContinuedAssertions);
        }*/
        
        [CustomAssertion]
        public static void BeNone<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(!self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", self.Subject);
        }
        
        [CustomAssertion]
        public static AndConstraint<TAssertions> BeSome<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", self.Subject);

            return new AndConstraint<TAssertions>(self.ContinuedAssertions);
        }
        
        [CustomAssertion]
        public static AndConstraint<TAssertions> NotBeNone<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", self.Subject);
        
            return new AndConstraint<TAssertions>(self.ContinuedAssertions);
        }
        
        [CustomAssertion]
        public static void NotBeSome<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(!self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", self.Subject);
        }
        
        [CustomAssertion]
        public static AndWhichConstraint<TAssertions, TSubject> HaveValue<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", self.Subject);

            return new AndWhichConstraint<TAssertions, TSubject>(self.ContinuedAssertions, self.Subject.ValueOrDefault());
        }
    }

    public static class OptionExtensions
    {
        public static OptionalAssertions<T> Should<T>(this Option<T> instance) => new OptionalAssertions<T>(instance);
        
        public static OptionalNonGenericCollectionAssertions Should(this Option<IEnumerable> instance) => new OptionalNonGenericCollectionAssertions(instance);
        
        public static OptionalGuidAssertions Should(this Option<Guid> instance) => new OptionalGuidAssertions(instance);
        
        public static OptionalBooleanAssertions Should(this Option<bool> instance) => new OptionalBooleanAssertions(instance);
        
        public static OptionalDateTimeAssertions Should(this Option<DateTime> instance) => new OptionalDateTimeAssertions(instance);
        
        public static OptionalStringAssertions Should(this Option<string> instance) => new OptionalStringAssertions(instance);
        
        public static OptionalNumericAssertions<int> Should(this Option<int> instance) => new OptionalNumericAssertions<int>(instance);
        
        public static OptionalNumericAssertions<uint> Should(this Option<uint> instance) => new OptionalNumericAssertions<uint>(instance);
        
        public static OptionalNumericAssertions<long> Should(this Option<long> instance) => new OptionalNumericAssertions<long>(instance);
        
        public static OptionalNumericAssertions<ulong> Should(this Option<ulong> instance) => new OptionalNumericAssertions<ulong>(instance);
        
        public static OptionalNumericAssertions<short> Should(this Option<short> instance) => new OptionalNumericAssertions<short>(instance);
        
        public static OptionalNumericAssertions<ushort> Should(this Option<ushort> instance) => new OptionalNumericAssertions<ushort>(instance);
        
        public static OptionalNumericAssertions<byte> Should(this Option<byte> instance) => new OptionalNumericAssertions<byte>(instance);
        
        public static OptionalNumericAssertions<sbyte> Should(this Option<sbyte> instance) => new OptionalNumericAssertions<sbyte>(instance);
        
        public static OptionalNumericAssertions<float> Should(this Option<float> instance) => new OptionalNumericAssertions<float>(instance);
        
        public static OptionalNumericAssertions<double> Should(this Option<double> instance) => new OptionalNumericAssertions<double>(instance);
        
        public static OptionalNumericAssertions<decimal> Should(this Option<decimal> instance) => new OptionalNumericAssertions<decimal>(instance);
        
        public static OptionEitherExceptionAssertions<T> Should<T>(this Option<T, Exception> instance) => new OptionEitherExceptionAssertions<T>(instance);
        
        public static OptionEitherAssertions<T, TException> Should<T, TException>(this Option<T, TException> instance) => new OptionEitherAssertions<T, TException>(instance);
    }
}