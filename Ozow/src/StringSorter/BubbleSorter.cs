using StringSorter.Helpers;

namespace StringSorter
{

    public class BubbleSorter : Interfaces.ISortingAlgorithm
    {

        public string SortingName => "Bubble Sorter"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var inputArray = input.ToCharArray();

            for (int iOuter = 0; iOuter < inputArray.Length; iOuter++) {
                
                for (int iInner = 0; iInner < inputArray.Length - 1; iInner++) {
                    
                    if (inputArray[iInner] > inputArray[iInner + 1]) 
                    {
                        inputArray.Swap(iInner, iInner + 1);
                    }
                }
            }

            return string.Concat(inputArray);
        }
    }

}