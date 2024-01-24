using System.Collections.Generic;
using FluentAssertions.Collections;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Collections
{
    public class OptionalGenericCollectionAssertions<TSubject> : GenericCollectionAssertions<TSubject>, IOptionAssertions<IEnumerable<TSubject>, GenericCollectionAssertions<TSubject>>
    {
        public OptionalGenericCollectionAssertions(Option<IEnumerable<TSubject>> subject)
            : base(subject.ValueOrDefault())
        {
            Subject = subject;
        }

        public new Option<IEnumerable<TSubject>> Subject { get; }

        public GenericCollectionAssertions<TSubject> ContinuedAssertions =>
            new GenericCollectionAssertions<TSubject>(Subject.ValueOrDefault());
    }
}