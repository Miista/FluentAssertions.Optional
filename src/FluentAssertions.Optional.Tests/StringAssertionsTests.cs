using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class StringAssertionsTests
    {
        public class BeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var value = "Value";
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
    }
}