using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalGuidAssertions : OptionContinuedAssertions<Guid, OptionalGuidAssertions, GuidAssertions>
    {
        public OptionalGuidAssertions(Option<Guid> subject) : base(subject, new GuidAssertions(subject.ValueOrDefault()))
        {
        }
        
        [CustomAssertion]
        public AndConstraint<GuidAssertions> BeEmpty(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeEmpty(because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<GuidAssertions> NotBeEmpty(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotBeEmpty(because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<GuidAssertions> Be(
            Guid expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().Be(expected, because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<GuidAssertions> NotBe(
            Guid unexpected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().NotBe(unexpected, because, becauseArgs);
        
        private GuidAssertions HaveValueAnd()
        {
            HaveValue();
            return new GuidAssertions(Subject.ValueOrDefault());
        }
    }
}