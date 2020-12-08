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

        public class NotBeNoneTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = "Value".Some();

                // Act
                Action act = () => option.Should().NotBeNone();

                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();

                // Act
                Action act = () => option.Should().NotBeNone();

                // Assert
                act.Should().Throw<XunitException>();
            }

            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().NotBeNone();

                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = Option.None<T>();
                
                // Act
                Action act = () => option.Should().NotBeNone();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional is None");
            }
        }

        public class NotBeSomeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Option.None<string>();
                
                // Act
                Action act = () => option.Should().NotBeSome();
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Value".Some();
                
                // Act
                Action act = () => option.Should().NotBeSome();
                
                // Assert
                act.Should().Throw<XunitException>();
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = Option.None<T>();
                
                // Act
                Action act = () => option.Should().NotBeSome();

                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().NotBeSome();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional contains a value");
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
                var value = "Value".Some();
                
                // Act
                Action act = () => option.Should().Be(value);
                
                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string>();
                var value = "Value".Some();
                
                // Act
                Action act = () => option.Should().Be(value);
                
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