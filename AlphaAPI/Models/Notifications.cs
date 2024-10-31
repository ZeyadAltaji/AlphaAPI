namespace AlphaAPI.Models
{
    public class Notifications
    {
        public int ID { get; set; }

        public int EmpNo { get; set; }

        public string PayEmpDesc { get; set; }

        public string ServiceTypeDesc { get; set; }

        public int VacType { get; set; }

        public string VacTypeDesc { get; set; }

        public string ItemDescription { get; set; }

        public double Quantity { get; set; }

        public string RemarksJustification { get; set; }

        public string DepartureDate { get; set; }

        public string ReturnDate { get; set; }

        public string StartTime { get; set; }

        public string StartDate { get; set; }

        public string EndTime { get; set; }

        public string EndDate { get; set; }

        public string RouteFrom { get; set; }

        public string RouteTo { get; set; }

        public string TravelerName { get; set; }

        public string Relation { get; set; }

        public string PassportNumber { get; set; }

        public string SubEmpDesc { get; set; }

        public string WPlaceDesc { get; set; }

        public double Basic_Salary { get; set; }

        public double RequiredAmount { get; set; }

        public double Aldd_amount { get; set; }

        public string DOB { get; set; }

        public string DateIssuse { get; set; }

        public string DateExpiry { get; set; }

        public string PlaceIssue { get; set; }

        public string Remarks { get; set; }

        public string TransDate { get; set; }

        public string TransTime { get; set; }

        public string DueBal { get; set; }

        public string KeyFDesc { get; set; }

        public int MonthNo { get; set; }

        public int RequeridHours { get; set; }

        public int RequeridMinut { get; set; }
        public int ActionStat { get; set; }
        public string FileName { get; set; }

        public string DateUploded { get; set; }

        public int FileSize { get; set; }

        public string ContentType { get; set; }

        public byte[] ArchiveData { get; set; }

        public long Serial { get; set; }

    }
}