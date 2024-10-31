using System;

namespace AlphaAPI.Models
{

    public class ConversationBulk
    {
        public int ReciverNum;
        public int SenderNum;
        public short CompNo;
        public string Message;
        public short seen;
        public int GroupId;
        public long refId;
    }
    public class NotificationBulk
    {
        public string UserRAction;
        public int OwnerUser;
        public int UsersTarget;
        public long FID;
        public short CompNo;
        public int RequestType;
        public short VacationOrLeave;
        public string form;
        public string ActionStat;
        public string fDescAr;
        public string EmpName;
        public string AdminName;
    }
    public class wfCL
    {
        public int TID;
        public short CompNo;
        public int FID;
        public string K1;
        public string K2;
        public string K3;
        public string K4;
        public string RAction;
        public string BUUser;
        public DateTime DateAdded;
        public string FunctionDesc;
        public string FunctionDescEn;
        public string TrDesc;
    }
    public class NotificationNewsAndEventsBulk
    {
        public short CompNo;
        public long ID;
        public string StartDate;
        public string Description;
        public string Subject;
    }

    public class NotificationTasksBulk
    {
        public short CompNo;
        public int OrderYear;
        public int OrderNo;
        public int StageCode;
        public string UserID;
        public int StageStatus;
        public string fDescAr;
    }
}
