using System;
using System.Collections.Generic;
using FluentAssertions.Primitives;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional.Primitives
{
  public class OptionalDateTimeAssertions : DateTimeAssertions, IOptionAssertions<DateTime, DateTimeAssertions>
  {
    public new Option<DateTime> Subject { get; }

    public DateTimeAssertions ContinuedAssertions => new DateTimeAssertions(Subject.ValueOrDefault());

    public OptionalDateTimeAssertions(Option<DateTime> value) : base(value.ValueOrDefault())
    {
      Subject = value;
    }
  }

    /*
    public class OptionalDateTimeAssertions : OptionContinuedAssertions<DateTime, OptionalDateTimeAssertions, DateTimeAssertions>
    {
        public OptionalDateTimeAssertions(Option<DateTime> subject) : base(subject, new DateTimeAssertions(subject.ValueOrDefault()))
        {
        }
        
        /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is within the specified number of milliseconds (default = 20 ms)
    /// from the specified <paramref name="nearbyTime" /> value.
    /// </summary>
    /// <remarks>
    /// Use this assertion when, for example the database truncates datetimes to nearest 20ms. If you want to assert to the exact datetime,
    /// use <see cref="M:FluentAssertions.Primitives.DateTimeAssertions.Be(System.DateTime,System.String,System.Object[])" />.
    /// </remarks>
    /// <param name="nearbyTime">
    /// The expected time to compare the actual value with.
    /// </param>
    /// <param name="precision">
    /// The maximum amount of milliseconds which the two values may differ.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
        public AndConstraint<DateTimeAssertions> BeCloseTo(
          DateTime nearbyTime,
          int precision = 20,
          string because = "",
          params object[] becauseArgs) =>
          HaveValueAnd().BeCloseTo(nearbyTime, TimeSpan.FromMilliseconds(precision), because, becauseArgs);

        private DateTimeAssertions HaveValueAnd()
        {
          HaveValue();
          return new DateTimeAssertions(Subject.ValueOrDefault());
        }
        
    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is within the specified time
    /// from the specified <paramref name="nearbyTime" /> value.
    /// </summary>
    /// <remarks>
    /// Use this assertion when, for example the database truncates datetimes to nearest 20ms. If you want to assert to the exact datetime,
    /// use <see cref="M:FluentAssertions.Primitives.DateTimeAssertions.Be(System.DateTime,System.String,System.Object[])" />.
    /// </remarks>
    /// <param name="nearbyTime">
    /// The expected time to compare the actual value with.
    /// </param>
    /// <param name="precision">
    /// The maximum amount of time which the two values may differ.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeCloseTo(
      DateTime nearbyTime,
      TimeSpan precision,
      string because = "",
      params object[] becauseArgs) =>
      HaveValueAnd().BeCloseTo(nearbyTime, precision, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is not within the specified number of milliseconds (default = 20 ms)
    /// from the specified <paramref name="distantTime" /> value.
    /// </summary>
    /// <remarks>
    /// Use this assertion when, for example the database truncates datetimes to nearest 20ms. If you want to assert to the exact datetime,
    /// use <see cref="M:FluentAssertions.Primitives.DateTimeAssertions.NotBe(System.DateTime,System.String,System.Object[])" />.
    /// </remarks>
    /// <param name="distantTime">
    /// The time to compare the actual value with.
    /// </param>
    /// <param name="precision">
    /// The maximum amount of milliseconds which the two values must differ.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeCloseTo(
      DateTime distantTime,
      int precision = 20,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeCloseTo(distantTime, TimeSpan.FromMilliseconds(precision), because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is not within the specified time
    /// from the specified <paramref name="distantTime" /> value.
    /// </summary>
    /// <remarks>
    /// Use this assertion when, for example the database truncates datetimes to nearest 20ms. If you want to assert to the exact datetime,
    /// use <see cref="M:FluentAssertions.Primitives.DateTimeAssertions.NotBe(System.DateTime,System.String,System.Object[])" />.
    /// </remarks>
    /// <param name="distantTime">
    /// The time to compare the actual value with.
    /// </param>
    /// <param name="precision">
    /// The maximum amount of time which the two values must differ.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeCloseTo(
      DateTime distantTime,
      TimeSpan precision,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeCloseTo(distantTime, precision, because, becauseArgs);
    
    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is before the specified value.
    /// </summary>
    /// <param name="expected">The <see cref="T:System.DateTime" />  that the current value is expected to be before.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeBefore(
      DateTime expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeBefore(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is not before the specified value.
    /// </summary>
    /// <param name="unexpected">The <see cref="T:System.DateTime" />  that the current value is not expected to be before.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeBefore(
      DateTime unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeBefore(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is either on, or before the specified value.
    /// </summary>
    /// <param name="expected">The <see cref="T:System.DateTime" />  that the current value is expected to be on or before.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeOnOrBefore(
      DateTime expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeOnOrBefore(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is neither on, nor before the specified value.
    /// </summary>
    /// <param name="unexpected">The <see cref="T:System.DateTime" />  that the current value is not expected to be on nor before.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeOnOrBefore(
      DateTime unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeOnOrBefore(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is after the specified value.
    /// </summary>
    /// <param name="expected">The <see cref="T:System.DateTime" />  that the current value is expected to be after.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeAfter(
      DateTime expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeAfter(expected, because, becauseArgs);
    
    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is not after the specified value.
    /// </summary>
    /// <param name="unexpected">The <see cref="T:System.DateTime" />  that the current value is not expected to be after.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeAfter(
      DateTime unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeAfter(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is either on, or after the specified value.
    /// </summary>
    /// <param name="expected">The <see cref="T:System.DateTime" />  that the current value is expected to be on or after.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeOnOrAfter(
      DateTime expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeOnOrAfter(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  is neither on, nor after the specified value.
    /// </summary>
    /// <param name="unexpected">The <see cref="T:System.DateTime" />  that the current value is expected not to be on nor after.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeOnOrAfter(
      DateTime unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeAfter(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> has the <paramref name="expected" /> year.
    /// </summary>
    /// <param name="expected">The expected year of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveYear(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveYear(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> year.
    /// </summary>
    /// <param name="unexpected">The year that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveYear(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveYear(unexpected, because, becauseArgs);


    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> has the <paramref name="expected" /> month.
    /// </summary>
    /// <param name="expected">The expected month of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveMonth(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveMonth(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> month.
    /// </summary>
    /// <param name="unexpected">The month that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveMonth(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveMonth(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  has the <paramref name="expected" /> day.
    /// </summary>
    /// <param name="expected">The expected day of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveDay(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveDay(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> day.
    /// </summary>
    /// <param name="unexpected">The day that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveDay(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveDay(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  has the <paramref name="expected" /> hour.
    /// </summary>
    /// <param name="expected">The expected hour of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveHour(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveHour(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> hour.
    /// </summary>
    /// <param name="unexpected">The hour that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveHour(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveHour(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  has the <paramref name="expected" /> minute.
    /// </summary>
    /// <param name="expected">The expected minutes of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveMinute(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveMinute(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> minute.
    /// </summary>
    /// <param name="unexpected">The minute that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveMinute(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveMinute(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" />  has the <paramref name="expected" /> second.
    /// </summary>
    /// <param name="expected">The expected seconds of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> HaveSecond(
      int expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().HaveSecond(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> does not have the <paramref name="unexpected" /> second.
    /// </summary>
    /// <param name="unexpected">The second that should not be in the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotHaveSecond(
      int unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotHaveSecond(unexpected, because, becauseArgs);

    /// <summary>
    /// Returns a <see cref="T:FluentAssertions.Primitives.DateTimeRangeAssertions" /> object that can be used to assert that the current <see cref="T:System.DateTime" />
    /// exceeds the specified <paramref name="timeSpan" /> compared to another <see cref="T:System.DateTime" /> .
    /// </summary>
    /// <param name="timeSpan">
    /// The amount of time that the current <see cref="T:System.DateTime" />  should exceed compared to another <see cref="T:System.DateTime" /> .
    /// </param>
    public DateTimeRangeAssertions BeMoreThan(TimeSpan timeSpan)
      => HaveValueAnd().BeMoreThan(timeSpan);

    /// <summary>
    /// Returns a <see cref="T:FluentAssertions.Primitives.DateTimeRangeAssertions" /> object that can be used to assert that the current <see cref="T:System.DateTime" />
    /// is equal to or exceeds the specified <paramref name="timeSpan" /> compared to another <see cref="T:System.DateTime" /> .
    /// </summary>
    /// <param name="timeSpan">
    /// The amount of time that the current <see cref="T:System.DateTime" />  should be equal or exceed compared to
    /// another <see cref="T:System.DateTime" />.
    /// </param>
    public DateTimeRangeAssertions BeAtLeast(TimeSpan timeSpan)
      => HaveValueAnd().BeAtLeast(timeSpan);

    /// <summary>
    /// Returns a <see cref="T:FluentAssertions.Primitives.DateTimeRangeAssertions" /> object that can be used to assert that the current <see cref="T:System.DateTime" />
    /// differs exactly the specified <paramref name="timeSpan" /> compared to another <see cref="T:System.DateTime" /> .
    /// </summary>
    /// <param name="timeSpan">
    /// The amount of time that the current <see cref="T:System.DateTime" />  should differ exactly compared to another <see cref="T:System.DateTime" /> .
    /// </param>
    public DateTimeRangeAssertions BeExactly(TimeSpan timeSpan)
      => HaveValueAnd().BeExactly(timeSpan);

    /// <summary>
    /// Returns a <see cref="T:FluentAssertions.Primitives.DateTimeRangeAssertions" /> object that can be used to assert that the current <see cref="T:System.DateTime" />
    /// is within the specified <paramref name="timeSpan" /> compared to another <see cref="T:System.DateTime" /> .
    /// </summary>
    /// <param name="timeSpan">
    /// The amount of time that the current <see cref="T:System.DateTime" />  should be within another <see cref="T:System.DateTime" /> .
    /// </param>
    public DateTimeRangeAssertions BeWithin(TimeSpan timeSpan)
      => HaveValueAnd().BeWithin(timeSpan);

    /// <summary>
    /// Returns a <see cref="T:FluentAssertions.Primitives.DateTimeRangeAssertions" /> object that can be used to assert that the current <see cref="T:System.DateTime" />
    /// differs at maximum the specified <paramref name="timeSpan" /> compared to another <see cref="T:System.DateTime" /> .
    /// </summary>
    /// <param name="timeSpan">
    /// The maximum amount of time that the current <see cref="T:System.DateTime" />  should differ compared to another <see cref="T:System.DateTime" /> .
    /// </param>
    public DateTimeRangeAssertions BeLessThan(TimeSpan timeSpan)
      => HaveValueAnd().BeLessThan(timeSpan);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> has the <paramref name="expected" /> date.
    /// </summary>
    /// <param name="expected">The expected date portion of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeSameDateAs(
      DateTime expected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeSameDateAs(expected, because, becauseArgs);

    /// <summary>
    /// Asserts that the current <see cref="T:System.DateTime" /> is not the <paramref name="unexpected" /> date.
    /// </summary>
    /// <param name="unexpected">The date that is not to match the date portion of the current value.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> NotBeSameDateAs(
      DateTime unexpected,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().NotBeSameDateAs(unexpected, because, becauseArgs);

    /// <summary>
    /// Asserts that the <see cref="T:System.DateTime" /> is one of the specified <paramref name="validValues" />.
    /// </summary>
    /// <param name="validValues">The values that are valid.</param>
    public AndConstraint<DateTimeAssertions> BeOneOf(
      params DateTime?[] validValues)
      => HaveValueAnd().BeOneOf(validValues);

    /// <summary>
    /// Asserts that the <see cref="T:System.DateTime" /> is one of the specified <paramref name="validValues" />.
    /// </summary>
    /// <param name="validValues">The values that are valid.</param>
    public AndConstraint<DateTimeAssertions> BeOneOf(
      params DateTime[] validValues)
      => HaveValueAnd().BeOneOf(validValues);
    
    /// <summary>
    /// Asserts that the <see cref="T:System.DateTime" /> is one of the specified <paramref name="validValues" />.
    /// </summary>
    /// <param name="validValues">The values that are valid.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeOneOf(
      IEnumerable<DateTime> validValues,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeOneOf(validValues, because, becauseArgs);

    /// <summary>
    /// Asserts that the <see cref="T:System.DateTime" /> is one of the specified <paramref name="validValues" />.
    /// </summary>
    /// <param name="validValues">The values that are valid.</param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeOneOf(
      IEnumerable<DateTime?> validValues,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeOneOf(validValues, because, becauseArgs);

    /// <summary>
    /// Asserts that the <see cref="T:System.DateTime" /> represents a value in the <paramref name="expectedKind" />.
    /// </summary>
    /// <param name="expectedKind">
    /// The expected <see cref="T:System.DateTimeKind" /> that the current value must represent.
    /// </param>
    /// <param name="because">
    /// A formatted phrase as is supported by <see cref="M:System.String.Format(System.String,System.Object[])" /> explaining why the assertion
    /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
    /// </param>
    /// <param name="becauseArgs">
    /// Zero or more objects to format using the placeholders in <see cref="!:because" />.
    /// </param>
    public AndConstraint<DateTimeAssertions> BeIn(
      DateTimeKind expectedKind,
      string because = "",
      params object[] becauseArgs)
      => HaveValueAnd().BeIn(expectedKind, because, becauseArgs);
    }
*/
}