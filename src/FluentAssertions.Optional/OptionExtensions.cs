using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions.Optional;
using FluentAssertions.Optional.Collections;
using FluentAssertions.Optional.Numeric;
using FluentAssertions.Optional.Primitives;
using Optional;

// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
    public static class OptionExtensions
    {
        public static OptionalAssertions<T> Should<T>(this Option<T> instance) => new OptionalAssertions<T>(instance);
        
        public static OptionalObjectAssertions Should(this Option<object> instance) => new OptionalObjectAssertions(instance);
        
#region Collection Assertions
        public static OptionalGenericDictionaryAssertions<TKey, TValue> Should<TKey, TValue>(this Option<IDictionary<TKey, TValue>> instance) => new OptionalGenericDictionaryAssertions<TKey, TValue>(instance);
        public static OptionalStringCollectionAssertions Should(this Option<IEnumerable<string>> instance) => new OptionalStringCollectionAssertions(instance);
        public static OptionalGenericCollectionAssertions<T> Should<T>(this Option<IEnumerable<T>> instance) => new OptionalGenericCollectionAssertions<T>(instance);
        public static OptionalNonGenericCollectionAssertions Should(this Option<IEnumerable> instance) => new OptionalNonGenericCollectionAssertions(instance);
#endregion Collection Assertions
        
        public static OptionalGuidAssertions Should(this Option<Guid> instance) => new OptionalGuidAssertions(instance);
        public static OptionalNullableGuidAssertions Should(this Option<Guid?> instance) => new OptionalNullableGuidAssertions(instance);
        
        public static OptionalBooleanAssertions Should(this Option<bool> instance) => new OptionalBooleanAssertions(instance);
        public static OptionalNullableBooleanAssertions Should(this Option<bool?> instance) => new OptionalNullableBooleanAssertions(instance);
        
        public static OptionalStringAssertions Should(this Option<string> instance) => new OptionalStringAssertions(instance);
        
#region Numeric Assertions
        public static OptionalNumericAssertions<int> Should(this Option<int> instance) => new OptionalNumericAssertions<int>(instance);
        public static OptionalNumericAssertions<uint> Should(this Option<uint> instance) => new OptionalNumericAssertions<uint>(instance);
        public static OptionalNumericAssertions<long> Should(this Option<long> instance) => new OptionalNumericAssertions<long>(instance);
        public static OptionalNumericAssertions<ulong> Should(this Option<ulong> instance) => new OptionalNumericAssertions<ulong>(instance);
        public static OptionalNumericAssertions<short> Should(this Option<short> instance) => new OptionalNumericAssertions<short>(instance);
        public static OptionalNumericAssertions<ushort> Should(this Option<ushort> instance) => new OptionalNumericAssertions<ushort>(instance);
        public static OptionalNumericAssertions<byte> Should(this Option<byte> instance) => new OptionalNumericAssertions<byte>(instance);
        public static OptionalNumericAssertions<sbyte> Should(this Option<sbyte> instance) => new OptionalNumericAssertions<sbyte>(instance);
        public static OptionalNumericAssertions<float> Should(this Option<float> instance) => new OptionalNumericAssertions<float>(instance);
        public static OptionalNumericAssertions<double> Should(this Option<double> instance) => new OptionalNumericAssertions<double>(instance);
        public static OptionalNumericAssertions<decimal> Should(this Option<decimal> instance) => new OptionalNumericAssertions<decimal>(instance);
#endregion Numeric Assertions

#region Nullable Numeric Assertions
        public static OptionalNullableNumericAssertions<int> Should(this Option<int?> instance) => new OptionalNullableNumericAssertions<int>(instance);
        public static OptionalNullableNumericAssertions<uint> Should(this Option<uint?> instance) => new OptionalNullableNumericAssertions<uint>(instance);
        public static OptionalNullableNumericAssertions<long> Should(this Option<long?> instance) => new OptionalNullableNumericAssertions<long>(instance);
        public static OptionalNullableNumericAssertions<ulong> Should(this Option<ulong?> instance) => new OptionalNullableNumericAssertions<ulong>(instance);
        public static OptionalNullableNumericAssertions<short> Should(this Option<short?> instance) => new OptionalNullableNumericAssertions<short>(instance);
        public static OptionalNullableNumericAssertions<ushort> Should(this Option<ushort?> instance) => new OptionalNullableNumericAssertions<ushort>(instance);
        public static OptionalNullableNumericAssertions<byte> Should(this Option<byte?> instance) => new OptionalNullableNumericAssertions<byte>(instance);
        public static OptionalNullableNumericAssertions<sbyte> Should(this Option<sbyte?> instance) => new OptionalNullableNumericAssertions<sbyte>(instance);
        public static OptionalNullableNumericAssertions<float> Should(this Option<float?> instance) => new OptionalNullableNumericAssertions<float>(instance);
        public static OptionalNullableNumericAssertions<double> Should(this Option<double?> instance) => new OptionalNullableNumericAssertions<double>(instance);
        public static OptionalNullableNumericAssertions<decimal> Should(this Option<decimal?> instance) => new OptionalNullableNumericAssertions<decimal>(instance);
#endregion Nullable Numeric Assertions

        public static OptionalComparableTypeAssertions<T> Should<T>(this Option<IComparable<T>> comparableValue) => new OptionalComparableTypeAssertions<T>(comparableValue);
        
#region DateTime(Offset) + TimeSpan Assertions
        public static OptionalDateTimeAssertions Should(this Option<DateTime> instance) => new OptionalDateTimeAssertions(instance);
        public static OptionalNullableDateTimeAssertions Should(this Option<DateTime?> instance) => new OptionalNullableDateTimeAssertions(instance);
        
        public static OptionalDateTimeOffsetAssertions Should(this Option<DateTimeOffset> actualValue) => new OptionalDateTimeOffsetAssertions(actualValue);
        public static OptionalNullableDateTimeOffsetAssertions Should(this Option<DateTimeOffset?> actualValue) => new OptionalNullableDateTimeOffsetAssertions(actualValue);
        
        public static OptionalNullableSimpleTimeSpanAssertions Should(this Option<TimeSpan?> actualValue) => new OptionalNullableSimpleTimeSpanAssertions(actualValue);
        public static OptionalSimpleTimeSpanAssertions Should(this Option<TimeSpan> actualValue) => new OptionalSimpleTimeSpanAssertions(actualValue);
#endregion DateTime(Offset) + TimeSpan Assertions

        public static OptionEitherExceptionAssertions<T> Should<T>(this Option<T, Exception> instance) => new OptionEitherExceptionAssertions<T>(instance);
        
        public static OptionEitherAssertions<T, TException> Should<T, TException>(this Option<T, TException> instance) => new OptionEitherAssertions<T, TException>(instance);
    }
}