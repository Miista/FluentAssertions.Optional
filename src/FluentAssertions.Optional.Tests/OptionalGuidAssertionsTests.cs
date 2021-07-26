using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionalGuidAssertionsTests
    {
        public class BeEmptyTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Guid.Empty.Some();

                // Act
                Action act = () => option.Should().BeEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Guid.NewGuid().Some();

                // Act
                Action act = () => option.Should().BeEmpty();

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
                var option = Guid.NewGuid().Some();

                // Act
                Action act = () => option.Should().NotBeEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Guid.Empty.Some();

                // Act
                Action act = () => option.Should().NotBeEmpty();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}