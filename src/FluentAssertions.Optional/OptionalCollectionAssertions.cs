using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions.Collections;
using Optional;
using Optional.Unsafe;

namespace FluentAssertions.Optional
{
    public class OptionalGenericCollectionAssertions<T> : OptionContinuedAssertions<IEnumerable<T>, OptionalGenericCollectionAssertions<T>, GenericCollectionAssertions<T>>
    {
        public OptionalGenericCollectionAssertions(Option<IEnumerable<T>> subject) : base(subject, new GenericCollectionAssertions<T>(subject.ValueOrDefault()))
        {
        }

        [CustomAssertion]
        public AndConstraint<GenericCollectionAssertions<T>> BeInAscendingOrder<TSelector>(
            Expression<Func<T, TSelector>> propertyExpression,
            string because = "",
            params object[] becauseArgs) =>
            HaveValueAnd().BeInAscendingOrder(because, becauseArgs);
        
        private GenericCollectionAssertions<T> HaveValueAnd()
        {
            HaveValue();
            return new GenericCollectionAssertions<T>(Subject.ValueOrDefault());
        }

    }
}