using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle5
{
    public class SleighLaunchSafetyManual
    {

        public static int CheckRules(string rules, string printResults)
        {
            List<int> orderedRules = GetRules(rules);
            List<int> middleNumbers = CheckTheRules(orderedRules, printResults);
            return AddMiddleNumbers(middleNumbers);
        }

        private static List<int> GetRules(string pageOrderingRules)
        {
            List<int> orderedRules = new List<int>();
            var splitOrders = pageOrderingRules.Split("\r\n");
            for (int i=0; i< splitOrders.Length; i++)
            {
                var splitRules = splitOrders[i].Split("|");
                CheckOrder(orderedRules, Convert.ToInt32(splitRules[0]), Convert.ToInt32(splitRules[1]));
            }
            return orderedRules;
        }


        private static void CheckOrder(List<int> orderedRules, int rule1, int rule2)
        {
            if(orderedRules.Contains(rule1) && orderedRules.Contains(rule2))
            {
                if(orderedRules.IndexOf(rule1) < orderedRules.IndexOf(rule2))
                {
                    return;
                }
                else
                {
                    orderedRules.Remove(rule1);
                    orderedRules.Insert(orderedRules.IndexOf(rule2),rule1);
                }
            }
            else
            {
                if(orderedRules.Contains(rule1) && ! orderedRules.Contains(rule2))
                {
                    orderedRules.Add(rule2);
                }
                else if(orderedRules.Contains(rule2) && !orderedRules.Contains(rule1))
                {
                    orderedRules.Insert(orderedRules.IndexOf(rule2), rule1);
                }
                else
                {
                    orderedRules.Add(rule2);
                    orderedRules.Add(rule1);
                }
            }
        }

        private static List<int> CheckTheRules(List<int> orderedRules,string printResults)
        {
            var splitString = printResults.Split("\r\n");
            int previousIndex = 0;
           
            List<int> middleNumber = new List<int>();
          
            for(int i =0; i < splitString.Length; i++) 
            {
                
                var splitNumbers = splitString[i].Split(',');
                List<int> printedManuals= new List<int>();
                bool flag = true;
                for (int j =0;j< splitNumbers.Length;j++)
                {
                   int currentIndex = orderedRules.IndexOf(Convert.ToInt32(splitNumbers[j]));

                   if (j==0 || currentIndex > previousIndex)
                   {
                        previousIndex = currentIndex;
                        printedManuals.Add(Convert.ToInt32(splitNumbers[j]));
                        continue;
                   }
                   else
                   {
                       flag = false;
                       break;
                   }
                }
                if (flag)
                {
                    middleNumber.Add(printedManuals[Convert.ToInt32((printedManuals.Count/2))]);
                }
            }
            return middleNumber;
        }

        private static int AddMiddleNumbers(List<int> middleNumbers)
        {
            int totalSum = 0;
            foreach (int i in middleNumbers)
            {
                totalSum += i;
            }
            return totalSum;
        }
    }
}
