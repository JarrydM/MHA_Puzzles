using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle2
{
    public class SafetyReport
    {
        #region Increments the reports
        public static int SafteyReportValidation(List<List<int>> reportsList)
        {
            int safeCounter = 0;
            foreach (var i in reportsList)
            {
                if(ReportEvaluation(i))
                {
                    //Increments the counter based on the evaluation
                    safeCounter++;
                }
            }
            return safeCounter;
        }
        #endregion

        #region Validating whether the reports are following the trend
        private static bool ReportEvaluation(List<int> reportList)
        {
            bool increasing=true;
            for(int i = 1; i < reportList.Count; i++)
            {
                int level = reportList[i] - reportList[i-1];
                if(i==1)
                {
                    //Used as a measure to determine whether the reports are increasing or decreasing
                    increasing = level > 0;
                }
                if((level < -3 || level > 3 || level == 0) || (increasing && level < 0) || (!increasing && level > 0))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
