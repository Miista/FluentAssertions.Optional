using System;
using System.Collections;
using System.Linq.Expressions;
using FluentAssertions.Collections;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Collections
{
    public class OptionalNonGenericCollectionAssertions : OptionalCollectionAssertions<IEnumerable, NonGenericCollectionAssertions>
    {
        public OptionalNonGenericCollectionAssertions(Option<IEnumerable> subject) : base(subject, new NonGenericCollectionAssertions(subject.ValueOrDefault()))
        {
        }
        
        [CustomAssertion]
        public AndConstraint<NonGenericCollectionAssertions> HaveCount(
            int expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCount(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<NonGenericCollectionAssertions> NotHaveCount(
            int unexpected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotHaveCount(unexpected, because, becauseArgs);

        [CustomAssertion]
        public AndConstraint<NonGenericCollectionAssertions> HaveCountGreaterThan(
            int expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCountGreaterThan(expected, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> HaveCountGreaterOrEqualTo(
            int expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCountGreaterOrEqualTo(expected, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> HaveCountLessThan(
            int expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCountLessThan(expected, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> HaveCountLessOrEqualTo(
            int expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCountLessOrEqualTo(expected, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> HaveCount(
            Expression<Func<int, bool>> countPredicate,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().HaveCount(countPredicate, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> Contain(
            object expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().Contain(expected, because, becauseArgs);

        public AndConstraint<NonGenericCollectionAssertions> NotContain(
            object unexpected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotContain(unexpected, because, becauseArgs);
        
        private NonGenericCollectionAssertions HaveValueAnd()
        {
            HaveValue();
            return new NonGenericCollectionAssertions(Subject.ValueOrDefault());
        }
    }
}