namespace StringSorter.Interfaces
{

    public interface ISortingAlgorithm
    {

        string SortingName { get; }
        string ApplySort(string input);

    }


}