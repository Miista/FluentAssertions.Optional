using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalBooleanAssertions : OptionContinuedAssertions<bool, OptionalBooleanAssertions, BooleanAssertions>
    {
        public OptionalBooleanAssertions(Option<bool> subject) : base(subject, new BooleanAssertions(subject.ValueOrDefault()))
        {
        }
        
        [CustomAssertion]
        public AndConstraint<BooleanAssertions> BeTrue(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeTrue(because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<BooleanAssertions> BeFalse(
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeFalse(because, becauseArgs);
        
        [CustomAssertion]
        public AndConstraint<BooleanAssertions> Be(
            bool expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().Be(expected, because, becauseArgs);
        
        private BooleanAssertions HaveValueAnd()
        {
            HaveValue();
            return new BooleanAssertions(Subject.ValueOrDefault());
        }
    }
}