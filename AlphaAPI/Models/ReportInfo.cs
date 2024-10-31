using System.Collections.Generic;
using System;
using System.Data;

namespace AlphaAPI.Models
{
    public class ReportInformation
    {
        public string Id { get; set; }
        public DataSet myDataSet { get; set; }
        public string path { get; set; }
        public string ReportName { get; set; }
    }

    public static class ReportInfoManager
    {
        private static Dictionary<string, ReportInformation> dicReports = new Dictionary<string, ReportInformation>();

        public static void AddReport(string uniqueName, ReportInformation report)
        {
            string reportId = CalculateMD5Hash(uniqueName);
            report.Id = reportId;

            if (dicReports.ContainsKey(reportId))
            {
                dicReports.Remove(reportId);
                dicReports.Add(reportId, report);
                return;
            }

            dicReports.Add(reportId, report);
        }

        public static void ClearReports()
        {
            dicReports.Clear();
        }
        public static ReportInformation GetReport(string reportId)
        {
            if (dicReports.ContainsKey(reportId))
            {
                return dicReports[reportId];
            }

            return null;
        }

        private static string CalculateMD5Hash(string input)
        {
            return Guid.NewGuid().ToString();

        }

    }
}
