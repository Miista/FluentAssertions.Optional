using System.Collections.Generic;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
    public interface IOptionAssertions<TSubject, TAssertions>
    {
        Option<TSubject> Subject { get; }
        TAssertions ContinuedAssertions { get; }
    }
    
    public class OptionalStringAssertions : StringAssertions, IOptionAssertions<string, StringAssertions>
    {
        public new Option<string> Subject { get; }

        public StringAssertions ContinuedAssertions => new StringAssertions(Subject.ValueOrDefault());

        public OptionalStringAssertions(Option<string> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
    /*
    public class OptionalStringAssertions : OptionContinuedAssertions<string, OptionalStringAssertions, StringAssertions>
    {
        public OptionalStringAssertions(Option<string> subject) : base(subject, new StringAssertions(subject.ValueOrDefault()))
        {
        }

        [CustomAssertion]
        public AndConstraint<StringAssertions> BeOneOf(
            IEnumerable<string> validValues,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeOneOf(validValues, because, becauseArgs);

        [CustomAssertion]
        public AndConstraint<StringAssertions> BeEquivalentTo(
            string expected,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeEquivalentTo(expected, because, becauseArgs);
        
        // public AndConstraint<StringAssertions> Be(
        //     string expected,
        //     string because = "",
        //     params object[] becauseArgs)
        // {
        //     return HaveValue().Which.Should().Be(expected, because, becauseArgs);
        // }
        //
        // [CustomAssertion]
        // public AndConstraint<StringAssertions> StartWith(
        //     string expected,
        //     string because = "",
        //     params object[] becauseArgs)
        // {
        //     return HaveValue().Which.Should().StartWith(expected, because, becauseArgs);
        // }
        //
        // [CustomAssertion]
        // public AndConstraint<StringAssertions> EndWith(
        //     string expected,
        //     string because = "",
        //     params object[] becauseArgs)
        // {
        //     return HaveValue().Which.Should().EndWith(expected, because, becauseArgs);
        // }
        
        private StringAssertions HaveValueAnd()
        {
            HaveValue();
            return new StringAssertions(Subject.ValueOrDefault());
        }
    }
    */
}