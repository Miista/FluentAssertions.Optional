using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions.Collections;
using FluentAssertions.Equivalency;
using Optional;

namespace FluentAssertions.Optional.Collections
{
  public abstract class OptionalCollectionAssertions<TSubject, TAssertions> : OptionContinuedAssertions<TSubject, OptionalCollectionAssertions<TSubject, TAssertions>, TAssertions>
    where TSubject : IEnumerable
    where TAssertions : CollectionAssertions<TSubject, TAssertions>
  {
    private readonly TAssertions _assertions;
        
    protected OptionalCollectionAssertions(Option<TSubject> subject, TAssertions assertions) : base(subject, assertions)
    {
      _assertions = assertions ?? throw new ArgumentNullException(nameof(assertions));
    }

    public AndConstraint<TAssertions> BeEmpty(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeEmpty(because, becauseArgs);
        
    public AndConstraint<TAssertions> NotBeEmpty(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().NotBeEmpty(because, becauseArgs);

    public AndConstraint<TAssertions> BeNullOrEmpty(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeNullOrEmpty(because, becauseArgs);
        
    public AndConstraint<TAssertions> NotBeNullOrEmpty(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().NotBeNullOrEmpty(because, becauseArgs);

    public AndConstraint<TAssertions> OnlyHaveUniqueItems(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().OnlyHaveUniqueItems(because, becauseArgs);

    public AndConstraint<TAssertions> NotContainNulls(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().NotContainNulls(because, becauseArgs);

    public AndConstraint<TAssertions> Equal(params object[] elements) =>
      HaveValueAnd().Equal(elements);

    public AndConstraint<TAssertions> Equal(
      IEnumerable expected,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().Equal(expected, because, becauseArgs);

    public AndConstraint<TAssertions> NotEqual(
      IEnumerable unexpected,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().NotEqual(unexpected, because, becauseArgs);

    public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(
      IEnumerable<TExpectation> expectation,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeEquivalentTo(expectation, because, becauseArgs);

    public AndConstraint<TAssertions> BeEquivalentTo(params object[] expectations) =>
      HaveValueAnd().BeEquivalentTo(expectations);

    public AndConstraint<TAssertions> BeEquivalentTo(
      IEnumerable expectation,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeEquivalentTo(expectation, because, becauseArgs);

    public AndConstraint<TAssertions> BeEquivalentTo(
      IEnumerable expectation,
      Func<EquivalencyAssertionOptions<IEnumerable>, EquivalencyAssertionOptions<IEnumerable>> config,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeEquivalentTo(expectation, config, because, becauseArgs);

    public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(
      IEnumerable<TExpectation> expectation,
      Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>> config,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeEquivalentTo(expectation, config, because, becauseArgs);

    public AndConstraint<TAssertions> NotBeEquivalentTo(
      IEnumerable unexpected,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().NotBeEquivalentTo(unexpected, because, becauseArgs);

    public AndConstraint<TAssertions> ContainEquivalentOf<TExpectation>(
      TExpectation expectation,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().ContainEquivalentOf(expectation, because, becauseArgs);

    public AndConstraint<TAssertions> ContainEquivalentOf<TExpectation>(
      TExpectation expectation,
      Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>> config,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().ContainEquivalentOf(expectation, config, because, becauseArgs);

    public AndConstraint<TAssertions> ContainItemsAssignableTo<T>(
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().ContainItemsAssignableTo<T>(because, becauseArgs);

    public AndConstraint<TAssertions> Contain(
      IEnumerable expected,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().Contain(expected, because, becauseArgs);

    public AndConstraint<TAssertions> ContainInOrder(
      params object[] expected) =>
      HaveValueAnd().ContainInOrder(expected);

    public AndConstraint<TAssertions> ContainInOrder(
      IEnumerable expected,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().ContainInOrder(expected, because, becauseArgs);
    
    private TAssertions HaveValueAnd()
    {
      HaveValue();
      return _assertions;
    }
  }
}