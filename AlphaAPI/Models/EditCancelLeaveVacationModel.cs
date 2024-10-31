using System;

namespace AlphaAPI.Models
{
    public class EditCancelLeaveVacationModel
    {
        public short CompNo { get; set; }

        public long EmpNo { get; set; }

        public string EmpName { get; set; }

        public long VR_Serial { get; set; }

        public string EngDesc { get; set; }

        public DateTime Start_Date = DateTime.Now;

        public DateTime End_Date = DateTime.Now.AddDays(1);

        public double Duration { get; set; }

        public string Address = "";

        public DateTime Req_Date = DateTime.Now;

        public short Status { get; set; }

        public string Emp_Notes = "";

        public short DaysHrs { get; set; }

        public long Supervisor_No { get; set; }

        public string Remarks = "";

        public string DaysHrsDesc = "";

        public string StatusDesc = "";

        public string LVDesc = "";

        public short LVCode { get; set; }

        public string DurationTF = "";

        public string Notes = "";

        public string Remark = "";

    }
}