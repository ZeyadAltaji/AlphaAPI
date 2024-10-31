using System;

namespace AlphaAPI.Models
{
    public class SalarySlipModel
    {
        public SalarySlipModel()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            GrossSalary = 0;
            MonthDays = 0;
            TotalDeductions = 0;
            AmountTrasnferredToBank = 0;
            TotalNetCash = 0;
            workedDays = 0;
            BodyTableSubData1 = "";
            BodyTableSubData2 = "";
            ErrorText = "";
        }

        public int Year { get; set; }

        public int Month { get; set; }

        public double GrossSalary { get; set; }

        public double TotalNetCash { get; set; }

        public int MonthDays { get; set; }

        public double TotalDeductions { get; set; }

        public double AmountTrasnferredToBank { get; set; }

        public int workedDays { get; set; }

        public string ErrorText { get; set; }

        public string BodyTableSubData1 { get; set; }

        public string BodyTableSubData2 { get; set; }

    }
}
