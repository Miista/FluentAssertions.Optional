using System;
using Optional;

namespace FluentAssertions.Optional.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionalInt = 1.Some();
            optionalInt.Should().BeSome();
            var intOrNone = Option.None<int>();
            intOrNone.Should().BePositive();
            intOrNone.Should().NotBeNone();
            // optionalInt.Should().HaveValue().Which.Should().BePositive();
            string s = null;
            s.Should().NotBeNull();
            Console.WriteLine("Hello World!");
        }
        
        //static void T<X>(X x) => x.Should() 
    }
}