using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Primitives
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
        
        public class BeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var guid = Guid.NewGuid();
                var option = guid.Some();

                // Act
                Action act = () => option.Should().Be(guid);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var guid1 = Guid.NewGuid();
                var guid2 = Guid.NewGuid();
                var option = guid1.Some();

                // Act
                Action act = () => option.Should().Be(guid2);

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
                var guid1 = Guid.NewGuid();
                var guid2 = Guid.NewGuid();
                var option = guid1.Some();

                // Act
                Action act = () => option.Should().NotBe(guid2);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var guid1 = Guid.NewGuid();
                var option = guid1.Some();

                // Act
                Action act = () => option.Should().NotBe(guid1);

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}