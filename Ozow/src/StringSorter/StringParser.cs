using System;
using System.Linq;

namespace StringSorter
{

    public static class StringParser
    {

        #region Methods
        public static string ParseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var validCharacters = string.Concat(input.ToLower()
                                    .ToCharArray()
                                    .Where(c => char.IsLetter(c))
                                    .Select(c => c));

            return validCharacters;
            
        } 
        #endregion

    }

}