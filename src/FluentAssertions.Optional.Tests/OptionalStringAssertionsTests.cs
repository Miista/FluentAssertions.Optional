using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionalStringAssertionsTests
    {
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
        
        public class BeOneOfTests
        {
            [Theory]
            [InlineData("ABC", new []{"ABC","DEF","GHI"})]
            [InlineData("DEF", new []{"ABC","DEF","GHI"})]
            [InlineData("GHI", new []{"ABC","DEF","GHI"})]
            public void Does_not_throw(string value, string[] validValues)
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
                var option = "Hello, World".Some();

                // Act
                Action act = () => option.Should().BeOneOf(new []{"Hello", "World"});

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
        
        public class BeEquivalentToTests
        {
            [Theory]
            [InlineData("ABC", "abc")]
            [InlineData("abc", "ABC")]
            public void Does_not_throw(string value, string expected)
            {
                // Arrange
                var option = value.Some();

                // Act
                Action act = () => option.Should().BeEquivalentTo(expected);

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Hello, World".Some();

                // Act
                Action act = () => option.Should().BeEquivalentTo("Goodbye, World!");

                // Assert
                act.Should().Throw<XunitException>();
            }
        }
    }
}