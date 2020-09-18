using System.Collections;
using System.Collections.Generic;

namespace Conway.Tests
{

    public class ConwayBoardProgressionBoundryClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var inputData = new byte[4, 4]
            {
                { 1, 1, 1, 1 }, 
                { 1, 0, 0, 1 },
                { 1, 0, 1, 0 },
                { 1, 1, 1, 1 }
            };

            yield return new object[] { inputData, 0, 0, 1 };
            yield return new object[] { inputData, 0, 3, 1 };
            yield return new object[] { inputData, 3, 0, 1 };
            yield return new object[] { inputData, 3, 3, 1 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } 

    public class ConwayBoardProgression1OrLessData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] 
            { 
                new byte[2, 2] { { 0, 0 }, { 1, 0 } }
            };
            yield return new object[] 
            { 
                new byte[2, 2] { { 0, 0 }, { 0, 0 } }
            };        
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } 

    public class ConwayBoardProgression4OrMoreData : IEnumerable<object[]>
    {
        
        public IEnumerator<object[]> GetEnumerator()
        {
            var inputData = new byte[4, 4]
            {
                { 0, 1, 1, 0 }, 
                { 1, 1, 0, 1 },
                { 1, 1, 1, 0 },
                { 0, 1, 1, 0 }
            };

            yield return new object[] 
            { 
                inputData, 1, 1
            };
                   
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    } 

    public class ConwayBoardProgression2Or3Data : IEnumerable<object[]>
    {
        
        public IEnumerator<object[]> GetEnumerator()
        {
            var inputData = new byte[4, 4]
            {
                { 1, 0, 0, 0 }, 
                { 0, 1, 0, 0 },
                { 1, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };

            yield return new object[] 
            { 
                inputData, 1, 1
            };
            yield return new object[] 
            { 
                inputData, 2, 2
            };
                   
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConwayBoardProgressionDeadCellToLiveData : IEnumerable<object[]>
    {
        
        public IEnumerator<object[]> GetEnumerator()
        {
            var inputData = new byte[4, 4]
            {
                { 1, 0, 0, 0 }, 
                { 1, 0, 0, 0 },
                { 1, 0, 0, 1 },
                { 0, 0, 0, 1 }
            };

            yield return new object[] 
            { 
                inputData, 1, 1
            };
                   
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}