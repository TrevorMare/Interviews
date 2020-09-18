using StringSorter.Helpers;

namespace StringSorter
{

    public class SelectionSorter : Interfaces.ISortingAlgorithm
    {

        public string SortingName => "Selection Sorter"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var inputArray = input.ToCharArray();

            int lowIndex; 
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                lowIndex = i;

                for (int index = i + 1; index < inputArray.Length; index++)
                {
                    if (inputArray[index] < inputArray[lowIndex])
                    {
                        lowIndex = index;
                    }
                }
                
                inputArray.Swap(i, lowIndex);
		    }

            return string.Concat(inputArray);
        }
    }

}