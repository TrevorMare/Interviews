using System;
using System.Linq;

namespace StringSorter
{

    public class ArrayLibrarySorter : Interfaces.ISortingAlgorithm
    {

        public string SortingName => "Array Library"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            
            var inputArray = input.ToCharArray();
            
            Array.Sort<char>(inputArray);

            return string.Concat(inputArray);
        }
    }

}