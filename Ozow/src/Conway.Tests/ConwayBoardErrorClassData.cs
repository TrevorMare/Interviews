using System.Collections;
using System.Collections.Generic;

namespace Conway.Tests
{

    public class ConwayBoardErrorClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new byte[ 0, 0 ] };
            yield return new object[] { new byte[ 1, 0 ] };
            yield return new object[] { new byte[ 0, 1 ] };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}