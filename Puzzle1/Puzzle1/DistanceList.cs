using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle1
{
    public class DistanceList
    {
        #region Calaculate the distance
        public static int AddDistances(List<int> locationList1, List<int> locationList2)
        {
            int totalDistance = 0;
            //Sorting the lists before adding them
            SortList(locationList1);
            SortList(locationList2);
            for (int i = 0; i < locationList1.Count; i++)
            {
                //Cakculating the total distance and validating that the values are positive
                totalDistance += (locationList1[i] - locationList2[i]) > 0 ? (locationList1[i] - locationList2[i]) : (-1 * (locationList1[i] - locationList2[i]));
            }
            return totalDistance;
        }
        #endregion

        #region Bubble Sort Algorithm
        private static void SortList(List<int> LocationList)
        {
            int size = LocationList.Count-1;
            for(int i=0; i < size;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (LocationList[j]> LocationList[j+1])
                    {
                        int tempVal = LocationList[j];
                        LocationList[j] = LocationList[j+1];
                        LocationList[j + 1] = tempVal;
                    }
                }
            }
        }
        #endregion

    }
}
