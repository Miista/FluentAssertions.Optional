using System;
using Optional;

namespace FluentAssertions.Optional.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionalInt = 1.Some();
            optionalInt.Should().BeSome().And.HaveValue().Which.Should().BePositive();
            // optionalInt.Should().HaveValue().Which.Should().BePositive();
            Console.WriteLine("Hello World!");
        }
    }
}