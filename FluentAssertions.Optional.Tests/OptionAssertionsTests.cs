using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionAssertionsTests
    {
        public class BeNoneTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Option.None<string>();
                
                // Act
                Action act = () => option.Should().BeNone();
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Value".Some();
                
                // Act
                Action act = () => option.Should().BeNone();
                
                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class BeSomeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = "Value".Some();

                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();

                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class HaveValueTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = "Value".Some();
                
                // Act
                Action act = () => option.Should().HaveValue();
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();
                
                // Act
                Action act = () => option.Should().HaveValue();
                
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
                var option = "Value".Some();
                
                // Act
                Action act = () => option.Should().Be("Value".Some());
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();
                
                // Act
                Action act = () => option.Should().Be("Value".Some());
                
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
                var option = "Value".Some();
                
                // Act
                Action act = () => option.Should().NotBe("Value".Some());
                
                // Assert
                act.Should().Throw<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();
                
                // Act
                Action act = () => option.Should().NotBe("Value".Some());
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
        }
    }
}