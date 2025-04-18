using Puzzle2;
List<List<int>> SafetyReportList = SanitiseString.SanitiseReports();
var value =SafetyReport.SafteyReportValidation(SafetyReportList);
Console.WriteLine(value);