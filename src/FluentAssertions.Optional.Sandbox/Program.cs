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

            Action act;
            var optionalException = Option.None<string, Exception>(new Exception("Hello"));
            // optionalException.Should().BeNone();
            // Option.Some<string, Exception>("").Should().HaveAlternateValue();
            optionalException.Should().HaveException<Exception>().WithMessage("Hello");

            var optionalEither = Option.None<string, int>(0);
            optionalEither.Should().HaveAlternateValue().Which.Should().BeGreaterOrEqualTo(1);
            
            // var optionalEitherFail = Option.None<string, int>(0);
            // optionalEitherFail.Should().NotHaveAlternateValue();
        }
    }
}