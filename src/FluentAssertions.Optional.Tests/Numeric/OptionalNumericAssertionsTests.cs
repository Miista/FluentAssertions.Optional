using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Numeric
{
    public class OptionalNumericAssertionsTests
    {
        public class BePositiveTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = 1;
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().BePositive();
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var value = -1;
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().BePositive();
                
                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeNegativeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = (-1).Some();

                // Act
                Action act = () => value.Should().BeNegative();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var value = 1.Some();

                // Act
                Action act = () => value.Should().BeNegative();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeLessThanTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = 1.Some();

                // Act
                Action act = () => value.Should().BeLessThan(2);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var value = 2.Some();

                // Act
                Action act = () => value.Should().BeLessThan(1);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeLessOrEqualToTests
        {
            [Theory]
            [InlineData(1, 1)]
            [InlineData(1, 2)]
            public void Does_not_throw(int value, int lessOrEqualTo)
            {
                // Arrange
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().BeLessOrEqualTo(lessOrEqualTo);
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 2.Some();
                
                // Act
                Action act = () => option.Should().BeLessOrEqualTo(1);
                
                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeGreaterThanTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeGreaterThan(0);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeGreaterThan(2);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeGreaterOrEqualToTests
        {
            [Theory]
            [InlineData(2, 1)]
            [InlineData(2, 2)]
            public void Does_not_throw(int value, int greaterOrEqualTo)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().BeGreaterOrEqualTo(greaterOrEqualTo);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 2.Some();

                // Act
                Action act = () => option.Should().BeGreaterOrEqualTo(3);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeInRangeTests
        {
            [Theory]
            [InlineData(1, 0, 2)]
            [InlineData(1, 1, 1)]
            public void Does_not_throw(int value, int minimumValue, int maximumValue)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().BeInRange(minimumValue, maximumValue);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeInRange(2, 3);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class NotBeInRangeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().NotBeInRange(2, 3);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(1, 0, 2)]
            [InlineData(1, 1, 1)]
            public void Throws(int value, int minimumValue, int maximumValue)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().NotBeInRange(minimumValue, maximumValue);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeOneOfTests
        {
            [Theory]
            [InlineData(1, new []{1,2,3})]
            [InlineData(2, new []{1,2,3})]
            [InlineData(3, new []{1,2,3})]
            public void Does_not_throw(int value, int[] validValues)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().BeOneOf(validValues);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeOneOf(2, 3);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeOfTypeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeOfType(typeof(int));

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().BeOfType(typeof(double));

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class NotBeOfTypeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().NotBeOfType(typeof(double));

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().NotBeOfType(typeof(int));

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = 1;
                var option = value.Some();
                
                // Act
                Action act = () => value.Should().Be(option);
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var value = "Value";
                var option = "World".Some();
                
                // Act
                Action act = () => value.Should().Be(option);
                
                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class NotBeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = "Value";
                var option = "World".Some();
                
                // Act
                Action act = () => value.Should().NotBe(option);
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var value = "Value";
                var option = value.Some();
                
                // Act
                Action act = () => value.Should().NotBe(option);
                
                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class MatchTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().Match(i => i == 1);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = 1.Some();

                // Act
                Action act = () => option.Should().Match(i => i == 2);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}