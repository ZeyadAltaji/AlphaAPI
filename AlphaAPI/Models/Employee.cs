using System;

namespace AlphaAPI.Models
{
    public class Employee
    {
        public Employee()
        {
            IsLogin = false;
            CompNo = 0;
            EmpNum = 0;
            IsSupervisor = false;
            IsInterviewer = false;
            ErrorMessage = "";
        }
        public short CompNo { get; set; }
        public short GroupId { get; set; }
        public long EmpNum { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool DefaultDate { get; set; }
        public string EmpName { get; set; }
        public string EmpEngName { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsInterviewer { get; set; }
        public int ClientNo { get; set; }
        public bool IsLogin { get; set; }
        public bool IsResigned { get; set; }
        public string SocialNo { get; set; }
        public string ErrorMessage { get; set; }
    }
}