using System;
using System.Collections.Generic;
using Optional;
using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.Optional.Tests.Collections
{
    public class OptionalGenericDictionaryAssertionsTests
    {
        public class BeEmptyTests
        {
            [Fact]
            public void Does_not_throw()
            {
                // Arrange
                var dict = new Dictionary<string, string>
                {
                    { "Hello", "World!" }
                } as IDictionary<string, string>;
                var option = dict.Some();

                // Act
                Action act = () => option.Should().NotBeEmpty();

                // Assert
                act.Should().NotThrow<XunitException>();
            }
        }
    }
}