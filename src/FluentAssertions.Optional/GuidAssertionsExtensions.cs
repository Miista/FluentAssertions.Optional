using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    // ReSharper disable once UnusedType.Global
    public static class GuidAssertionsExtensions
    {
        [CustomAssertion]
        public static AndConstraint<GuidAssertions> Be(
            this GuidAssertions self,
            Option<Guid> expected,
            string because = "",
            params object[] becauseArgs
        ) =>
            self.Be(expected.ValueOrDefault(), because, becauseArgs);

        [CustomAssertion]
        public static AndConstraint<GuidAssertions> NotBe(
            this GuidAssertions self,
            Option<Guid> option,
            string because = "",
            params object[] becauseArgs
        ) =>
            self.NotBe(option.ValueOrDefault(), because, becauseArgs);
    }
}