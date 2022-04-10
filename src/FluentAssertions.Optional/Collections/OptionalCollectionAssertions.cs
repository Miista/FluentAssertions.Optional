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
    
    public AndConstraint<TAssertions> BeInAscendingOrder(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().BeInAscendingOrder(because, becauseArgs);

    /// <summary>
    /// Expects the current collection to have all elements in ascending order. Elements are compared
    /// using the given <see cref="T:System.Collections.Generic.IComparer`1" /> implementation.
    /// </summary>
    /// <param name="comparer">
    /// The object that should be used to determine the expected ordering.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> BeInAscendingOrder(
      IComparer<object> comparer,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().BeInAscendingOrder(comparer, because, becauseArgs);

    /// <summary>
    /// Expects the current collection to have all elements in descending order. Elements are compared
    /// using their <see cref="M:System.IComparable.CompareTo(System.Object)" /> implementation.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> BeInDescendingOrder(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().BeInDescendingOrder(because, becauseArgs);

    /// <summary>
    /// Expects the current collection to have all elements in descending order. Elements are compared
    /// using the given <see cref="T:System.Collections.Generic.IComparer`1" /> implementation.
    /// </summary>
    /// <param name="comparer">
    /// The object that should be used to determine the expected ordering.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> BeInDescendingOrder(
      IComparer<object> comparer,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().BeInDescendingOrder(comparer, because, becauseArgs);

    /// <summary>
    /// Asserts the current collection does not have all elements in ascending order. Elements are compared
    /// using their <see cref="M:System.IComparable.CompareTo(System.Object)" /> implementation.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeAscendingInOrder(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotBeAscendingInOrder(because, becauseArgs);

    /// <summary>
    /// Asserts the current collection does not have all elements in ascending order. Elements are compared
    /// using their <see cref="M:System.IComparable.CompareTo(System.Object)" /> implementation.
    /// </summary>
    /// <param name="comparer">
    /// The object that should be used to determine the expected ordering.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeAscendingInOrder(
      IComparer<object> comparer,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotBeAscendingInOrder(comparer, because, becauseArgs);

    /// <summary>
    /// Asserts the current collection does not have all elements in descending order. Elements are compared
    /// using their <see cref="M:System.IComparable.CompareTo(System.Object)" /> implementation.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeDescendingInOrder(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotBeDescendingInOrder(because, becauseArgs);

    /// <summary>
    /// Asserts the current collection does not have all elements in descending order. Elements are compared
    /// using their <see cref="M:System.IComparable.CompareTo(System.Object)" /> implementation.
    /// </summary>
    /// <param name="comparer">
    /// The object that should be used to determine the expected ordering.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeDescendingInOrder(
      IComparer<object> comparer,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotBeDescendingInOrder(comparer);

    /// <summary>
    /// Asserts that the collection is a subset of the <paramref name="expectedSuperset" />.
    /// </summary>
    /// <param name="expectedSuperset">An <see cref="T:System.Collections.IEnumerable" /> with the expected superset.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> BeSubsetOf(
      IEnumerable expectedSuperset,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().BeSubsetOf(expectedSuperset, because, becauseArgs);

    /// <summary>
    /// Asserts that the collection is not a subset of the <paramref name="unexpectedSuperset" />.
    /// </summary>
    /// <param name="unexpectedSuperset">An <see cref="T:System.Collections.IEnumerable" /> with the unexpected superset.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotBeSubsetOf(
      IEnumerable unexpectedSuperset,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotBeSubsetOf(unexpectedSuperset, because, becauseArgs);

    /// <summary>
    /// Assert that the current collection has the same number of elements as <paramref name="otherCollection" />.
    /// </summary>
    /// <param name="otherCollection">The other collection with the same expected number of elements</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> HaveSameCount(
      IEnumerable otherCollection,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().HaveSameCount(otherCollection, because, becauseArgs);

    /// <summary>
    /// Assert that the current collection does not have the same number of elements as <paramref name="otherCollection" />.
    /// </summary>
    /// <param name="otherCollection">The other collection with the unexpected number of elements</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotHaveSameCount(
      IEnumerable otherCollection,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotHaveSameCount(otherCollection, because, becauseArgs);

    /// <summary>
    /// Asserts that the current collection has the supplied <paramref name="element" /> at the
    /// supplied <paramref name="index" />.
    /// </summary>
    /// <param name="index">The index where the element is expected</param>
    /// <param name="element">The expected element</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndWhichConstraint<TAssertions, object> HaveElementAt(
      int index,
      object element,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().HaveElementAt(index, element, because, becauseArgs);

    /// <summary>
    /// Asserts that the current collection does not contain the supplied items. Elements are compared
    /// using their <see cref="M:System.Object.Equals(System.Object)" /> implementation.
    /// </summary>
    /// <param name="unexpected">An <see cref="T:System.Collections.IEnumerable" /> with the unexpected elements.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotContain(
      IEnumerable unexpected,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotContain(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the collection shares one or more items with the specified <paramref name="otherCollection" />.
    /// </summary>
    /// <param name="otherCollection">The <see cref="T:System.Collections.IEnumerable" /> with the expected shared items.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> IntersectWith(
      IEnumerable otherCollection,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().IntersectWith(otherCollection, because, becauseArgs);

    /// <summary>
    /// Asserts that the collection does not share any items with the specified <paramref name="otherCollection" />.
    /// </summary>
    /// <param name="otherCollection">The <see cref="T:System.Collections.IEnumerable" /> to compare to.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> NotIntersectWith(
      IEnumerable otherCollection,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().NotIntersectWith(otherCollection, because, becauseArgs);

    /// <summary>
    /// Asserts that the collection starts with the specified <paramref name="element" />.
    /// </summary>
    /// <param name="element">
    /// The element that is expected to appear at the start of the collection. The object's <see cref="M:System.Object.Equals(System.Object)" />
    /// is used to compare the element.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> StartWith(
      object element,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().StartWith(element, because, becauseArgs);

    /// <summary>
    /// Asserts that the collection ends with the specified <paramref name="element" />.
    /// </summary>
    /// <param name="element">
    /// The element that is expected to appear at the end of the collection. The object's <see cref="M:System.Object.Equals(System.Object)" />
    /// is used to compare the element.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> EndWith(
      object element,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().EndWith(element, because, becauseArgs);

    /// <summary>
    /// Asserts that the <paramref name="expectation" /> element directly precedes the <paramref name="successor" />.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> HaveElementPreceding(
      object successor,
      object expectation,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().HaveElementPreceding(successor, expectation, because, becauseArgs);

    /// <summary>
    /// Asserts that the <paramref name="expectation" /> element directly succeeds the <paramref name="predecessor" />.
    /// </summary>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> HaveElementSucceeding(
      object predecessor,
      object expectation,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().HaveElementSucceeding(predecessor, expectation, because, becauseArgs);

    /// <summary>
    /// Asserts that all items in the collection are of the specified type <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The expected type of the objects</typeparam>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> AllBeAssignableTo<T>(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().AllBeAssignableTo<T>(because, becauseArgs);

    /// <summary>
    /// Asserts that all items in the collection are of the specified type <paramref name="expectedType" />
    /// </summary>
    /// <param name="expectedType">The expected type of the objects</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> AllBeAssignableTo(
      Type expectedType,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().AllBeAssignableTo(expectedType, because, becauseArgs);

    /// <summary>
    /// Asserts that all items in the collection are of the exact specified type <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T">The expected type of the objects</typeparam>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> AllBeOfType<T>(
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().AllBeOfType<T>(because, becauseArgs);

    /// <summary>
    /// Asserts that all items in the collection are of the exact specified type <paramref name="expectedType" />
    /// </summary>
    /// <param name="expectedType">The expected type of the objects</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<TAssertions> AllBeOfType(
      Type expectedType,
      string because = "",
      params object[] becauseArgs) => HaveValueAnd().AllBeOfType(expectedType, because, becauseArgs);

    private TAssertions HaveValueAnd()
    {
      HaveValue();
      return _assertions;
    }
  }
}