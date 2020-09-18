using System;

namespace StringSorter.Helpers
{


    public static class ArrayHelper
    {

        public static void Swap(this char[] input, int leftIndex, int rightIndex)
        {
            if (leftIndex < 0)
            {
                throw new IndexOutOfRangeException($"{nameof(leftIndex)} cannot be less than 0.");
            }

            if (rightIndex < 0)
            {
                throw new IndexOutOfRangeException($"{nameof(rightIndex)} cannot be less than 0.");
            }

            if (leftIndex > input.Length - 1)
            {
                throw new IndexOutOfRangeException($"{nameof(leftIndex)} cannot be greater than array count.");
            }   

            if (rightIndex > input.Length - 1)
            {
                throw new IndexOutOfRangeException($"{nameof(rightIndex)} cannot be greater than array count.");
            }   

            var temp = input[leftIndex];
            input[leftIndex] = input[rightIndex];
            input[rightIndex] = temp;
        }


    }

}