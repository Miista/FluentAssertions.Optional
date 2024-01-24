using System;
using System.Collections.Generic;
using Optional;
using Xunit;

namespace FluentAssertions.Optional.Tests.Collections
{
    public class OptionalStringCollectionAssertionsTests
    {
        [Fact]
        public void Test()
        {
            // Arrange
            var collection = new[] { "Hello", "World!" } as IEnumerable<string>;
            var option = collection.Some();

            // Act
            Action act = () => option.Should().NotBeEmpty();
            
            // Assert
            act.Should().NotThrow(because: "the collection is not empty");
        }
    }
}