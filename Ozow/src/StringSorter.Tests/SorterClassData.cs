using System.Collections;
using System.Collections.Generic;

namespace StringSorter.Tests
{

    public class SorterClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new LinqLibrarySorter() };
            yield return new object[] { new ArrayLibrarySorter() };
            yield return new object[] { new BubbleSorter() };
            yield return new object[] { new InsertSorter() };
            yield return new object[] { new QuickSorter() };
            yield return new object[] { new SelectionSorter() };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}