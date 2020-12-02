using FluentAssertions.Execution;
using Optional;

namespace FluentAssertions.Optional
{
    public class OptionEitherAssertions<T, TException>
    {
        private readonly Option<T, TException> _subject;

        public OptionEitherAssertions(Option<T, TException> subject)
        {
            _subject = subject;
        }
        
        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> Be(
            Option<T, TException> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject == other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, _subject);
            
            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBe(
            Option<T, TException> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject != other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, _subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
        
        [CustomAssertion]
        public AndWhichConstraint<OptionEitherAssertions<T, TException>, TException> HaveException(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", _subject);

            TException _exception = default(TException);
            _subject.MapException(ex => _exception = ex);
            return new AndWhichConstraint<OptionEitherAssertions<T, TException>, TException>(this, _exception);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", _subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> BeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", _subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
    }
}