using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionEitherAssertionsTests
    {
        public class AnyTypeData : IEnumerable<object[]>
        {
            // ReSharper disable once InconsistentNaming
            // ReSharper disable once MemberCanBePrivate.Global
            public IEnumerator<object[]> GetEnumerator()
            {
                // decimal is skipped because it causes an AmbiguousMatchException
                yield return new object[] {default(bool)};
                yield return new object[] {default(string)};
                yield return new object[] {default(char)};
                yield return new object[] {default(byte)};
                yield return new object[] {default(double)};
                yield return new object[] {default(float)};
                yield return new object[] {default(short)};
                yield return new object[] {default(int)};
                yield return new object[] {default(long)};
                yield return new object[] {default(ushort)};
                yield return new object[] {default(uint)};
                yield return new object[] {default(ulong)};
                yield return new object[] {default(Uri)};
                yield return new object[] {default(CancellationToken)};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = Option.None<T, Exception>(new Exception());
                
                // Act
                Action act = () => option.Should().BeNone();

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optional is None");
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                
                // Act
                Action act = () => option.Should().BeNone();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional contains a value");
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                
                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optional contains a value");
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = Option.None<T, Exception>(new Exception());
                
                // Act
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional is None");
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                var expectedValue = value.Some<T, Exception>();
                
                // Act
                Action act = () => option.Should().Be(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the two optionals are the same");
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                var expectedValue = Option.None<T, Exception>(new Exception());
                
                // Act
                Action act = () => option.Should().Be(expectedValue);

                // Assert
                act.Should().Throw<XunitException>(because: "the two optionals are not the same");
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                var expectedValue = value.Some<T, Exception>();
                
                // Act
                Action act = () => option.Should().NotBe(expectedValue);

                // Assert
                act.Should().Throw<XunitException>(because: "the optionals contain the same value");
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = value.Some<T, Exception>();
                var expectedValue = Option.None<T, Exception>(new Exception());
                
                // Act
                Action act = () => option.Should().NotBe(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optionals are not the same");
            }
        }
    }
}