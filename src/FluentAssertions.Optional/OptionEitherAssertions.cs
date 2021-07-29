using FluentAssertions.Execution;
using Optional;

namespace FluentAssertions.Optional
{
    public class OptionEitherAssertions<T, TException>
    {
        internal readonly Option<T, TException> Subject;

        public OptionEitherAssertions(Option<T, TException> subject)
        {
            Subject = subject;
        }
        
        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> Be(
            Option<T, TException> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, Subject);
            
            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBe(
            Option<T, TException> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject != other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
        
        [CustomAssertion]
        public AndWhichConstraint<OptionEitherAssertions<T, TException>, TException> HaveAlternateValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to have alternate value{reason} but found {0}.", Subject);

            TException _exception = default(TException);
            Subject.MapException(ex => _exception = ex);
            
            return new AndWhichConstraint<OptionEitherAssertions<T, TException>, TException>(this, _exception);
        }
        
        [CustomAssertion]
        public void NotHaveAlternateValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to have alternate value{reason} but found {0}.", Subject);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", Subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", Subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> BeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", Subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", Subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
    }
}