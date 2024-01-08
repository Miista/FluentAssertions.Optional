using System;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public static class NullableGuidAssertionsExtensions
    {
        [CustomAssertion]
        public static AndConstraint<NullableGuidAssertions> Be(
            this NullableGuidAssertions self,
            Option<Guid?> expected,
            string because = "",
            params object[] becauseArgs
        ) =>
            self.Be(expected.ValueOrDefault(), because, becauseArgs);
    }
}