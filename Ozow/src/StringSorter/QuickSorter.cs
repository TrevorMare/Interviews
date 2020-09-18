using System.Linq;
using StringSorter.Helpers;

namespace StringSorter
{

    public class QuickSorter : Interfaces.ISortingAlgorithm
    {

        public string SortingName => "Quick Sorter"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var inputArray = input.ToCharArray();

            QuickSort(inputArray, 0, inputArray.Count() - 1);

            return string.Concat(inputArray);
        }


        private void QuickSort(char[] inputArray, int startIndex, int endIndex)
        {
            var pivotIndex = 0;
            if (startIndex < endIndex)
            {
                pivotIndex = PartitionArray(inputArray, startIndex, endIndex);
        
                QuickSort(inputArray, startIndex, pivotIndex - 1);
                QuickSort(inputArray, pivotIndex + 1, endIndex);
            }
        }
        
        private int PartitionArray(char[] inputArray, int startIndex, int endIndex)
        {
            char endIndexValue = inputArray[endIndex];
            var workingIndex = startIndex - 1;
        
            for (int iIndex = startIndex; iIndex <= endIndex - 1; iIndex++)
            {

                if (inputArray[iIndex] <= endIndexValue)
                {
                    workingIndex++;
                    inputArray.Swap(workingIndex, iIndex);
                }
            }

            inputArray.Swap(workingIndex + 1, endIndex);

            return workingIndex + 1;
        }

    }

}