using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Specialized;
using Optional;

namespace FluentAssertions.Optional
{
    // public static class OptionEitherAssertionExtensions
    // {
    //     public static ExceptionAssertions<TException> HaveException<T, TException>(
    //         this OptionEitherAssertions<T, TException> assertions,
    //         string because = "",
    //         params object[] becauseArgs)
    //         where TException : Exception
    //     {
    //         Execute.Assertion
    //             .ForCondition(!assertions._subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} to be None{reason} but found {0}.", assertions._subject);
    //         
    //         TException exception = null;
    //         assertions._subject.MatchNone(ex => exception = ex);
    //         
    //         return new ExceptionAssertions<TException>(new []{exception});
    //     }
    // }
    
    public class OptionEitherAssertions<T, TException>
    {
        internal readonly Option<T, TException> _subject;

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
        public ExceptionAssertions<TExpectedException> HaveException<TExpectedException>(string because = "", params object[] becauseArgs) where TExpectedException : Exception, TException
        {
            Execute.Assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to have exception{reason} but found {0}.", _subject);

            TException _exception = default(TException);
            _subject.MapException(ex => _exception = ex);
            
            return new ExceptionAssertions<TExpectedException>(new List<TExpectedException>{(TExpectedException) _exception});
        }
        
        [CustomAssertion]
        public void NotHaveException(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to have exception{reason} but found {0}.", _subject);
        }
        
        [CustomAssertion]
        public AndWhichConstraint<OptionEitherAssertions<T, TException>, TException> HaveAlternateValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to have alternate value{reason} but found {0}.", _subject);

            TException _exception = default(TException);
            _subject.MapException(ex => _exception = ex);
            
            return new AndWhichConstraint<OptionEitherAssertions<T, TException>, TException>(this, _exception);
        }
        
        [CustomAssertion]
        public void NotHaveAlternateValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to have alternate value{reason} but found {0}.", _subject);
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
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", _subject);

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

        [CustomAssertion]
        public AndConstraint<OptionEitherAssertions<T, TException>> NotBeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!_subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", _subject);

            return new AndConstraint<OptionEitherAssertions<T, TException>>(this);
        }
    }
}