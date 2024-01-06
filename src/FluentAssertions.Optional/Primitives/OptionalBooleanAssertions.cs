using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public class OptionalBooleanAssertions : BooleanAssertions, IOptionAssertions<bool, BooleanAssertions>
    {
        public new Option<bool> Subject { get; }

        public BooleanAssertions ContinuedAssertions => new BooleanAssertions(Subject.ValueOrDefault());

        public OptionalBooleanAssertions(Option<bool> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }

    
    /*
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
*/
}