using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests
{
    public class OptionAssertionsTests
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = Option.None<T>();
                
                // Act
                Action act = () => option.Should().BeNone();

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

            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().BeSome();

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
                Action act = () => option.Should().BeSome();

                // Assert
                act.Should().Throw<XunitException>(because: "the optional is None");
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some();
                
                // Act
                Action act = () => option.Should().HaveValue();

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optional contains a value");
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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some();
                var expectedValue = value.Some();
                
                // Act
                Action act = () => option.Should().Be(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>();
            }
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type_Throws<T>(T value)
            {
                // Arrange
                var option = value.Some();
                var expectedValue = Option.None<T>();
                
                // Act
                Action act = () => option.Should().Be(expectedValue);

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
            
            [Theory]
            [ClassData(typeof(AnyTypeData))]
            public void Works_with_any_type<T>(T value)
            {
                // Arrange
                var option = value.Some();
                var expectedValue = value.Some();
                
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
                var option = value.Some();
                var expectedValue = Option.None<T>();
                
                // Act
                Action act = () => option.Should().NotBe(expectedValue);

                // Assert
                act.Should().NotThrow<XunitException>(because: "the optionals are not the same");
            }
        }
    }
}