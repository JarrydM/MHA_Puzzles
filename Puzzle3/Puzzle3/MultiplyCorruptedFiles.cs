using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Puzzle3
{
    public class MultiplyCorruptedFiles
    {

        #region Matches the values from the string and multiplies the values
        public static int MatchValues(string corruptedValues)
        {
            int totalSum = 0;
            
             // Matches the values based on the sequence of character
             
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            Regex regex = new Regex(pattern);
            MatchCollection regMatch = regex.Matches(corruptedValues);
            //The following pattern is used as a mechanism to extract the values from the original regex sequence
            pattern = @"(\d{1,3}),(\d{1,3})";
            Regex regex2 = new Regex(pattern);
            foreach (Match m in regMatch)
            {
               Match match = regex2.Match(m.Value);
               totalSum += MultiplyValues(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value));
            }
            return totalSum;
        }
        #endregion

        private static int MultiplyValues(int value1, int value2)
        {
            return value1*value2;
        }


    }
}
