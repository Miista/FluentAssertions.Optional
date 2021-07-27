using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Collections
{
    public class OptionalNonGenericCollectionAssertionsTests
    {
        public class HaveCountTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCount(length);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCount(1 + length);

                // Assert
                act.Should().Throw<XunitException>();
            }

            public class ExpressionTests
            {
                [Theory]
                [InlineData(0)]
                [InlineData(1)]
                [InlineData(5)]
                public void Does_not_throw(int length)
                {
                    // Arrange
                    var enumerable = Enumerable.Repeat(default(int), length).ToList();
                    var option = (enumerable as IEnumerable).Some();

                    // Act
                    Action act = () => option.Should().HaveCount(i => i == enumerable.Count);

                    // Assert
                    act.Should().NotThrow<XunitException>();
                }

                [Theory]
                [InlineData(0)]
                [InlineData(1)]
                [InlineData(5)]
                public void Throws(int length)
                {
                    var enumerable = Enumerable.Repeat(default(int), length).ToList();
                    var option = (enumerable as IEnumerable).Some();

                    // Act
                    Action act = () => option.Should().HaveCount(i => i != enumerable.Count);

                    // Assert
                    act.Should().Throw<XunitException>();
                }
            }
        }
        
        public class NotHaveCountTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().NotHaveCount(1 + length);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().NotHaveCount(length);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class HaveCountGreaterThanTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountGreaterThan(length - 1);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountGreaterThan(length);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class HaveCountGreaterOrEqualToTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action equalTo = () => enumerable.Should().HaveCountGreaterOrEqualTo(length);
                Action greater = () => enumerable.Should().HaveCountGreaterOrEqualTo(length - 1);

                // Assert
                equalTo.Should().NotThrow<XunitException>();
                greater.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountGreaterOrEqualTo(1 + length);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class HaveCountLessThanTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountLessThan(1 + length);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountLessThan(length);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class HaveCountLessOrEqualToTests
        {
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(5)]
            public void Does_not_throw(int length)
            {
                // Arrange
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action equalTo = () => enumerable.Should().HaveCountLessOrEqualTo(length);
                Action less = () => enumerable.Should().HaveCountLessOrEqualTo(1 + length);

                // Assert
                equalTo.Should().NotThrow<XunitException>();
                less.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(1)]
            [InlineData(5)]
            public void Throws(int length)
            {
                var enumerable = (Enumerable.Repeat(default(int), length) as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().HaveCountLessOrEqualTo(length - 1);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class ContainTests
        {
            [Theory]
            [InlineData(new []{0, 1, 2}, 0)]
            [InlineData(new []{0, 1, 2}, 1)]
            [InlineData(new []{0, 1, 2}, 2)]
            public void Does_not_throw(int[] values, int expectedValue)
            {
                // Arrange
                var enumerable = (values as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().Contain(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                var enumerable = (new []{0,1,2} as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().Contain(3);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class NotContainTests
        {
            [Theory]
            [InlineData(new []{0}, 1)]
            [InlineData(new []{0, 1}, 2)]
            [InlineData(new []{0, 1, 2}, 3)]
            public void Does_not_throw(int[] values, int expectedValue)
            {
                // Arrange
                var enumerable = (values as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().NotContain(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                var enumerable = (new []{0,1,2} as IEnumerable).Some();

                // Act
                Action act = () => enumerable.Should().NotContain(2);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}