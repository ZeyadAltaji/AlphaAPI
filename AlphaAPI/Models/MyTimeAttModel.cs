using System;

namespace AlphaAPI.Models
{
    public class MyTimeAttModel
    {

        public MyTimeAttModel()
        {

        }

        public short? CompNo { get; set; }
        
        public long EmpNo { get; set; }

        public string comp_ename { get; set; }

        public DateTime SDate { get; set; }
        
        public DateTime? SDateFull { get; set; }

        public string EmpName { get; set; }
        
        public string EmpEngName { get; set; }

        public string Emp_In { get; set; }
        
        public string Emp_Out { get; set; }
        
        public string Tot_LeavesTF { get; set; }
        
        public double? Tot_Leaves { get; set; }

        public string Tot_OvertTF { get; set; }

        public double? Tot_Overt { get; set; }

        public Boolean? Vacation { get; set; }

        public int? ShiftNo { get; set; }

        public string EngDesc { get; set; }

        public string Tot_HrsTF { get; set; }

        public double? Tot_Hrs { get; set; }

        public Boolean? DayOff { get; set; }

        public string UnitDesc { get; set; }
        
        public string UnitDescEng { get; set; }

        public int? UnitCode { get; set; }

        public string WplaceEng { get; set; }
        
        public string Vac_EngDesc { get; set; }

        public string Prog_IN { get; set; }
        
        public string Prog_Out { get; set; }
        
        public string Daily_Prog { get; set; }

        public short? Hol_File { get; set; }
        
        public Boolean? Reject { get; set; }
        
        public string Brk_Out { get; set; }
        
        public string Brk_IN { get; set; }

        public double? Brk_Duration { get; set; }
        
        public string ProgEngDesc { get; set; }

        public Boolean? Ded_BrkHrs { get; set; }
        
        public double? Br_Duration { get; set; }

        public int? VacNo { get; set; }
        
        public string HolVacEngDesc { get; set; }
        
        public double? hrs_per_day { get; set; }

        public DateTime? Emp_INDT { get; set; }
        
        public DateTime? Emp_OUTDT { get; set; }

        public double? DelayHrs { get; set; }
        
        public double? SysUpd { get; set; }
        
        public Boolean? HasINPunch { get; set; }
        
        public Boolean? HasOUTPunch { get; set; }
        
        public short? INStatus { get; set; }
        
        public short? OUTStatus { get; set; }
        
        public string GridVacDesc { get; set; }
        
        public int? HistData { get; set; }

        public string ErrorText { get; set; }
    }
}
