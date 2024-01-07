using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Collections
{
    public class OptionalGenericCollectionAssertionsTests
    {
                public class BeEmptyTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var enumerable = Enumerable.Empty<int>().Some();

                // Act
                Action act = () => enumerable.Should().BeEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var enumerable = Enumerable.Repeat(1, 1).Some();

                // Act
                Action act = () => enumerable.Should().BeEmpty();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class NotBeEmptyTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var enumerable = Enumerable.Repeat(1, 1).Some();

                // Act
                Action act = () => enumerable.Should().NotBeEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var enumerable = (Enumerable.Empty<int>() ).Some();

                // Act
                Action act = () => enumerable.Should().NotBeEmpty();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class BeNullOrEmptyTests
        {
            [Theory]
            [InlineData(null)]
            [InlineData(new int[0])]
            public void Does_not_throw(IEnumerable values)
            {
                // Arrange
                var enumerable = values.Some();

                // Act
                Action act = () => enumerable.Should().BeNullOrEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var enumerable = (new[] {1} as IEnumerable<int>).Some();

                // Act
                Action act = () => enumerable.Should().BeNullOrEmpty();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class NotBeNullOrEmptyTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var enumerable = (new[] {1} as IEnumerable<int>).Some();

                // Act
                Action act = () => enumerable.Should().NotBeNullOrEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(null)]
            [InlineData(new int[0])]
            public void Throws(IEnumerable values)
            {
                // Arrange
                var enumerable = values.Some();

                // Act
                Action act = () => enumerable.Should().NotBeNullOrEmpty();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class OnlyHaveUniqueItemsTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                // Act
                Action act = () => enumerable.Should().OnlyHaveUniqueItems();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var enumerable = (new[] {1, 1} as IEnumerable<int>).Some();

                // Act
                Action act = () => enumerable.Should().OnlyHaveUniqueItems();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class NotContainNullsTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                // Act
                Action act = () => enumerable.Should().NotContainNulls();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var enumerable = (new object[] {null} as IEnumerable<object>).Some();

                // Act
                Action act = () => enumerable.Should().NotContainNulls();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class EqualTests
        {
            public class ParamsTests
            {
                [Fact]
                public void Does_not_throw()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().Equal(1, 2, 3);

                    // Assert
                    act.Should().NotThrow<XunitException>();
                }

                [Fact]
                public void Throws()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().Equal(3, 2, 1);

                    // Assert
                    act.Should().Throw<XunitException>();
                }
            }
            
            // ReSharper disable once InconsistentNaming
            public class IEnumerableTests
            {
                [Fact]
                public void Does_not_throw()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().Equal(new[] {1, 2, 3});

                    // Assert
                    act.Should().NotThrow<XunitException>();
                }

                [Fact]
                public void Throws()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().Equal(new[] {3, 2, 1});

                    // Assert
                    act.Should().Throw<XunitException>();
                }
            }
        }
        
        public class NotEqualTests
        {
            // ReSharper disable once InconsistentNaming
            public class IEnumerableTests
            {
                [Fact]
                public void Does_not_throw()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().NotEqual(new[] {3, 2, 1});

                    // Assert
                    act.Should().NotThrow<XunitException>();
                }

                [Fact]
                public void Throws()
                {
                    // Arrange
                    var enumerable = (new[] {1,2,3} as IEnumerable<int>).Some();

                    // Act
                    Action act = () => enumerable.Should().NotEqual(new[] {1, 2, 3});                    

                    // Assert
                    act.Should().Throw<XunitException>();
                }
            }
        }
        
        public class BeEquivalentToTests
        {
            // ReSharper disable once InconsistentNaming
            public class NonGenericEnumerableTests
            {
                [Theory]
                [InlineData(new[]{1,2,3}, new []{1,2,3})]
                [InlineData(new[]{1,2,3}, new []{1,3,2})]
                [InlineData(new[]{1,2,3}, new []{2,1,3})]
                [InlineData(new[]{1,2,3}, new []{2,3,1})]
                [InlineData(new[]{1,2,3}, new []{3,1,2})]
                [InlineData(new[]{1,2,3}, new []{3,2,1})]
                public void Does_not_throw(int[] values, int[] expectedValues)
                {
                    // Arrange
                    var enumerable = (values as IEnumerable<int>).Some();
                    var expected = expectedValues as IEnumerable<int>;

                    // Act
                    Action act = () => enumerable.Should().BeEquivalentTo(expected);

                    // Assert
                    act.Should().NotThrow<XunitException>();
                }

                [Fact]
                public void Throws()
                {
                    // Arrange
                    var enumerable = (new[] {1, 2, 3} as IEnumerable<int>).Some();
                    var unexpected = new[] {3, 1} as IEnumerable<int>;

                    // Act
                    Action act = () => enumerable.Should().BeEquivalentTo(unexpected);                    

                    // Assert
                    act.Should().Throw<XunitException>();
                }
            }
        }
    }
}