using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace FluentAssertions.Optional.Tests
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
}