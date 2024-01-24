using System.Collections.Generic;
using FluentAssertions.Collections;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Collections
{
    public class OptionalStringCollectionAssertions : StringCollectionAssertions, IOptionAssertions<IEnumerable<string>, StringCollectionAssertions>
    {
        public new Option<IEnumerable<string>> Subject { get; }

        public StringCollectionAssertions ContinuedAssertions => new StringCollectionAssertions(Subject.ValueOrDefault());

        public OptionalStringCollectionAssertions(Option<IEnumerable<string>> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}