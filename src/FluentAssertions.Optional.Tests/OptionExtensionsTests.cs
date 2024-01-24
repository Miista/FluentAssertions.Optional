using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Optional.Collections;
using FluentAssertions.Optional.Numeric;
using FluentAssertions.Optional.Primitives;
using Optional;
using Xunit;

namespace FluentAssertions.Optional.Tests
{
    public class OptionExtensionsTests
    {
        [Theory]
        [MemberData(nameof(Test_Data))]
        public void Calling_Should_on_an_option_starts_optional_assertions<TEntity, TAssertions>(
            Option<TEntity> entity,
            Func<Option<TEntity>, TAssertions> transformer,
            TAssertions assertions
        )
            where TAssertions : class
        {
            // Act
            var optionalAssertions = transformer(entity);

            // Assert
            optionalAssertions.Should().NotBeNull(because: "the assertions is of type {0}", typeof(TAssertions));
            optionalAssertions.GetType().Should().BeAssignableTo<TAssertions>();
        }

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<object[]> Test_Data
        {
            get
            {
                yield return TestCase(
                    Enumerable.Empty<int>(),
                    opt => opt.Should(),
                    new OptionalGenericCollectionAssertions<int>(Option.None<IEnumerable<int>>())
                );
                
                yield return TestCase(
                    Enumerable.Empty<int>() as IEnumerable,
                    opt => opt.Should(),
                    new OptionalNonGenericCollectionAssertions(Option.None<IEnumerable>())
                );
                
                yield return TestCase(
                    Enumerable.Empty<string>(),
                    opt => opt.Should(),
                    new OptionalStringCollectionAssertions(Option.None<IEnumerable<string>>())
                );
                
                yield return TestCase(
                    string.Empty as object,
                    opt => opt.Should(),
                    new OptionalObjectAssertions(Option.None<object>())
                );
                
                yield return TestCase(
                    string.Empty,
                    opt => opt.Should(),
                    new OptionalStringAssertions(Option.None<string>())
                );
                
                yield return TestCase(
                    Guid.Empty,
                    opt => opt.Should(),
                    new OptionalGuidAssertions(Option.None<Guid>())
                );
                
                yield return TestCase(
                    null as Guid?,
                    opt => opt.Should(),
                    new OptionalNullableGuidAssertions(Option.None<Guid?>())
                );
                
                yield return TestCase(
                    true,
                    opt => opt.Should(),
                    new OptionalBooleanAssertions(Option.None<bool>())
                );
                
                yield return TestCase(
                    null as bool?,
                    opt => opt.Should(),
                    new OptionalNullableBooleanAssertions(Option.None<bool?>())
                );
                
                yield return TestCase(
                    new Dictionary<string, string>() as IDictionary<string, string>,
                    opt => opt.Should(),
                    new OptionalGenericDictionaryAssertions<string, string>(Option.None<IDictionary<string, string>>())
                );
                
                yield return TestCase(
                    default(int),
                    opt => opt.Should(),
                    new OptionalNumericAssertions<int>(Option.None<int>())
                );
                
                yield return TestCase(
                    default(double),
                    opt => opt.Should(),
                    new OptionalNumericAssertions<double>(Option.None<double>())
                );
                
                yield return TestCase(
                    default(long),
                    opt => opt.Should(),
                    new OptionalNumericAssertions<long>(Option.None<long>())
                );

                yield return TestCase(
                    default(DateTime),
                    opt => opt.Should(),
                    new OptionalDateTimeAssertions(Option.None<DateTime>())
                );
                
                yield return TestCase(
                    default(DateTime?),
                    opt => opt.Should(),
                    new OptionalNullableDateTimeAssertions(Option.None<DateTime?>())
                );

                yield return TestCase(
                    default(DateTimeOffset),
                    opt => opt.Should(),
                    new OptionalDateTimeOffsetAssertions(Option.None<DateTimeOffset>())
                );
                
                yield return TestCase(
                    default(DateTimeOffset?),
                    opt => opt.Should(),
                    new OptionalNullableDateTimeOffsetAssertions(Option.None<DateTimeOffset?>())
                );
                
                yield return TestCase(
                    default(TimeSpan),
                    opt => opt.Should(),
                    new OptionalSimpleTimeSpanAssertions(Option.None<TimeSpan>())
                );
                
                yield return TestCase(
                    default(TimeSpan?),
                    opt => opt.Should(),
                    new OptionalNullableSimpleTimeSpanAssertions(Option.None<TimeSpan?>())
                );

                object[] TestCase<T, TAssertions>(
                    T entity,
                    Func<Option<T>, TAssertions> transformer,
                    TAssertions assertions
                )
                {
                    return new object[] { entity.Some(), transformer, assertions };
                }
            }
        }
    }
}