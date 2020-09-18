using System.Linq;

namespace StringSorter
{

    public class LinqLibrarySorter : Interfaces.ISortingAlgorithm
    {
        public string SortingName => "Linq Library"; 

        public string ApplySort(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            return string.Concat(input.ToCharArray().OrderBy(c => c));
        }
    }

}