using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Primitives
{
    public class OptionalBooleanAssertionsTests
    {
        public class BeTrueTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = true.Some();

                // Act
                Action act = () => option.Should().BeTrue();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = false.Some();

                // Act
                Action act = () => option.Should().BeTrue();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeFalseTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = false.Some();

                // Act
                Action act = () => option.Should().BeFalse();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = true.Some();

                // Act
                Action act = () => option.Should().BeFalse();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class BeTests
        {
            [Theory]
            [InlineData(true)]
            [InlineData(false)]
            public void Does_not_throw(bool value)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().Be(value);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Theory]
            [InlineData(true)]
            [InlineData(false)]
            public void Throws(bool value)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().Be(!value);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}