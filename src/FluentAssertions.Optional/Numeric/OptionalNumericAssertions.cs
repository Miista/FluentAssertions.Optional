using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Numeric
{
    public class OptionalNumericAssertions<T> : OptionContinuedAssertions<T, OptionalNumericAssertions<T>, NumericAssertions<T>> where T : struct 
    {
        public OptionalNumericAssertions(Option<T> subject) : base(subject, new NumericAssertions<T>(subject.ValueOrDefault()))
        {
        }
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BePositive(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BePositive(because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeNegative(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeNegative(because, becauseArgs);

        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeLessThan(
            T expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeLessThan(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeLessOrEqualTo(
            T expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeLessOrEqualTo(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeGreaterThan(
            T expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeGreaterThan(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeGreaterOrEqualTo(
            T expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeGreaterOrEqualTo(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeInRange(
            T minimumValue,
            T maximumValue,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeInRange(minimumValue, maximumValue, because, becauseArgs);

        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> NotBeInRange(
            T minimumValue,
            T maximumValue,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotBeInRange(minimumValue, maximumValue, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeOneOf(
            IEnumerable<T> validValues,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeOneOf(validValues, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeOneOf(
            params T[] validValues) =>
            HaveValueAnd().BeOneOf(validValues);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> BeOfType(
            Type expectedType,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeOfType(expectedType, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> NotBeOfType(
            Type unexpectedType,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotBeOfType(unexpectedType, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NumericAssertions<T>> Match(
            Expression<Func<T, bool>> predicate,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().Match(predicate, because, becauseArgs);
        
        private NumericAssertions<T> HaveValueAnd()
        {
            HaveValue();
            return new NumericAssertions<T>(Subject.ValueOrDefault());
        }
    }
}