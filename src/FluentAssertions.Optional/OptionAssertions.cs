using FluentAssertions.Execution;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public class OptionAssertions<T>
    {
        private readonly Option<T> _subject;

        public OptionAssertions(Option<T> subject)
        {
            _subject = subject;
        }

        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> Be(
            Option<T> other,
            string because = "",
            params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(_subject == other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, _subject);
            
            return new AndConstraint<OptionAssertions<T>>(this);
        }

        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> NotBe(
            Option<T> other,
            string because = "",
            params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(_subject != other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, _subject);

            return new AndConstraint<OptionAssertions<T>>(this);
        }

        [CustomAssertion]
        public AndWhichConstraint<OptionAssertions<T>, T> HaveValue(string because = "", params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", _subject);

            return new AndWhichConstraint<OptionAssertions<T>, T>(this, _subject.ValueOrDefault());
        }

        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", _subject);

            return new AndConstraint<OptionAssertions<T>>(this);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> NotBeNone(string because = "", params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", _subject);

            return new AndConstraint<OptionAssertions<T>>(this);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> BeSome(string because = "", params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", _subject);

            return new AndConstraint<OptionAssertions<T>>(this);
        }
        
        [CustomAssertion]
        public AndConstraint<OptionAssertions<T>> NotBeSome(string because = "", params object[] becauseArgs)
        {
            var assertion = Execute.Assertion;

            assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", _subject);

            return new AndConstraint<OptionAssertions<T>>(this);
        }
    }
}