using FluentAssertions.Execution;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public static class Ext
    {
        [CustomAssertion]
        public static void BeNone<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(!self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be None{reason} but found {0}.", self.Subject);
        }
        
        [CustomAssertion]
        public static AndConstraint<TAssertions> BeSome<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", self.Subject);

            return new AndConstraint<TAssertions>(self.ContinuedAssertions);
        }
        
        [CustomAssertion]
        public static AndConstraint<TAssertions> NotBeNone<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be None{reason} but found {0}.", self.Subject);
        
            return new AndConstraint<TAssertions>(self.ContinuedAssertions);
        }
        
        [CustomAssertion]
        public static void NotBeSome<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(!self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", self.Subject);
        }
        
        [CustomAssertion]
        public static AndWhichConstraint<TAssertions, TSubject> HaveValue<TSubject, TAssertions>(
            this IOptionAssertions<TSubject, TAssertions> self,
            string because = "",
            params object[] becauseArgs
        )
        {
            Execute.Assertion
                .ForCondition(self.Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", self.Subject);

            return new AndWhichConstraint<TAssertions, TSubject>(self.ContinuedAssertions, self.Subject.ValueOrDefault());
        }
    }
}