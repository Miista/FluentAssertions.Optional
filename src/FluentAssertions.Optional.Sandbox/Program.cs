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
            var intOrNone = Option.None<int>();
            intOrNone.Should().NotBeNone();
            // optionalInt.Should().HaveValue().Which.Should().BePositive();
            string s = null;
            s.Should().NotBeNull();
            Console.WriteLine("Hello World!");
        }
    }
}