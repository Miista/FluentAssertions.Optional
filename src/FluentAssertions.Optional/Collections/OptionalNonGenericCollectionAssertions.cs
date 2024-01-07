using System;
using System.Collections;
using System.Linq.Expressions;
using FluentAssertions.Collections;
using FluentAssertions.Optional.Primitives;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Collections
{
    public class OptionalNonGenericCollectionAssertions : NonGenericCollectionAssertions, IOptionAssertions<IEnumerable, NonGenericCollectionAssertions>
    {
        public new Option<IEnumerable> Subject { get; }

        public NonGenericCollectionAssertions ContinuedAssertions => new NonGenericCollectionAssertions(Subject.ValueOrDefault());

        public OptionalNonGenericCollectionAssertions(Option<IEnumerable> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}