using FluentAssertions.Execution;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public abstract class OptionContinuedAssertions<T, TAssertions, TContinuedAssertions>
        where TAssertions : OptionContinuedAssertions<T, TAssertions, TContinuedAssertions>
    {
        private readonly TContinuedAssertions _assertions;
        protected readonly Option<T> Subject;

        protected OptionContinuedAssertions(Option<T> subject, TContinuedAssertions assertions)
        {
            _assertions = assertions;
            Subject = subject;
        }
        
        [CustomAssertion]
        public void Be(
            Option<T> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, Subject);
        }
        
        [CustomAssertion]
        public AndConstraint<TAssertions> NotBe(
            Option<T> other,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject != other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, Subject);
        
            return new AndConstraint<TAssertions>((TAssertions) this);
        }
        
        [CustomAssertion]
        public AndConstraint<TContinuedAssertions> BeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", Subject);

            return new AndConstraint<TContinuedAssertions>(_assertions);
        }
        
        [CustomAssertion]
        public void NotBeSome(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", Subject);
        }
        
        [CustomAssertion]
        public AndConstraint<TContinuedAssertions> BeSome(T expected, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject == Option.Some(expected))
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some({1}){reason} but found {0}.", Subject, expected);

            return new AndConstraint<TContinuedAssertions>(_assertions);
        }
        
        [CustomAssertion]
        public void BeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(!Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", Subject);
        }
        
        [CustomAssertion]
        public AndConstraint<TContinuedAssertions> NotBeNone(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", Subject);
        
            return new AndConstraint<TContinuedAssertions>(_assertions);
        }
        
        [CustomAssertion]
        public AndWhichConstraint<TContinuedAssertions, T> HaveValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", Subject);

            return new AndWhichConstraint<TContinuedAssertions, T>(_assertions, Subject.ValueOrDefault());
        }
    }
    
    // public abstract class OptionAssertions<T, TAssertions> where TAssertions : OptionAssertions<T, TAssertions>
    // {
    //     protected readonly Option<T> Subject;
    //
    //     protected OptionAssertions(Option<T> subject)
    //     {
    //         Subject = subject;
    //     }
    //
    //     [CustomAssertion]
    //     public AndConstraint<TAssertions> Be(
    //         Option<T> other,
    //         string because = "",
    //         params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(Subject == other)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:Option} to be {0}{reason}, but found {1}.", other, Subject);
    //         
    //         return new AndConstraint<TAssertions>((TAssertions) this);
    //     }
    //
    //     [CustomAssertion]
    //     public AndConstraint<TAssertions> NotBe(
    //         Option<T> other,
    //         string because = "",
    //         params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(Subject != other)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:Option} not to be {0}{reason}, but found {1}.", other, Subject);
    //
    //         return new AndConstraint<TAssertions>((TAssertions) this);
    //     }
    //
    //     [CustomAssertion]
    //     public AndWhichConstraint<TAssertions, T> HaveValue(string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(Subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} to be Some{reason} but found {0}.", Subject);
    //
    //         return new AndWhichConstraint<TAssertions, T>((TAssertions) this, Subject.ValueOrDefault());
    //     }
    //
    //     [CustomAssertion]
    //     public AndConstraint<TAssertions> BeNone(string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(!Subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} to be None{reason} but found {0}.");
    //         
    //         return new AndConstraint<TAssertions>((TAssertions) this);
    //     }
    //     
    //     [CustomAssertion]
    //     public AndConstraint<OptionAssertions<T, TAssertions>> NotBeNone(string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(Subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} not to be None{reason} but found {0}.", Subject);
    //
    //         return new AndConstraint<OptionAssertions<T, TAssertions>>(this);
    //     }
    //     
    //     [CustomAssertion]
    //     public AndConstraint<TAssertions> BeSome(string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(Subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} to be Some{reason} but found {0}.", Subject);
    //
    //         return new AndConstraint<TAssertions>((TAssertions) this);
    //     }
    //     
    //     [CustomAssertion]
    //     public AndConstraint<OptionAssertions<T, TAssertions>> NotBeSome(string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(!Subject.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", Subject);
    //
    //         return new AndConstraint<OptionAssertions<T, TAssertions>>(this);
    //     }
    // }
}