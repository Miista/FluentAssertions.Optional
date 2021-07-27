using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Specialized;
using Optional;

namespace FluentAssertions.Optional
{
  public class OptionEitherExceptionAssertions<T> : OptionEitherAssertions<T, Exception>
  {
    public OptionEitherExceptionAssertions(Option<T, Exception> subject) : base(subject)
    {
    }
        
    [CustomAssertion]
    public ExceptionAssertions<Exception> HaveException(string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(!Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} to have exception{reason} but found {0}.", Subject);

      var exception = default(Exception);
      Subject.MapException(actualException => exception = actualException);
            
      return new ExceptionAssertions<Exception>(new List<Exception>{exception});
    }
        
    [CustomAssertion]
    public void NotHaveException(string because = "", params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} not to have exception{reason} but found {0}.", Subject);
    }
  }
}