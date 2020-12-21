using FluentAssertions.Numeric;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public class OptionalNumericAssertions<T> : OptionContinuedAssertions<T, OptionalNumericAssertions<T>, NumericAssertions<T>> where T : struct 
    {
        public OptionalNumericAssertions(Option<T> subject) : base(subject, new NumericAssertions<T>(subject.ValueOrDefault()))
        {
        }
        
        // public AndConstraint<NumericAssertions<T>> Be(
        //     T expected,
        //     string because = "",
        //     params object[] becauseArgs) =>
        //     HaveValueAnd().Be(expected, because, becauseArgs);
        //
        // public AndConstraint<NumericAssertions<T>> BePositive(
        //     string because = "",
        //     params object[] becauseArgs) =>
        //     HaveValueAnd().BePositive(because, becauseArgs);
        //
        // public AndConstraint<NumericAssertions<T>> BeNegative(
        //     string because = "",
        //     params object[] becauseArgs) =>
        //     HaveValueAnd().BeNegative(because, becauseArgs);
        //
        // private NumericAssertions<T> HaveValueAnd()
        // {
        //     HaveValue();
        //     return new NumericAssertions<T>(Subject.ValueOrDefault());
        // }
    }
}