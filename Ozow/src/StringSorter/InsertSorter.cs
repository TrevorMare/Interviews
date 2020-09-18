using System.Linq;
using StringSorter.Helpers;

namespace StringSorter
{

    public class InsertSorter : Interfaces.ISortingAlgorithm
    {

        public string SortingName => "Insert Sorter"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var inputArray = input.ToCharArray();
            bool flag = false;
            for (int iInner = 1; iInner < inputArray.Count(); iInner++) 
            {
                char currentValue = inputArray[iInner];
                flag = false;
                
                for (int iOuter = iInner - 1; iOuter >= 0 && flag == false;) 
                {
                    if (currentValue < inputArray[iOuter]) 
                    {
                        inputArray.Swap(iOuter, iOuter + 1);
                        iOuter--;
                    }
                    else 
                    {
                        flag = true;
                    }
                }
            }

            return string.Concat(inputArray);
        }
    }

}