using FluentAssertions.Execution;

namespace FluentAssertions.Optional
{
  public static class OptionAssertionExtensions
  {
    [CustomAssertion]
    public static void HaveValue<T>(
      this IOptionAssertions<T> assertions,
      string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(assertions.Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} to be Some{reason} but found {0}.", assertions.Subject);
    }

    [CustomAssertion]
    public static void BeNone<T>(
      this IOptionAssertions<T> assertions,
      string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(!assertions.Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} to be None{reason} but found {0}.", assertions.Subject);
    }

    [CustomAssertion]
    public static void NotBeNone<T>(
      this IOptionAssertions<T> assertions,
      string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(assertions.Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} not to be None{reason} but found {0}.", assertions.Subject);
    }

    [CustomAssertion]
    public static void BeSome<T>(
      this IOptionAssertions<T> assertions,
      string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(assertions.Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} to be Some{reason} but found {0}.", assertions.Subject);
    }

    [CustomAssertion]
    public static void NotBeSome<T>(
      this IOptionAssertions<T> assertions,
      string because = "",
      params object[] becauseArgs)
    {
      Execute.Assertion
        .ForCondition(!assertions.Subject.HasValue)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:option} not to be Some{reason} but found {0}.", assertions.Subject);
    }
  }
}