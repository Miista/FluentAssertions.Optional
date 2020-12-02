using System;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionEitherAssertionsTests
    {
        public class BeNoneTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Option.None<string, Exception>(new Exception());

                // Act
                Action act = () => option.Should().BeNone();

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optional contains an exception and not a value");
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().BeNone();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional contains a value and not an exception");
            }
        }

        public class BeSomeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().NotThrow<XunitException>();
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string, Exception>(new Exception());

                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().Throw<XunitException>();
            }
        }

        public class HaveExceptionTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Option.None<string, Exception>(new Exception());

                // Act
                Action act = () => option.Should().HaveException();

                // Assert
                act.Should().NotThrow<XunitException>(because: "the option contains an exception and not a value");
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().HaveException();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional contains a value and not an exception");
            }
        }
        
        public class BeTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();
                var value = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().Be(value);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optional contains a value and not an exception");
            }
            
            [Fact]
            public void Does_not_throw_with_exception()
            {
                // Arrange
                var exception = new Exception();
                var option = Option.None<string, Exception>(exception);
                var value = Option.None<string, Exception>(exception);

                // Act
                Action act = () => option.Should().Be(value);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the two optionals both contain the same exceptions");
            }

            [Fact]
            public void Throws()
            {
                // Arrange
                var option = Option.None<string, Exception>(new Exception());
                var value = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().Be(value);

                // Assert
                act.Should().Throw<XunitException>(because: "the option contains an exception and not a value");
            }
            
            [Fact]
            public void Throws_with_exception()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();
                var value = Option.None<string, Exception>(new Exception());

                // Act
                Action act = () => option.Should().Be(value);

                // Assert
                act.Should().Throw<XunitException>(because: "the option contains an exception and not a value");
            }
        }

        public class NotBeTests
        {
            [Fact]
            public void Throws()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();
                var value = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().NotBe(value);

                // Assert
                act.Should().Throw<XunitException>(because: "the two options contain the same value");
            }

            [Fact]
            public void Throws_with_exception()
            {
                // Arrange
                var exception = new Exception();
                var option = Option.None<string, Exception>(exception);
                var value = Option.None<string, Exception>(exception);

                // Act
                Action act = () => option.Should().NotBe(value);

                // Assert
                act.Should().Throw<XunitException>(because: "the two optionals both contain the same exceptions");
            }

            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var option = Option.None<string, Exception>(new Exception());
                var value = "Value".Some<string, Exception>();

                // Act
                Action act = () => option.Should().NotBe(value);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the option contains an exception and not a value");
            }
            
            [Fact]
            public void Does_not_throw_with_exception()
            {
                // Arrange
                var option = "Value".Some<string, Exception>();
                var value = Option.None<string, Exception>(new Exception());

                // Act
                Action act = () => option.Should().NotBe(value);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the option contains an exception and not a value");
            }
        }
    }
}