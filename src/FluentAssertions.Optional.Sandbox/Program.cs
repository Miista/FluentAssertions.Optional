using System;
using System.Collections.Generic;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // The "code" should be a drop-in replacement,
            // meaning that if you change the type of a property
            // any existing assertions should work.
            // In other words, the following:
            var fromMinutes = TimeSpan.FromMinutes(10);
            var d = DateTime.Now;
            var dateTime = d.Some();
            dateTime.Should().Be(dateTime);
            dateTime.Should().BeAfter(d.Subtract(fromMinutes));
            dateTime.Should().BeCloseTo(d);
            dateTime.Should().BeExactly(TimeSpan.Zero).After(d).And.BeExactly(TimeSpan.Zero).Before(d);
            dateTime.Should().BeSameDateAs(d);

            var b = true;
            var boolean = b.Some();
            boolean.Should().BeTrue();
            boolean.Should().Be(true);

            var i = 1;
            var nt = i.Some();
            nt.Should().BeOneOf(1, 2, 3);
            nt.Should().BePositive();
            nt.Should().BeGreaterThan(0);
            nt.Should().BeGreaterOrEqualTo(1);
            nt.Should().BeInRange(0, 10);

            /*
            Action act = () => throw new Exception();
            act.Should().Throw<Exception>().BeOfType<Exception>();
            
            var n = Option.None<string, Exception>(new Exception("H"));
            n.Should().HaveAlternateValue();
            n.Should().BeNone();
            n.Should().HaveException().BeOfType<Exception>(); //WithMessage("H");
            */
            // var optionalInt = Option.None<int>();
            // // optionalInt.Should().BeSome();
            // optionalInt.Should().Be(0);
            //
            // // var intOrNone = Option.None<int>();
            // // intOrNone.Should().NotBeNone();
            // // optionalInt.Should().HaveValue().Which.Should().BePositive();
            // // string s = null;
            // // s.Should().NotBeNull();
            //
            // // "Hello".Should().Be("hello");
            // // "Hello".Should().BeEquivalentTo("hello");
            // var optionalString = Option.None<string>();
            // optionalString.Should().BeEquivalentTo("hello");
            // // "Hello".Some().Should().BeSome("hello");
            // // 0.Should().BePositive();
            //
            // // Guid? nullableGuid = null;
            // // nullableGuid.Should().BeNull();
            //
            // // int? nullableInt = null;
            // // nullableInt.Should().Be(0);

//            var optionalString = "Hello".Some();
//            optionalString.Should().BeSome().And.StartWith("He").And.EndWith("llo").And.HaveLength(5);
//
//            var optionalDateTime = DateTime.Now.Some();
//            optionalDateTime.Should().BeSome().And.BeCloseTo(DateTime.Now);
//            
//            var optionalInt = 1.Some();
//            optionalInt.Should().BeSome().And.Be(1);
//            optionalInt.Should().BeSome().And.BePositive();
//
//            var optionalNegativeInt = (-1).Some();
//            optionalNegativeInt.Should().BeSome().And.BeNegative();
//
//            var optionalDouble = 2.0.Some();
//            optionalDouble.Should().BeSome().And.Be(2);
//            optionalDouble.Should().BeSome(2);
//            optionalDouble.Should().Be(optionalDouble);
//            optionalDouble.Should().HaveValue().Which.Should().Be(2);
//            
//            var optionalGuid = Guid.Empty.Some();
//            optionalGuid.Should().BeSome().And.Be(Guid.Empty);
//            optionalGuid.Should().BeSome().And.BeEmpty();
//            // optionalGuid.Should().HaveValueThatShould().BeEmpty();
//            
//            var optionalList = new List<string> {"Hello"}.Some(); //Option.None<List<string>>(); //1.Some();
//            var ass = new OptionalEquivalencyAssertions<List<string>>(optionalList);
//            ass.BeEquivalentTo(new List<string>());
//
//            Console.WriteLine("Hello World!");
//
//            Action act;
//            var optionalException = Option.None<string, Exception>(new Exception("Hello"));
//            // optionalException.Should().BeNone();
//            // Option.Some<string, Exception>("").Should().HaveAlternateValue();
//            optionalException.Should().HaveException<Exception>().WithMessage("Hello");
//
//            var optionalEither = Option.None<string, int>(0);
//            optionalEither.Should().HaveAlternateValue().Which.Should().BeGreaterOrEqualTo(1);
//            
//            // var optionalEitherFail = Option.None<string, int>(0);
//            // optionalEitherFail.Should().NotHaveAlternateValue();
        }
    }

    // public static class OptionalAssertionExtensions
    // {
    //     [CustomAssertion]
    //     public static AndConstraint<StringAssertions> BeEquivalentTo(
    //         this OptionalAssertions<string> assertions,
    //         string expected,
    //         string because = "",
    //         params object[] becauseArgs)
    //     {
    //         if (assertions == null) throw new ArgumentNullException(nameof(assertions));
    //         
    //         return assertions.HaveValue(because, becauseArgs).Which.Should().BeEquivalentTo(expected, because, becauseArgs);
    //     }
    //     
    //     [CustomAssertion]
    //     public static AndConstraint<GuidAssertions> Be(
    //         this OptionalAssertions<Guid> assertions,
    //         Guid expected,
    //         string because = "",
    //         params object[] becauseArgs)
    //     {
    //         if (assertions == null) throw new ArgumentNullException(nameof(assertions));
    //
    //         return assertions.HaveValue(because, becauseArgs).Which.Should().Be(expected, because, becauseArgs);
    //     }
    //     
    //     public static GuidAssertions HaveValueThatShould(
    //         this OptionalAssertions<Guid> assertions)
    //     {
    //         if (assertions == null) throw new ArgumentNullException(nameof(assertions));
    //
    //         return assertions.HaveValue().Which.Should();
    //     }
    //     
    //     public static StringAssertions HaveValueThatShould(
    //         this OptionalAssertions<string> assertions)
    //     {
    //         if (assertions == null) throw new ArgumentNullException(nameof(assertions));
    //
    //         return assertions.HaveValue().Which.Should();
    //     }
    //     
    //     [CustomAssertion]
    //     public static AndConstraint<GuidAssertions> BeEmpty(
    //         this OptionalAssertions<Guid> assertions,
    //         string because = "",
    //         params object[] becauseArgs)
    //     {
    //         if (assertions == null) throw new ArgumentNullException(nameof(assertions));
    //         
    //         return assertions.NotBeNone(because, becauseArgs).And.HaveValue().Which.Should().BeEmpty(because, becauseArgs);
    //     }
    // }
    
    public class OptionalEquivalencyAssertions<T>
    {
        public Option<T> Subject { get; }

        public OptionalEquivalencyAssertions(Option<T> subject)
        {
            Subject = subject;
        }

        public void BeEquivalentTo(
            T expected,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some({1}){reason} but found {0}.", Subject, expected);

            var makeGenericType = typeof(T);
            var memberInfo = typeof(List<>);

            if (typeof(T) == typeof(string))
            {
                (((T) Subject.ValueOrDefault()) as string).Should().BeEquivalentTo(expected as string);
            }
            else if (typeof(T) == memberInfo)
            {
                ((object) Subject.ValueOrDefault()).Should().BeEquivalentTo(expected);
            }
        }
    }
    
    public class OptionalNumericAssertions<T> where T : struct, IComparable
    {
        internal Option<T> InternalSubject { get; }

        private readonly NumericAssertions<T> _numericAssertions;
        
        public OptionalNumericAssertions(Option<T> value) // : base(value.ToNullable())
        {
            InternalSubject = value;
            _numericAssertions = new NumericAssertions<T>(value.ValueOrDefault());
        }
        
        [CustomAssertion]
        public AndWhichConstraint<OptionalNumericAssertions<T>, T> HaveValue(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(InternalSubject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some{reason} but found {0}.", InternalSubject);

            return new AndWhichConstraint<OptionalNumericAssertions<T>, T>(this, InternalSubject.ValueOrDefault());
        }
        
        public AndConstraint<OptionalNumericAssertions<T>> Be(
            T expected,
            string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(InternalSubject.HasValue)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:option} to be Some({1}){reason} but found {0}.", InternalSubject, expected);
            
            _numericAssertions.Be(expected, because, becauseArgs);
                
            return new AndConstraint<OptionalNumericAssertions<T>>(this);
        }
    }

    // public static class OptionNumericAssertionExtensions
    // {
    //     public static void Be<T>(this OptionalNumericAssertions<T> assertions, T expected) where T : struct, IComparable
    //     {
    //         Execute.Assertion
    //             .ForCondition(assertions.InternalSubject.HasValue)
    //             .FailWith("Expected {context:option} to be Some{reason} but found {0}.", assertions.InternalSubject);
    //     }
    // }

    public class OptionalStringAssertions : StringAssertions
    {
        public OptionalStringAssertions(Option<string> value) : base(value.ValueOrDefault())
        {
        }
    }
    
    // public static class OptionExtensions
    // {
    //     public static OptionalNumericAssertions<int> Should(this Option<int> instance)
    //     {
    //         using (new AssertionScope("lol"))
    //         {
    //             return new OptionalNumericAssertions<int>(instance);
    //         }
    //     }
    //
    //     public static OptionalStringAssertions Should(this Option<string> instance) => new OptionalStringAssertions(instance);
    //
    //     public static void BeSome<T>(this OptionalNumericAssertions<T> instance, string because = "", params object[] becauseArgs)
    //         where T : struct, IComparable => BeSome(instance.InternalSubject, because, becauseArgs);
    //
    //     private static void BeSome<T>(Option<T> option, string because = "", params object[] becauseArgs)
    //     {
    //         Execute.Assertion
    //             .ForCondition(option.HasValue)
    //             .BecauseOf(because, becauseArgs)
    //             .FailWith("Expected {context:option} to be Some{reason} but found {0}.", option);
    //     }
    // }
}