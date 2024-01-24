using System.Collections.Generic;
using FluentAssertions.Collections;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Collections
{
    public class OptionalGenericDictionaryAssertions<TKey, TValue> : GenericDictionaryAssertions<TKey, TValue>, IOptionAssertions<IDictionary<TKey, TValue>, GenericDictionaryAssertions<TKey, TValue>>
    {
        public new Option<IDictionary<TKey, TValue>> Subject { get; }

        public GenericDictionaryAssertions<TKey, TValue> ContinuedAssertions => new GenericDictionaryAssertions<TKey, TValue>(Subject.ValueOrDefault());

        public OptionalGenericDictionaryAssertions(Option<IDictionary<TKey, TValue>> value) : base(value.ValueOrDefault())
        {
            Subject = value;
        }
    }
}