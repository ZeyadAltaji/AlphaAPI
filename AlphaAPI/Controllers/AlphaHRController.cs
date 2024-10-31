using AlphaAPI.BasicAuth;
using AlphaAPI.Helpers;
using AlphaAPI.Models;
using AlphaAPI.Services;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

[assembly: ApiController]
namespace AlphaAPI.Controllers
{
    [ActivatorUtilitiesConstructor]
    [ApiController]
    //[BasicAuth]
    public class AlphaHRController : ControllerBase
    {
        private readonly FirebaseApp _firebaseApp;
        private readonly FirebaseMessaging _firebaseMessaging;
        public class NotificationModel
        {
            public string Title { get; set; }
            public string Body { get; set; }
            public string Sound { get; set; } = "default";
        }

        public class GoogleNotification
        {
            public class DataPayload
            {
                public string Title { get; set; }
                public string Body { get; set; }
            }
            public string Priority { get; set; } = "high";
            public string Sound { get; set; } = "default";
            public DataPayload Data { get; set; }
            public DataPayload Notification { get; set; }
        }
        [HttpPost("sendToTopic")]
        public async Task<IActionResult> SendNotificationToTopic ()
        {

            //var notification = new NotificationModel
            //{
            //    Title = "نظام الخدمة الذاتية" ,
            //    Body = "طلب إجازة"
            //};

            // Use the fully qualified name for Message
            var message = new Message
            {
                Notification = new Notification
                {
                    Title = "نظام الخدمة الذاتية" ,
                    Body = "طلب إجازة"
                } ,
                Topic = "news" ,
                Data = new Dictionary<string , string>
                {
                    { "Type", "n" },
                            { "EmpName", "ahmad" },
                    { "FID", "45645645456" },
                    { "RequestType", "2" },
                    { "VacationOrLeave", "21" },
                    { "fDescAr", "طلب إجازة" },
                    { "addDate", DateTime.Now.ToString("yyyy-MM-dd") },
                    { "form", "admin" }
                }
            };

            string response = await _firebaseMessaging.SendAsync(message);
            return Ok(new { MessageId = response });
        }
        public static IConfigurationRoot Configuratio_ = null;
        public static IConfigurationRoot Configuration
        {
            get
            {
                if (Configuratio_ == null)
                {
                    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var builder = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("appsettings.json");
                    Configuratio_ = builder.Build();
                    return Configuratio_;
                }
                return Configuratio_;
            }
        }


        [HttpPost("MobileTest")]
        public object MobileTest()
        {
            DataTable result = (DataTable)excute("MobileTest", "", false, false, "", true);
            return Ok(new { result, error = false });
        }


        [AllowAnonymous]
        [HttpGet("UpdateApp")]
        public object UpdateApp(int android, string compNo, int version)
        {
            SqlConnection conn = new SqlConnection(string.Format("Server={0};Database={1};User ID=sa2;Password=sa2", "192.168.12.18", "MobileApps"));
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("UpdateApp");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@android", SqlDbType.Int).Value = android;
            cmd.Parameters.Add("@version", SqlDbType.Int).Value = version;
            cmd.Parameters.Add("@compNo", SqlDbType.BigInt).Value = compNo;
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            return Ok(new { result = dt, error = true });
        }

        #region Conversation

        [HttpPatch("UpdateApp")]
        public object UpdateApp(string command, string password)
        {
            //if (password != "@LphaGce$0ft#5")
            //    return Ok(new { result = "wrong password", error = true });

            if (password != "GceSoft01042000")
                return Ok(new { result = "wrong password", error = true });

            SqlCommand Cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.ConnectionString = connectionstring;
            conn.Open();
            Cmd.Connection = conn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = command;
            Cmd.ExecuteNonQuery();
            conn.Close();
            return Ok(new { result = "update success", error = false });
        }

        [AllowAnonymous]
        [HttpGet("test")]
        [RequestLimit("Test-Action", NoOfRequest = 5, Seconds = 10)]
        public object test()
        {
            return Ok(new { result = "success" });
        }

        [Route("Conversations"), HttpGet("Conversations"), HttpPut("Conversations")]
        [AllowAnonymous]
        public object Conversations(DateTime DateTime, int ReciverNum, int SenderNum, short CompNo, string Message, short seen, int GroupId, long refId)
        {
            Task.Factory.StartNew(() => ConversationsJob(DateTime.Now, ReciverNum, SenderNum, CompNo, Message, seen, GroupId, refId));
            return Ok(new { Id = DateTime.Now.ToString("yyyyMMddHHmmss"), result = DateTime.Now.ToString("yyyyMMddHHmmss"), error = false });
        }
        private void ConversationsJob(DateTime DateTime, int ReciverNum, int SenderNum, short CompNo, string Message, short seen, int GroupId, long refId)
        {
            //Parameters.AddWithValue("@DateTime", DateTime);
            //Parameters.AddWithValue("@ReciverNum", ReciverNum);
            //Parameters.AddWithValue("@SenderNum", SenderNum);
            //Parameters.AddWithValue("@CompNo", CompNo);
            //Parameters.AddWithValue("@Message", Message);
            //Parameters.AddWithValue("@GroupId", GroupId);
            //Parameters.AddWithValue("@seen", seen);
            //Parameters.AddWithValue("@refId", refId);
            //long Id = (long)excute("HRP_Mobile_Send", "", false, false, "Id");
            //hb.Clients.All.SendCoreAsync("NewConversation",
            //    new object[] { Id,  DateTime, ReciverNum, SenderNum, CompNo,Message,seen,GroupId,refId
            //});
            //var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", AlphaHRFireBase);
            //request.AddHeader("Content-Type", "application/json");
            //string body = @"{" +
            //              @"    ""to"": ""/topics/hr-m-ClientNumber-CompNox-ReciverNumx""," +
            //              @"    ""notification"": {" +
            //              @"        ""title"": ""نظام الخدمة الذاتية""," +
            //              @"        ""body"": ""رسالة جديدة""," +
            //              @"        ""sound"" : ""default""" +
            //              @"    }," +
            //              @"    ""data"": {" +
            //              @"        ""Type"": ""m""," +
            //              @"        ""Id"": ""Idx""," +
            //              @"        ""DateTime"": ""DateTimex""," +
            //              @"        ""ReciverNum"": ReciverNumx," +
            //              @"        ""SenderNum"": ""SenderNumx""," +
            //              @"        ""CompNo"": ""CompNox""," +
            //              @"        ""Message"": ""Messagex""," +
            //              @"        ""seen"": 0," +
            //              @"        ""GroupId"": 1," +
            //              @"        ""refId"": ""refIdx""" +
            //              @"    }," +
            //              @"    ""time_to_live"": 600" +
            //              @"}";
            //body = body.Replace("ClientNumber", ClientNumber);
            //body = body.Replace("ReciverNumx", ReciverNum.ToString());
            //body = body.Replace("Idx", Id.ToString());
            //body = body.Replace("DateTimex", DateTime.Now.ToString("yyyy-MM-dd"));
            //body = body.Replace("SenderNumx", SenderNum.ToString());
            //body = body.Replace("CompNox", CompNo.ToString());
            //body = body.Replace("Messagex", Message.ToString());
            //body = body.Replace("refIdx", refId.ToString());
            //body = body.Replace("addDatex", DateTime.Now.ToString("yyyy-MM-dd"));
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //client.Execute(request);
        }

        #endregion

        #region SignalR 

        [Route("notify"), HttpPost("notify")]
        [AllowAnonymous]
        public void Notify([FromBody] NotificationBulk c)
        {
            if (c == null)
                return;

            if (c.UserRAction == null)
                c.UserRAction = "";

            Task.Factory.StartNew(() => NotifyJob(c));
        }

        private async Task<object> NotifyJob(NotificationBulk c)
        {
            string response = "";
            string cc = c.UserRAction.Trim().ToLower();
            if (cc == "c" | cc == "r")
            {
                string topic = $"/topics/hr-ClientNumber-{c.CompNo}-UsersTarget-{c.OwnerUser}";
                string descr = c.UserRAction.Trim().ToLower() == "c" ? "موافقة " + c.fDescAr : "رفض " + c.fDescAr;
                var message = new Message
                {
                    Notification = new Notification
                    {
                        Title = "نظام الخدمة الذاتية" ,
                        Body = nameof(descr)
                    } ,
                    Topic = nameof(topic) ,
                    Data = new Dictionary<string , string>
                {
                    { "Type", "n" },
                    { "EmpName", nameof(c.EmpName) },
                    { "FID", nameof(c.FID) },
                    { "RequestType", nameof(c.RequestType) },
                    { "VacationOrLeave", nameof(c.VacationOrLeave) },
                    { "fDescAr", nameof(descr) },
                    { "addDate", DateTime.Now.ToString("yyyy-MM-dd") },
                    { "form", nameof(c.form) }
                }
                };

                response = await _firebaseMessaging.SendAsync(message);
                return Ok(new { MessageId = response });
                ////Task.Factory.StartNew(() => SendGoogle("n", c.OwnerUser, c.FID, c.CompNo, c.RequestType, c.VacationOrLeave, c.UsersTarget, c.form, c.ActionStat, descr, c.AdminName));
                //Task.Factory.StartNew(() =>  SendGoogle("n" , c.OwnerUser , c.FID , c.CompNo , c.RequestType , c.VacationOrLeave , c.UsersTarget , c.form , c.ActionStat , descr , c.AdminName));

                //Task.Factory.StartNew(() => SendSignalR("newAlert", c.OwnerUser, c.FID, c.CompNo, c.RequestType, c.VacationOrLeave, c.UsersTarget, c.form, c.ActionStat, descr, c.AdminName));
            }
            else
            {
                string topic = $"/topics/hr-ClientNumber-{c.CompNo}-UsersTarget-{c.UsersTarget}";
                string descr = c.UserRAction.Trim().ToLower() == "c" ? "موافقة " + c.fDescAr : "رفض " + c.fDescAr;
                var message = new Message
                {
                    Notification = new Notification
                    {
                        Title = "نظام الخدمة الذاتية" ,
                        Body = nameof(descr)
                    } ,
                    Topic = nameof(topic) ,
                    Data = new Dictionary<string , string>
                {
                    { "Type", "cr" },
                    { "EmpName", nameof(c.EmpName) },
                    { "FID", nameof(c.FID) },
                    { "RequestType", nameof(c.RequestType) },
                    { "VacationOrLeave", nameof(c.VacationOrLeave) },
                    { "fDescAr", nameof(descr) },
                    { "addDate", DateTime.Now.ToString("yyyy-MM-dd") },
                    { "form", nameof(c.form) }
                }
                };
                response = await _firebaseMessaging.SendAsync(message);
                return Ok(new { MessageId = response });

                //Task.Factory.StartNew(() => SendGoogle("cr", c.UsersTarget, c.FID, c.CompNo, c.RequestType, c.VacationOrLeave, c.OwnerUser, c.form, c.ActionStat, c.fDescAr, c.EmpName));
                //Task.Factory.StartNew(() =>  _notificationService.SendNotificationVacationOrLeave("cr" , c.UsersTarget , c.FID , c.CompNo , c.RequestType , c.VacationOrLeave , c.OwnerUser , c.form , c.ActionStat , c.fDescAr , c.EmpName));

            }
        }
         

        [Route("notifyNewsAndEvents"), HttpPost("notifyNewsAndEvents")]
        [AllowAnonymous]
        public void notifyNewsAndEvents([FromBody] NotificationNewsAndEventsBulk c)
        {
            if (c == null)
                return;


            Task.Factory.StartNew(() => NotifyNewsAndEventsJob(c));
        }

        private void NotifyNewsAndEventsJob(NotificationNewsAndEventsBulk c)
        {
            Task.Factory.StartNew(() => SendGoogleNewsAndEvents(c.ID, c.CompNo, c.StartDate, c.Description, c.Subject));
            Task.Factory.StartNew(() => SendSignalRNewsAndEvents("newAlert", c.ID, c.CompNo, c.StartDate, c.Description, c.Subject));
        }
        [Route("SendGoogleNewsAndEvents"), HttpGet("SendGoogleNewsAndEvents"), HttpPut("SendGoogleNewsAndEvents")]
        public async Task<object> SendGoogleNewsAndEvents (long FID, short CompNo, string StartDate, string Description, string Subject)
        {
            //var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", "key=AAAAutseYrM:APA91bEoVdqZryae-ICNYjmZu4iUzexi54tFTKd3m5NLDMg_Wfz-j6cridoCapS_Wn19Xn2VUJVUIrhnbPqCsKblNwzagV-ZNpIzd71_NMdPd3_U3ItjZIzsnZhOrN_HeXrNPw8QQIOW");
            //request.AddHeader("Content-Type", "application/json");
            //string body = @"{""to"": ""/topics/hr-ClientNumber"",""notification"": {""title"": ""نظام الخدمة الذاتية"",""body"":  ""Subjectx"",""sound"": ""alert.caf""},""data"":{""Type"":""news"",""FID"": ""FIDX"",""fDescAr"": ""fDescArx"",""Subject"": ""Subjectx"",""clientNo"": ""clientNox""},""time_to_live"": 600}";
            //body = body.Replace("ClientNumber", ClientNumber.ToString());
            //body = body.Replace("clientNox", ClientNumber.ToString());
            //body = body.Replace("fDescArx", Description.ToString());
            //body = body.Replace("FIDX", FID.ToString());
            //body = body.Replace("Subjectx", Subject.ToString());
            //body = body.Replace("CompNox", CompNo.ToString());
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //return response;
            string topic = $"/topics/hr-ClientNumber-{CompNo}";

            var notification = new NotificationModel
            {
                Title = "نظام الخدمة الذاتية" ,
                Body = nameof(Description)
            };

            var message = new FirebaseAdmin.Messaging.Message
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = notification.Title ,
                    Body = notification.Body ,
                } ,
                Topic = topic ,
                Data = new Dictionary<string , string>
{
    { "clientNo", ClientNumber.ToString() },
    { "FID", FID.ToString() },
    { "fDescAr", Description.ToString() },
    { "Subject", Subject.ToString() },
    { "CompNo", CompNo.ToString() },
}
            };

            string response = await _firebaseMessaging.SendAsync(message);
            return Ok(new { MessageId = response });
        }
        private void SendSignalRNewsAndEvents(string CRR, long FID, short CompNo, string StartDate, string Description, string Subject)
        {
            hb.Clients.All.SendCoreAsync(
                   CRR,
                   new object[] {
                        StartDate,
                        Subject,
                        FID,
                        CompNo,
                        Description,
                        DateTime.Now
             });
        }

        [Route("SendGoogle"), HttpGet("SendGoogle"), HttpPut("SendGoogle")]
        public async Task<object> SendGoogle (string CRR, int UsersTarget, long FID, short CompNo, int RequestType, short VacationOrLeave, int OwnerUser, string form, string ActionStat, string fDescAr, string EmpName)
        {
            //var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", "key=AAAAutseYrM:APA91bEoVdqZryae-ICNYjmZu4iUzexi54tFTKd3m5NLDMg_Wfz-j6cridoCapS_Wn19Xn2VUJVUIrhnbPqCsKblNwzagV-ZNpIzd71_NMdPd3_U3ItjZIzsnZhOrN_HeXrNPw8QQIOW");
            //request.AddHeader("Content-Type", "application/json");
            //string body = @"{""to"": ""/topics/hr-CRR-ClientNumber-CompNox-UsersTarget"",""notification"": {""title"": ""نظام الخدمة الذاتية"",""body"":  ""fDescArx"",""sound"": ""alert.caf""},""data"":{""Type"":""CRR"",""EmpName"": ""EmpNamex"",""FID"": ""FIDX"",""RequestType"": ""RequestTypex"",""VacationOrLeave"": ""VacationOrLeavex"",""fDescAr"": ""fDescArx"",""addDate"": ""addDatex"",""form"": ""formx""},""time_to_live"": 600}";
            //body = body.Replace("ClientNumber", ClientNumber);
            //body = body.Replace("UsersTarget", UsersTarget.ToString());
            //body = body.Replace("fDescArx", fDescAr.ToString());
            //body = body.Replace("EmpNamex", EmpName.ToString());
            //body = body.Replace("FIDX", FID.ToString());
            //body = body.Replace("RequestTypex", RequestType.ToString());
            //body = body.Replace("VacationOrLeavex", VacationOrLeave.ToString());
            //body = body.Replace("addDatex", DateTime.Now.ToString("yyyy-MM-dd"));
            //body = body.Replace("formx", form.ToString());
            //body = body.Replace("CRR", CRR.ToLower());
            //body = body.Replace("CompNox", CompNo.ToString());
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //return response;
            string topic = $"/topics/hr-ClientNumber-{CompNo}-UsersTarget-{UsersTarget}";

            var notification = new NotificationModel
            {
                Title = "نظام الخدمة الذاتية" ,
                Body = fDescAr
            };

            // Use the fully qualified name for Message
            var message = new FirebaseAdmin.Messaging.Message
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = notification.Title ,
                    Body = notification.Body ,
                } ,
                Topic = topic ,
                Data = new Dictionary<string , string>
{
    { "Type", CRR.ToLower() },
    { "EmpName", EmpName },
    { "FID", FID.ToString() },
    { "RequestType", RequestType.ToString() },
    { "VacationOrLeave", VacationOrLeave.ToString() },
    { "fDescAr", fDescAr },
    { "addDate", DateTime.Now.ToString("yyyy-MM-dd") },
    { "form", form }
}
            };

            string response = await _firebaseMessaging.SendAsync(message);
            return Ok(new { MessageId = response });

        }

        private void SendSignalR(string CRR, int UsersTarget, long FID, short CompNo, int RequestType, short VacationOrLeave, int OwnerUser, string form, string ActionStat, string fDescAr, string EmpName)
        {
            hb.Clients.All.SendCoreAsync(
                   CRR,
                   new object[] {
                        UsersTarget,
                        EmpName,
                        FID,
                        CompNo,
                        RequestType,
                        VacationOrLeave,
                        fDescAr,
                        DateTime.Now,
                        OwnerUser,
                        form,
                        ActionStat
             });
        }

        [Route("GAlert"), HttpGet("GAlert")]
        [AllowAnonymous]
        public void GAlert(int EmpNo, short CompNo, string Title, string Message, string rout)
        {
            hb.Clients.All.SendCoreAsync(
                "newGAlert",
                new object[] { EmpNo, CompNo, Title, Message, rout }
                );
        }

        [AllowAnonymous]
        [Route("SetConnectionId")]
        public object SetConnectionId(string connectionId, int CompNo, int EmpNo)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@connectionId", connectionId);
            DataTable result = (DataTable)excute("HRP_Mobile_Offline", "", false, false, "", true);
            return Ok(new { result });
        }
        private DataTable GetDataTable(string query)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            for (int i = Parameters.Count - 1; i >= 0; i--)
            {
                var p = Parameters[i];
                Parameters.Remove(p);
                cmd.Parameters.Add(p);
            }
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            Parameters = new SqlCommand().Parameters;
            return dt;
        }
        [Route("notifications")]
        public object notifications(short CompNo, short Lang, int EmpNo, short Srl = 0)
        {
            DataTable result = new DataTable();
            if (Srl == 0)
            {
                Parameters.AddWithValue("@CompNo", CompNo);
                Parameters.AddWithValue("@EmpNo", EmpNo);
                Parameters.AddWithValue("@Lang", Lang);
                result = (DataTable)excute("HRP_MOBILE_WORKFLOW", "", false, false, "", true);
            }
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@EmpNo", SqlDbType.BigInt).Value = EmpNo;
            DataTable news = (DataTable)excute("HRP_Mobile_NewsWithSubStitutes", "", false, false, "", true);
            return Ok(new { result, news });
        }
        #endregion

        #region Update
        [AllowAnonymous]
        [HttpGet("UpdateDataBase")]
        public DataTable UpdateDataBase(string token)
        {
            if (token == null)
                return new DataTable();

            //if (token != "@LphaGce$0ft#5")
            //    return new DataTable();


            if (token != "GceSoft01042000")
                return new DataTable();

            string IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            Parameters.AddWithValue("@IpAddress", IpAddress);
            DataTable result = (DataTable)excute("HRP_Mobile_UpdateP", "", false, false, "", true);
            return result;

        }

        [AllowAnonymous]
        [HttpGet("UpdateMe")]
        public object UpdateMe(string password)
        {
            if (password == null)
                return Ok(new { });

            //if (password != "@LphaGce$0ft#5")
            //    return Ok(new { });

            if (password != "GceSoft01042000")
                return Ok(new { });

            string html = string.Empty;
            //string url = @"http://gss.gcesoft.com.jo:8888/apicore/UpdateDataBase?token=" + password;
            string url = @"http://192.168.12.84/API/UpdateDataBase?token=" + password;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(dataStream))
                html = reader.ReadToEnd();

            return Ok(new { html });
        }
        #endregion

        #region Basic
        private IEnumerable<CboLeaveVac> LeaveTypeList;
        private IEnumerable<CboLeaveVac> VacationTypeList;
        private readonly IHubContext<HRHub> hb;
        private int COMMAND_TIMEOUT = 90;
        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database={1};User ID=Admin;Password=GceSoft01042000", sName, dbName);
                //return string.Format("Server={0};Database={1};User ID=Admin;Password=@LphaGce$0ft#5", sName, dbName);
            }
        }

        [AllowAnonymous]
        [Route("Home/Index")]
        public string Index()
        {
            return "Welcome ...";
        }

        public AlphaHRController(IHubContext<HRHub> hubContext)
        {
            hb = hubContext;
            string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot");
            string path = Path.Combine(wwwrootPath , "FcmNotification" , "gcesoft-78e0d-firebase-adminsdk-brzao-08a915fd84.json");

            if ( FirebaseApp.DefaultInstance == null )
            {
                _firebaseApp = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(path) ,
                });
            }
            else
            {
                _firebaseApp = FirebaseApp.DefaultInstance;
            }

            _firebaseMessaging = FirebaseMessaging.DefaultInstance;

        }

        [Route("WFnotify"), HttpGet("WFnotify")]
        [AllowAnonymous]
        public void WFnotify(long TID, short CompNo, short FID, string K1, string K2, string K3, string K4, string RAction, short BU, string BUUser, short BULvl, string BUUserAction, string OwnerUser, DateTime DateAdded, DateTime ActionDate, string TrDesc, string UserNotes, string ExecNot)
        {
            hb.Clients.All.SendCoreAsync("onNewRequest",
                new object[] {  TID, CompNo, FID, K1, K2, K3, K4, RAction, BU, BUUser, BULvl, BUUserAction, OwnerUser, DateAdded, ActionDate, TrDesc, UserNotes, ExecNot
            });
        }

        #endregion

        #region Basic2

        static object iif(bool expression, object truePart, object falsePart)
        {
            return expression ? truePart : falsePart;
        }

        [HttpGet("Connect"), HttpPost("Connect")]
        public ActionResult Connect(string compNo, string deviceID, string deviceMODEL, string deviceManufacturer, string fingerprint)
        {
            string myIP = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            SqlConnection conn = new SqlConnection(string.Format("Server={0};Database={1};User ID=sa2;Password=sa2", "192.168.12.18", "MobileApps"));
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Connect");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@compNo", SqlDbType.BigInt).Value = compNo;
            cmd.Parameters.Add("@deviceID", SqlDbType.VarChar).Value = deviceID;
            cmd.Parameters.Add("@myIP", SqlDbType.VarChar).Value = myIP;
            cmd.Parameters.Add("@deviceMODEL", SqlDbType.VarChar).Value = deviceMODEL;
            cmd.Parameters.Add("@deviceManufacturer", SqlDbType.VarChar).Value = deviceManufacturer;
            cmd.Parameters.Add("@fingerprint", SqlDbType.VarChar).Value = fingerprint;
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);

            int error = (int.Parse(dt.Rows[0]["error"].ToString()));

            if (error == 1)
            {
                var img = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot" , "files" , "companylogo" , compNo + ".png");
                if ( !System.IO.File.Exists(img) )
                {
                    img = Path.Combine(Directory.GetCurrentDirectory() , "wwwroot" , "files" , "companylogo" , "null.png");
                }
                byte [] imageArray = System.IO.File.ReadAllBytes(img);
                string imagex = Convert.ToBase64String(imageArray);
                compConnection result = new compConnection()
                {
                    compNo = compNo ,
                    company = dt.Rows [0] ["result"].ToString() ,
                    myURL = dt.Rows [0] ["myURL"].ToString() ,
                    myProtocol = dt.Rows [0] ["myProtocol"].ToString() ,
                    image = imagex ,
                    adunit = dt.Rows [0] ["AdUnit"].ToString() ,
                };
                return Ok(new { result , error = false });
            }
            else
            {
                compConnection result = new compConnection()
                {
                    compNo = compNo,
                    company = dt.Rows[0]["result"].ToString(),
                    myURL = "",
                    myProtocol = "",
                    image = "error",
                    adunit = dt.Rows[0]["AdUnit"].ToString(),
                    shortcut = dt.Rows[0]["shortcut"].ToString(),
                };

                return Ok(new { result, error = true });
            }

        }

        [NonAction]
        private string Encode(string value)
        {
            string result = "";
            int i2 = 0;
            for (int i = 0; i < value.Length; ++i)
            {
                i2 = i2 + 1;
                char ch = (char)(value.Substring(i, 1)[0] - i2);
                result += ch.ToString();
                if (i2 >= 2)
                    i2 = 0;
            }
            return result;
        }

        [NonAction]
        private static string Decode(string pWord)
        {
            int intCounter;
            int intSubCount;
            String strDecodedWord;

            strDecodedWord = "";
            intSubCount = 0;

            for (intCounter = 0; intCounter < pWord.Length; intCounter++)
            {
                intSubCount = intSubCount + 1;

                var s1 = pWord.Substring(intCounter, 1);
                var s2 = (int)s1[0];
                var s3 = s2 - intSubCount;
                var s4 = (char)s3;

                strDecodedWord = strDecodedWord + s4;

                if (intSubCount >= 2) intSubCount = 0;
            }

            return strDecodedWord;
        }


        [NonAction]
        private IEnumerable<CompParModel> GetAllCompPar(short CompNo)
        {
            List<CompParModel> result = new List<CompParModel>();
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = conn;
            SqlDataAdapter Da = new SqlDataAdapter();
            Cmd.Connection = conn;
            Cmd.CommandText = "HRP_Web_CompPar_Get";
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Da.SelectCommand = Cmd;
            Da.Fill(dt);
            if (dt.Rows.Count == 0)
                return result;

            result = dt.AsEnumerable().Select(row => new CompParModel
            {
                CompNo = (Int16)(iif(row["CompNo"] == DBNull.Value, 0, row["CompNo"])),
                Par_ID = (long)iif(row["Par_ID"] == DBNull.Value, 0, row["Par_ID"]),
                Par_Value = (double)(iif(row["Par_Value"] == DBNull.Value, 0, row["Par_Value"])),
                Par_NameAr = iif(row["Par_NameAr"] == DBNull.Value, "", row["Par_NameAr"]).ToString(),
                Par_NameEn = iif(row["Par_NameEn"] == DBNull.Value, "", row["Par_NameEn"]).ToString(),
                Note = iif(row["Note"] == DBNull.Value, "", row["Note"]).ToString()
            }).ToList();

            return result;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult Login(string UserName, string Password)
        {

            LoginModel a = new LoginModel()
            {
                Username = UserName.Trim(),
                Password = Password.Trim(),
            };
            Employee result = LoginEMP(a);
            if (result.IsLogin)
            {
                List<CompParModel> Compar = new List<CompParModel>();
                Compar = GetAllCompPar(result.CompNo).ToList();
                var UrlScreen = Compar.Where(a => a.Par_ID == 8).Select(a => a.Par_Value).FirstOrDefault();
                List<menu> menus = new List<menu>();
                Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Parameters.AddWithValue("@gLang", SqlDbType.SmallInt).Value = 1;
                DataTable dtx0 = (DataTable)excute("HRP_Mobile_GetMainMenu", "", false, false, "", true);
                menus.AddRange(dtx0.AsEnumerable().Select(row => new menu
                {
                    descr = row["descr"].ToString(),
                    id = int.Parse(row["id"].ToString())

                }).OrderBy(x => x.id).ToList());

                List<submenu> submenus = new List<submenu>();
                Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Parameters.AddWithValue("@gLang", SqlDbType.SmallInt).Value = 1;
                Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = result.EmpNum;
                DataTable dtx = (DataTable)excute("HRP_Mobile_GetMenu", "", false, false, "", true);
                submenus.AddRange(dtx.AsEnumerable().Select(row => new submenu
                {
                    color = row["color"].ToString(),
                    descr = row["descr"].ToString(),
                    img = row["img"].ToString(),
                    link = row["link"].ToString(),
                    id = int.Parse(row["id"].ToString()),
                    id2 = int.Parse(row["id2"].ToString()),
                    disabled = int.Parse(row["disabled"].ToString())
                }).ToList());

                menus = menus.OrderBy(x => x.id).ToList();
                submenus = submenus.OrderBy(x => x.id).ThenBy(x => x.id2).ToList();
                List<def> def = new List<def>();
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlCommand Cmd = new SqlCommand();
                Cmd.Connection = conn;
                SqlDataAdapter Da = new SqlDataAdapter();
                Cmd.Connection = conn;
                Cmd.CommandText = "HRP_Mobile_Def";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Da.SelectCommand = Cmd;
                Da.Fill(dt);

                def = dt.AsEnumerable().Select(row => new def
                {
                    parID = int.Parse(row["Par_ID"].ToString()),
                    parValue = double.Parse(row["Par_Value"].ToString()),
                    Value = double.Parse(row["Value"].ToString()),
                    parNameAr = row["Par_NameAr"].ToString(),
                    par_NameEn = row["par_NameEn"].ToString()
                }).ToList();

                Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Parameters.Add("@EmpNum", SqlDbType.SmallInt).Value = result.EmpNum;

                return Ok(new { result, menus, submenus, def });
            }
            else
            {
                Employee error = new Employee();
                error.ErrorMessage = result.ErrorMessage;
                return Ok(new { result = error });
            }
        }

        [Route("getVac")]
        public object getVac(short CompNo, int FromEmpNo, DateTime FromDate, DateTime ToDate, int gLang)
        {
            DataTable dt = GetDataTable(string.Format("select Vac_Code from Pay_Vac where vac_bal = 1 and compno = {0}", CompNo));
            List<Vac> vacs = new List<Vac>();
            foreach (DataRow vt in dt.Rows)
            {
                Parameters.AddWithValue("@CompNo", CompNo);
                Parameters.AddWithValue("@FromEmpNo", FromEmpNo);
                Parameters.AddWithValue("@FromVacType", vt.Field<short>("Vac_Code"));
                Parameters.AddWithValue("@FromDate", FromDate);
                Parameters.AddWithValue("@ToDate", ToDate);
                Parameters.AddWithValue("@BalOnly", 1);
                Parameters.AddWithValue("@gLang", gLang);
                DataTable result = (DataTable)excute("HRP_RptVacBal", "", false, false, "", true);
                if (result.Rows.Count > 0)
                    vacs.Add(new Vac
                    {
                        consBal = result.Rows[0].Field<decimal>("ConsBal"),
                        dueBal = result.Rows[0].Field<decimal>("DueBal"),
                        openingBal = result.Rows[0].Field<decimal>("OpeningBal"),
                        remBal = result.Rows[0].Field<decimal>("RemBal"),
                        roundedBal = result.Rows[0].Field<decimal>("RoundedBal"),
                        Added_Hrs = result.Rows[0].Field<decimal>("Added_Hrs"),
                        Vac_EngDesc = result.Rows[0].Field<string>("Vac_EngDesc")
                    });
            }

            return Ok(new { result = vacs });
        }

        [Route("General")]
        public object General(Dictionary<string, string> Parameter)
        {
            if (!Parameter.ContainsKey("pn")) return Ok(new { result = "pn error!!", error = true });
            string Procedure = Parameter.Where(x => x.Key == "pn").FirstOrDefault().Value;
            foreach (var p in Parameter.Where(x => x.Key != "pn"))
                Parameters.AddWithValue("@" + p.Key, p.Value);

            DataTable result = (DataTable)excute(Procedure, "", false, false, "", true);
            return Ok(new { result, error = false });
        }

        [HttpPost("Now")]
        [AllowAnonymous]
        public ActionResult Now()
        {
            string result = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            return Ok(new { result, error = false });
        }

        [NonAction]
        private Employee LoginEMP(LoginModel model)
        {
            string usrname = model.Username;
            string compShortName = "1";
            Employee resModel = new Employee();
            resModel.IsLogin = false;
            if (model.Username.Contains("@"))
            {
                usrname = model.Username.Split('@')[0];
                compShortName = model.Username.Split('@')[1];
            }

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(connectionstring);
                cmd.CommandText = "HRP_GetLogIn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompShortName", compShortName);
                cmd.Parameters.AddWithValue("@UserName", usrname);
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    DataRow rw = dt.Rows[0];
                    resModel.CompNo = short.Parse(rw["CompNo"].ToString());
                    resModel.GroupId = short.Parse(rw["GroupId"].ToString());
                    resModel.EmpNum = int.Parse(rw["EmpNum"].ToString());
                    resModel.ClientNo = int.Parse(rw["ClientNo"].ToString());
                    resModel.Username = rw["Username"].ToString();
                    resModel.Password = rw["UserPass"].ToString();
                    resModel.EmpName = rw["EmpName"].ToString();
                    resModel.EmpEngName = rw["EmpEngName"].ToString();
                    resModel.SocialNo = rw["SocialNo"].ToString();
                    resModel.IsSupervisor = bool.Parse(rw["IsSupervisor"].ToString());
                    resModel.IsInterviewer = bool.Parse(rw["IsInterviewer"].ToString());
                    resModel.IsResigned = bool.Parse(rw["IsResigned"].ToString());
                    if (resModel.IsResigned == false)
                    {
                        resModel.ErrorMessage = "هذا المستخدم موقوف !!! ";
                        resModel.IsLogin = false;
                    }
                    else
                        if (model.Password == Decode(resModel.Password))
                        resModel.IsLogin = true;
                    else
                        resModel.ErrorMessage = "كلمة المرور خاطئة";
                }
                else
                    resModel.ErrorMessage = "اسم الدخول غير مسجل";
            }
            catch (Exception ex)
            {
                resModel.ErrorMessage = ex.Message;
            }
            return resModel;
        }

        [NonAction]
        private double GetCompParValue(short CompNo, long Par_ID)
        {
            double res = 0;
            try
            {
                Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
                Parameters.Add("@Par_ID", SqlDbType.SmallInt).Value = Par_ID;
                res = (double)excute("HRP_Web_CompPar_GetByID", "", false, false, "Par_Value");
            }
            catch
            {
                res = 0;
            }
            return res;
        }

        [NonAction]
        private  int GetCalcleavePerMonth(short CompNo, int EmpNo, int LVType, DateTime startDate, double TotalMinutes)
        {
            int res = 0;

            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_CalcleavePerMonth");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompNo", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@leaveType", LVType);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@TotalMinutes", TotalMinutes);
                cmd.Parameters.Add("@PerMonth", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                res = (int)cmd.Parameters["@PerMonth"].Value;

            }
            catch (Exception)
            {
                res = 0;
            }
            
            return res;
        }

        [NonAction]
        private string InsertHRP_WorkFlow(short CompNo, long ID, int RequestType, int EmpNo, string Reject = null)
        {
            try
            {
                Parameters.AddWithValue("@Comp_num", CompNo);
                Parameters.AddWithValue("@FID", ID);
                Parameters.AddWithValue("@RequestType", RequestType);
                Parameters.AddWithValue("@EmpNo", EmpNo);
                Parameters.AddWithValue("@Reject", iif(Reject == null, "", Reject));
                excute("HRP_Web_AddWorkFlow");
                return "تم ارسال طلبك";
            }
            catch (Exception ex)
            {
                return "خطأ : " + ex.Message;
            }
        }

        [HttpPost("setImage")]
        public object setImage(int CompNo, int EmpNo, string base64)
        {
            byte[] uploadFile = Convert.FromBase64String(base64);
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@FileData", uploadFile);
            excute("HRP_Mobile_SetMyImage");
            return Ok(new { result = "تم تحديث الصورة بنجاح", error = false });
        }

        [HttpPost("InsertSocialAssistance")]
        public object InsertSocialAssistance(int ReqTypeSocialAssistance, short CompNo, int EmpNo, DateTime RequestDate, double RequiredAmount, string RequeridNote, string base64, string path)
        {
            DateTime rDate = new DateTime(RequestDate.Year, RequestDate.Month, RequestDate.Day);
            DateTime nDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (rDate < nDate)
                return Ok(new { result = "لا يمكن ادخال تاريخ في الماضي", error = true });

            if (base64 == null) base64 = "";

            UploadFile uploadFile = null;
            if (base64.Trim() != "")
            {
                Uri uri = new Uri(path);
                string filename = System.IO.Path.GetFileName(uri.LocalPath);
                byte[] FileByte = Convert.FromBase64String(base64);
                uploadFile = new UploadFile();
                uploadFile.ContentType = GetMimeType(Path.GetExtension(filename).ToString().ToLower());
                uploadFile.EmpID = EmpNo;
                uploadFile.File = FileByte;
                uploadFile.FileName = filename;
                uploadFile.FileSize = FileByte.Length;
            }
            if (null == RequeridNote)
                RequeridNote = "";

            int RequestType = 3;
            DateTime TransDate = DateTime.Now;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddSocialAssistanceRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompNo", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@ReqTypeSocialAssistance", ReqTypeSocialAssistance);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@ReqSocialAssistanceVal", RequiredAmount);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;
                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 3, EmpNo);
                if (uploadFile != null)
                {
                    Parameters.AddWithValue("@CompNo", CompNo);
                    Parameters.AddWithValue("@EmpNo", EmpNo);
                    Parameters.AddWithValue("@VRSerial", ID);
                    Parameters.AddWithValue("@RequestType", RequestType);
                    Parameters.AddWithValue("@ReqTypeSocialAssistance", ReqTypeSocialAssistance);
                    Parameters.AddWithValue("@RequestDate", RequestDate);
                    Parameters.AddWithValue("@TransDate", DateTime.Now);
                    Parameters.AddWithValue("@FileName", uploadFile.FileName);
                    Parameters.AddWithValue("@DateUploded", DateTime.Now);
                    Parameters.AddWithValue("@FileData", uploadFile.File);
                    Parameters.AddWithValue("@ContentType", uploadFile.ContentType);
                    Parameters.AddWithValue("@Filesize", uploadFile.FileSize);
                    excute("HRP_web_AddServiceRequestArchives");
                }


                return Ok(new { result = "تم ارسال طلبك", error = false });

            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });

            }
        }

        [HttpPost("InsertAdvanceRequest")]
        public object InsertAdvanceRequest(short CompNo, int EmpNo, DateTime RequestDate, double RequiredAmount, string RequeridNote, int MonthNo, string base64, string path)
        {
            DateTime rDate = new DateTime(RequestDate.Year, RequestDate.Month, RequestDate.Day);
            DateTime nDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (rDate < nDate)
                return Ok(new { result = "لا يمكن ادخال تاريخ في الماضي", error = true });

            if (base64 == null) base64 = "";

            UploadFile uploadFile = null;
            if (base64.Trim() != "")
            {
                Uri uri = new Uri(path);
                string filename = System.IO.Path.GetFileName(uri.LocalPath);
                byte[] FileByte = Convert.FromBase64String(base64);
                uploadFile = new UploadFile();
                uploadFile.ContentType = GetMimeType(Path.GetExtension(filename).ToString().ToLower());
                uploadFile.EmpID = EmpNo;
                uploadFile.File = FileByte;
                uploadFile.FileName = filename;
                uploadFile.FileSize = FileByte.Length;
            }

            if (null == RequeridNote) { RequeridNote = ""; }
            var t = Request.Headers["Authorization"];
            DateTime TransDate = DateTime.Now;
            int RequestType = 4;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddAdvanceRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@RequiredAmount", RequiredAmount);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.AddWithValue("@MonthNo", MonthNo);
                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;
                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 
                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 4, EmpNo);


                if (uploadFile != null)
                {
                    Parameters.AddWithValue("@CompNo", CompNo);
                    Parameters.AddWithValue("@EmpNo", EmpNo);
                    Parameters.AddWithValue("@VRSerial", ID);
                    Parameters.AddWithValue("@RequestType", RequestType);
                    Parameters.AddWithValue("@ReqTypeSocialAssistance", RequestType);
                    Parameters.AddWithValue("@RequestDate", RequestDate);
                    Parameters.AddWithValue("@TransDate", DateTime.Now);
                    Parameters.AddWithValue("@FileName", uploadFile.FileName);
                    Parameters.AddWithValue("@DateUploded", DateTime.Now);
                    Parameters.AddWithValue("@FileData", uploadFile.File);
                    Parameters.AddWithValue("@ContentType", uploadFile.ContentType);
                    Parameters.AddWithValue("@Filesize", uploadFile.FileSize);
                    excute("HRP_web_AddServiceRequestArchives");
                }


                return Ok(new { result = "تم ارسال طلبك", error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });
            }
        }

        [HttpPost("UploadDocument")]
        public object UploadDocument(short lang, short CompNo, int EmpNo, int ArchiveCode, string FileName, string Base64, string Description, string ContentType)
        {
            if (FileName == null) FileName = "";
            if (Description == null) Description = "";
            try
            {
                byte[] FileByte = Convert.FromBase64String(Base64);
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = connectionstring;
                conn.Open();
                SqlCommand cmd = new SqlCommand("Pay_AddArchiveInfo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@Emp_num", EmpNo);
                cmd.Parameters.AddWithValue("@ArchiveCode", ArchiveCode);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@FileName", FileName);
                cmd.Parameters.AddWithValue("@DateUploded", DateTime.Now);
                cmd.Parameters.AddWithValue("@FileSize", FileByte.Length);
                cmd.Parameters.AddWithValue("@ContentType", ContentType);
                cmd.Parameters.AddWithValue("@ArchiveData", FileByte);
                cmd.Parameters.AddWithValue("@Serial", 0);
                cmd.Parameters.AddWithValue("@ErrNo", ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                conn.Close();

                return Ok(new { result = lang == 1 ? "تم رفع الملف بنجاح" : "File uploaded successfully", error = false });
            }
            catch (Exception r)
            {
                return Ok(new { result = r.Message, error = true });

                throw;
            }
        }

        [HttpPost("OpenFile")]
        public object OpenFile(short CompNo, int EmpNo, int ArchiveCode, long Serial)
        {

            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("HRP_Mobile_OpenFile");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CompNo", CompNo);
            cmd.Parameters.AddWithValue("EmpNo", EmpNo);
            cmd.Parameters.AddWithValue("ArchiveCode", ArchiveCode);
            cmd.Parameters.AddWithValue("Serial", Serial);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;

            Da.Fill(dt);

            DataRow row = dt.Rows[0];
            string FileData = Convert.ToBase64String((byte[])(iif(row["FileData"] != DBNull.Value, (byte[])row["FileData"], null)));
            string FileName = row["FileName"].ToString();
            return Ok(new { FileData, FileName, error = false });
        }

        [HttpPost("InsertAdditionalWork")]
        public object InsertAdditionalWork(short CompNo, int EmpNo, DateTime RequestDate, DateTime RequestToDate, int RequeridHours, int RequeridMinut, string RequeridNote, int OverTCode = 1)
        {
            if (null == RequeridNote) { RequeridNote = ""; }
            int RequestType = 6;
            DateTime TransDate = DateTime.Now;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddAdditionalWorkRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@RequestToDate", RequestToDate);
                cmd.Parameters.AddWithValue("@RequeridHours", RequeridHours);
                cmd.Parameters.AddWithValue("@RequeridMinut", RequeridMinut);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.AddWithValue("@OverTCode", OverTCode);

                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;
                if (ID == 0)
                    return Ok(new { result = "خطأ : لا يمكن الادخال في هذا التاريخ بسبب احتساب رواتب هذا الشهر", error = true });

                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 
                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 6, EmpNo);
                return Ok(new { result = "تم ارسال طلبك", error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });
            }
        }

        [HttpPost("InsertAdvanceAllowance")]
        public object InsertAdvanceAllowance(short CompNo, int EmpNo, DateTime RequestDate, double RequiredAmount, string RequeridNote)
        {
            if (null == RequeridNote) { RequeridNote = ""; }
            int RequestType = 5;
            DateTime TransDate = DateTime.Now;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddAdvanceAllowanceRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@RequiredAmount", RequiredAmount);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;
                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 5, EmpNo);

                return Ok(new { result = "تم ارسال طلبك", error = false });

            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });

            }
        }

        [HttpPost("WorkFlowAction")]
        public object WorkFlowAction(short CompNo, int EmpNo, int ID, int RequestType, int ApproveOrReject, string Reject)
        {
            if (Reject == null) Reject = "";
            switch (RequestType)
            {
                case 13:
                    if (ApproveOrReject == 1)
                    {
                        Insert_ApprovelWorkFlow(CompNo, ID, 13, EmpNo, Reject);
                        UpdateHRP_WorkFlowStatus(CompNo, ID, 13, EmpNo);
                    }
                    else
                        InsertHRP_RejectWorkFlow(CompNo, ID, 13, EmpNo, Reject);


                    break;
                case 1: // اجازة
                    if (ApproveOrReject == 1)
                    {
                        UpdateStatisRequestLeave(CompNo, ID, EmpNo, Reject);
                    }
                    else
                    {
                        RejectStatisLeave(CompNo, ID, Reject, EmpNo);
                        SendEmailToSuperVisorReject(CompNo, ID);
                    }
                    break;
                case 2://الغاء اجازة
                    if (ApproveOrReject == 1)
                        UpdateStatisRequestCancelLeave(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisLeaveCancel(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 3:// معونة اجتماعية
                    if (ApproveOrReject == 1)
                        UpdateStatisSocialAssistance(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisSocialAssistance(CompNo, ID, Reject, EmpNo);
                    break;
                case 4: // سلفة
                    if (ApproveOrReject == 1)
                        UpdateStatisAdvance(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisAdvance(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 5:// طلب علاوة
                    if (ApproveOrReject == 1)
                    {

                    }
                    else
                    {

                    }
                    break;
                case 6://عمل اضافي
                    if (ApproveOrReject == 1)
                        UpdateStatisOvertime(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisOvertime(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 7:// خدمات عامة
                    if (ApproveOrReject == 1)
                        UpdateStatisPublicServices(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisPublicServices(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 8: // خدمة صحية
                    if (ApproveOrReject == 1)
                        UpdateStatisHealthServices(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisHealthServices(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 9:// تكنولوجيا معلومات
                    if (ApproveOrReject == 1)
                        UpdateStatisIT(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisIT(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 10://نسيان بصمة
                    if (ApproveOrReject == 1)
                        UpdateStatisForgetFingerprint(CompNo, ID, EmpNo, Reject);
                    else
                        RejectStatisForgetFingerprint(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 11://نسيان بصمة
                    if (ApproveOrReject == 1)
                        UpdateCalcOverTime(CompNo, ID, EmpNo, Reject);
                    else
                        RejectCalcOverTime(CompNo, ID, RequestType, Reject, EmpNo);
                    break;
                case 12://طلب عقوبة
                    UpdatePunshment(CompNo, ID, RequestType, EmpNo, Reject, ApproveOrReject == 1);
                    break;
                default:
                    break;
            }


            return Ok(new { result = "", error = false });
        }

        [NonAction]
        public string UpdatePunshment(short CompNo, int ID, int RequestType, int EmpNo, string Reject, bool approve)
        {
            if (approve)
            {
                Insert_ApprovelWorkFlow(CompNo, ID, 12, EmpNo, Reject);
                UpdateHRP_WorkFlowStatus(CompNo, ID, 12, EmpNo);
            }
            else
                InsertHRP_RejectWorkFlow(CompNo, ID, 12, EmpNo, Reject);

            return "done";
        }

        [NonAction]
        public string UpdateCalcOverTime(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestCalcOverTime");
            Insert_ApprovelWorkFlow(CompNo, ID, 11, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 11, EmpNo);
            return "done";
        }

        [NonAction]
        public string RejectCalcOverTime(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            InsertHRP_RejectWorkFlow(CompNo, ID, 11, EmpNo, Reject);
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            return "done";
        }

        [HttpPost("RptDailyAttendance")]
        public object RptDailyAttendance(short CompNo, Int64 EmpNo, DateTime? FromDate, DateTime? ToDate, short lang = 1)
        {
            List<MyTimeAttModel> result = new List<MyTimeAttModel>();

            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
            Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
            Parameters.Add("@FromEmp", SqlDbType.BigInt).Value = EmpNo;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = lang;
            DataTable dt = (DataTable)excute("HRP_RptDailyAttendance", "", false, false, "", true);
            if (dt.Rows.Count == 0)
                return Ok(new { result });

            result = dt.AsEnumerable().Select(row => new MyTimeAttModel
            {
                Brk_IN = iif(row["Brk_IN"] == DBNull.Value, "", row["Brk_IN"]).ToString(),
                Brk_Out = iif(row["Brk_Out"] == DBNull.Value, "", row["Brk_Out"]).ToString(),
                comp_ename = iif(row["comp_ename"] == DBNull.Value, "", row["comp_ename"]).ToString(),
                Daily_Prog = iif(row["Daily_Prog"] == DBNull.Value, "", row["Daily_Prog"]).ToString(),
                EmpEngName = iif(row["EmpEngName"] == DBNull.Value, "", row["EmpEngName"]).ToString(),
                Emp_In = iif(row["Emp_In"] == DBNull.Value, "", row["Emp_In"]).ToString(),
                Emp_Out = iif(row["Emp_Out"] == DBNull.Value, "", row["Emp_Out"]).ToString(),
                EngDesc = iif(row["EngDesc"] == DBNull.Value, "", row["EngDesc"]).ToString(),
                GridVacDesc = iif(row["GridVacDesc"] == DBNull.Value, "", row["GridVacDesc"]).ToString(),
                HolVacEngDesc = iif(row["HolVacEngDesc"] == DBNull.Value, "", row["HolVacEngDesc"]).ToString(),
                ProgEngDesc = iif(row["ProgEngDesc"] == DBNull.Value, "", row["ProgEngDesc"]).ToString(),
                Prog_IN = iif(row["Prog_IN"] == DBNull.Value, "", row["Prog_IN"]).ToString(),
                Prog_Out = iif(row["Prog_Out"] == DBNull.Value, "", row["Prog_Out"]).ToString(),
                Tot_HrsTF = iif(row["Tot_HrsTF"] == DBNull.Value, "", row["Tot_HrsTF"]).ToString(),
                Tot_LeavesTF = iif(row["Tot_LeavesTF"] == DBNull.Value, "", row["Tot_LeavesTF"]).ToString(),
                Tot_OvertTF = iif(row["Tot_OvertTF"] == DBNull.Value, "", row["Tot_OvertTF"]).ToString(),
                UnitDesc = iif(row["UnitDesc"] == DBNull.Value, "", row["UnitDesc"]).ToString(),
                Vac_EngDesc = iif(row["Vac_EngDesc"] == DBNull.Value, "", row["Vac_EngDesc"]).ToString(),
                WplaceEng = iif(row["WplaceEng"] == DBNull.Value, "", row["WplaceEng"]).ToString(),
                UnitDescEng = iif(row["UnitDescEng"] == DBNull.Value, "", row["UnitDescEng"]).ToString(),
                ErrorText = "",
                CompNo = Convert.ToInt16(iif(row["CompNo"] == DBNull.Value, 0, row["CompNo"])),
                Hol_File = Convert.ToInt16(iif(row["Hol_File"] == DBNull.Value, 0, row["Hol_File"])),
                INStatus = Convert.ToInt16(iif(row["INStatus"] == DBNull.Value, 0, row["INStatus"])),
                OUTStatus = Convert.ToInt16(iif(row["OUTStatus"] == DBNull.Value, 0, row["OUTStatus"])),
                HistData = Convert.ToInt32(iif(row["HistData"] == DBNull.Value, 0, row["HistData"])),
                ShiftNo = Convert.ToInt32(iif(row["ShiftNo"] == DBNull.Value, 0, row["ShiftNo"])),
                UnitCode = Convert.ToInt32(iif(row["UnitCode"] == DBNull.Value, 0, row["UnitCode"])),
                VacNo = Convert.ToInt32(iif(row["VacNo"] == DBNull.Value, 0, row["VacNo"])),
                EmpNo = Convert.ToInt64(iif(row["EmpNo"] == DBNull.Value, 0, row["EmpNo"])),
                Brk_Duration = Convert.ToDouble(iif(row["Brk_Duration"] == DBNull.Value, 0, row["Brk_Duration"])),
                Br_Duration = Convert.ToDouble(iif(row["Br_Duration"] == DBNull.Value, 0, row["Br_Duration"])),
                DelayHrs = Convert.ToDouble(iif(row["DelayHrs"] == DBNull.Value, 0, row["DelayHrs"])),
                Tot_Leaves = Convert.ToDouble(iif(row["Tot_Leaves"] == DBNull.Value, 0, row["Tot_Leaves"])),
                Tot_Overt = Convert.ToDouble(iif(row["Tot_Overt"] == DBNull.Value, 0, row["Tot_Overt"])),
                hrs_per_day = Convert.ToDouble(iif(row["hrs_per_day"] == DBNull.Value, 0, row["hrs_per_day"])),
                SysUpd = Convert.ToDouble(iif(row["SysUpd"] == DBNull.Value, 0, row["SysUpd"])),
                Tot_Hrs = Convert.ToDouble(iif(row["Tot_Hrs"] == DBNull.Value, 0, row["Tot_Hrs"])),
                DayOff = (Boolean?)(iif(row["DayOff"] == DBNull.Value, null, row["DayOff"])),
                Ded_BrkHrs = (Boolean?)(row["Ded_BrkHrs"]),
                HasINPunch = Convert.ToBoolean(row["HasINPunch"]),
                HasOUTPunch = Convert.ToBoolean(row["HasOUTPunch"]),
                Reject = (Boolean?)(row["Reject"]),
                Vacation = (Boolean?)(row["Vacation"]),
                Emp_INDT = (DateTime?)(iif(row["Emp_INDT"] == DBNull.Value, null, row["Emp_INDT"])),
                Emp_OUTDT = (DateTime?)(iif(row["Emp_OUTDT"] == DBNull.Value, null, row["Emp_OUTDT"])),
                SDate = (DateTime)(iif(row["SDate"] == DBNull.Value, null, row["SDate"])),
                SDateFull = (DateTime?)(iif(row["SDateFull"] == DBNull.Value, null, row["SDateFull"]))

            }).ToList();

            return Ok(new { result });
        }

        [HttpPost("SavePermission")]
        public object SavePermission(short CompNo, string notAllowedList, string al)
        {
            if (al == null) al = "";
            notAllowedList = notAllowedList.Replace("[", "").Replace("]", "");
            string delete = string.Format("delete from HRP_Mobile_Permision where compno = {0} and empNum in({1});", CompNo, notAllowedList);
            if (al.Trim() != "")
                al = "insert into HRP_Mobile_Permision " + al;

            SqlCommand Cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.ConnectionString = connectionstring;
            conn.Open();
            Cmd.Connection = conn;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = delete + al;
            Cmd.ExecuteNonQuery();
            conn.Close();
            return Ok(new { result = "تم الحفظ", error = false });
        }

        [HttpPost("GetFingerPrints")]
        public object GetFingerPrints(short CompNo, int empNum, int adminNum)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@empNum", empNum);
            Parameters.AddWithValue("@adminNum", adminNum);
            DataTable result = (DataTable)excute("HRP_Mobile_FingerPrintsLog", "", false, false, "", true);
            return Ok(new { result, error = false });
        }

        #endregion

        #region NONACTION
        [NonAction]//
        public string UpdateStatisHealthServices(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestHealthServices");
            Insert_ApprovelWorkFlow(CompNo, ID, 8, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 8, EmpNo);
            return "done";
        }
        [NonAction]//
        public string RejectStatisHealthServices(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 8, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string UpdateStatisIT(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestIT");
            Insert_ApprovelWorkFlow(CompNo, ID, 9, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 9, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisIT(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 9, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string UpdateStatisForgetFingerprint(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestForgetFingerprint");
            Insert_ApprovelWorkFlow(CompNo, ID, 10, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 10, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisForgetFingerprint(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            InsertHRP_RejectWorkFlow(CompNo, ID, 10, EmpNo, Reject);
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            return "done";
        }
        [NonAction]//
        public string UpdateStatisPublicServices(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestPublicServices");
            Insert_ApprovelWorkFlow(CompNo, ID, 7, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 7, EmpNo);
            return "done";
        }
        [NonAction]//
        public string RejectStatisPublicServices(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 7, EmpNo, Reject);
            return "done";
        }
        [NonAction]//
        public string UpdateStatisOvertime(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestOvertime");
            Insert_ApprovelWorkFlow(CompNo, ID, 6, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 6, EmpNo);
            return "done";
        }
        [NonAction]//
        public string RejectStatisOvertime(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 6, EmpNo, Reject);
            return "done";
        }
        [NonAction]//سلفة
        public string UpdateStatisAdvanceAllowance(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestAdvanceAllowance");
            Insert_ApprovelWorkFlow(CompNo, ID, 5, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 5, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisAdvanceAllowance(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 5, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string UpdateStatisAdvance(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestAdvance");
            Insert_ApprovelWorkFlow(CompNo, ID, 4, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 4, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisAdvance(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 4, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string UpdateStatisSocialAssistance(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestSocialAssistance");
            Insert_ApprovelWorkFlow(CompNo, ID, 3, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 3, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisSocialAssistance(short CompNo, int ID, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", 3);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 3, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string UpdateStatisRequestCancelLeave(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestLeave");
            Insert_ApprovelWorkFlow(CompNo, ID, 2, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 2, EmpNo);
            return "done";
        }
        [NonAction]
        public string RejectStatisLeaveCancel(short CompNo, int ID, int RequestType, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 2, EmpNo, Reject);
            return "done";
        }
        [NonAction]//
        public string UpdateStatisRequestLeave(short CompNo, int ID, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            excute("HRP_Web_UpdRequestLeave");
            Insert_ApprovelWorkFlow(CompNo, ID, 1, EmpNo, Reject);
            UpdateHRP_WorkFlowStatus(CompNo, ID, 1);
            return "done";
        }
        [NonAction]//
        public string RejectStatisLeave(short CompNo, int ID, string Reject, int EmpNo)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@ID", ID);
            Parameters.AddWithValue("@RequestType", 1);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdRejectRequestLeave");
            InsertHRP_RejectWorkFlow(CompNo, ID, 1, EmpNo, Reject);
            return "done";
        }
        [NonAction]
        public string Insert_ApprovelWorkFlow(short CompNo, long ID, int RequestType, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@FID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@Reject", iif(Reject == null, "", Reject));
            excute("HRP_Web_AddAppWorkFlow");
            return "done";
        }
        [NonAction]
        public string UpdateHRP_WorkFlowStatus(short CompNo, long ID, int RequestType, int EmpNo = 0)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@FID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@ActionBy", EmpNo);
            excute("HRP_Web_UpdWorkFlowStatus");
            return "done";
        }
        [NonAction]
        public string InsertHRP_RejectWorkFlow(short CompNo, long ID, int RequestType, int EmpNo, string Reject)
        {
            Parameters.AddWithValue("@Comp_num", CompNo);
            Parameters.AddWithValue("@FID", ID);
            Parameters.AddWithValue("@RequestType", RequestType);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@Reject", iif(Reject == null, "", Reject));
            excute("HRP_Web_RejectWorkFlow");
            return "done";
        }
        #endregion

        #region Done       

        [HttpPost("SaveTrans")]
        public object SaveTrans(short CompNo, int empNum, string trans)
        {
            List<TransDF> data = JsonConvert.DeserializeObject<List<TransDF>>(trans);
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("HRP_Mobile_SaveTrans");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompNo", CompNo);
            cmd.Parameters.AddWithValue("@empNum", empNum);
            setParameters(data, cmd);
            cmd.CommandTimeout = COMMAND_TIMEOUT;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            return Ok(new { result = "" });
        }
        void setParameters(List<TransDF> data, SqlCommand cmd)
        {
            DataTable tbl = new DataTable();
            #region HEADER
            tbl.Columns.Add("Area");
            tbl.Columns.Add("City");
            tbl.Columns.Add("Customer");
            tbl.Columns.Add("Reason");
            tbl.Columns.Add("Amount");
            tbl.Columns.Add("Date");
            foreach (var dt in data)
            {
                tbl.Rows.Add(
                dt.area,
                dt.city,
                dt.customer,
                dt.reason,
                dt.amount,
                dt.date
                );
            }
            #endregion
            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@data";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;
            cmd.Parameters.Add(Parameter);
        }

        [HttpPost("GetSaralySlip")]
        public object GetSaralySlip(short CompNo, int EmpNo, short Month = 0, short Year = 0, short Lang = 1)
        {
            SalarySlipModel result = GetMySaralySlip(CompNo, EmpNo, Month, Year, Lang);
            return Ok(new { result, error = false });
        }

        [HttpPost("InsertReqPublicServices")]
        public object InsertReqPublicServices(short CompNo, int EmpNo, int RequestTypePublicServ, DateTime RequestDate, string RequeridNote, string base64, string path)
        {
            DateTime rDate = new DateTime(RequestDate.Year, RequestDate.Month, RequestDate.Day);
            DateTime nDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (rDate < nDate)
                return Ok(new { result = "لا يمكن ادخال تاريخ في الماضي", error = true });

            if (base64 == null) base64 = "";

            UploadFile uploadFile = null;
            if (base64.Trim() != "")
            {
                Uri uri = new Uri(path);
                string filename = System.IO.Path.GetFileName(uri.LocalPath);
                byte[] FileByte = Convert.FromBase64String(base64);
                uploadFile = new UploadFile();
                uploadFile.ContentType = GetMimeType(Path.GetExtension(filename).ToString().ToLower());
                uploadFile.EmpID = EmpNo;
                uploadFile.File = FileByte;
                uploadFile.FileName = filename;
                uploadFile.FileSize = FileByte.Length;
            }

            if (null == RequeridNote) { RequeridNote = ""; }
            int RequestType = 7;
            DateTime TransDate = DateTime.Now;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddPublicServicesRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@RequestTypePublicServ", RequestTypePublicServ);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;

                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 7, EmpNo);


                if (uploadFile != null)
                {
                    Parameters.AddWithValue("@CompNo", CompNo);
                    Parameters.AddWithValue("@EmpNo", EmpNo);
                    Parameters.AddWithValue("@VRSerial", ID);
                    Parameters.AddWithValue("@RequestType", RequestType);
                    Parameters.AddWithValue("@RequestTypePublicServ", RequestTypePublicServ);
                    Parameters.AddWithValue("@RequestDate", RequestDate);
                    Parameters.AddWithValue("@TransDate", DateTime.Now);
                    Parameters.AddWithValue("@FileName", uploadFile.FileName);
                    Parameters.AddWithValue("@DateUploded", DateTime.Now);
                    Parameters.AddWithValue("@FileData", uploadFile.File);
                    Parameters.AddWithValue("@ContentType", uploadFile.ContentType);
                    Parameters.AddWithValue("@Filesize", uploadFile.FileSize);
                    excute("HRP_web_AddPublicServiceRequestArchives");
                }

                return Ok(new { result = "تم ارسال طلبك", error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });

            }
        }

        [HttpPost("InsertReqHealthServices")]
        public object InsertReqHealthServices(short CompNo, int EmpNo, int RequestTypeHealthServ, DateTime RequestDate, string RequeridNote, string base64, string path)
        {
            DateTime rDate = new DateTime(RequestDate.Year, RequestDate.Month, RequestDate.Day);
            DateTime nDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (rDate < nDate)
                return Ok(new { result = "لا يمكن ادخال تاريخ في الماضي", error = true });

            if (base64 == null) base64 = "";

            UploadFile uploadFile = null;
            if (base64.Trim() != "")
            {
                Uri uri = new Uri(path);
                string filename = System.IO.Path.GetFileName(uri.LocalPath);
                byte[] FileByte = Convert.FromBase64String(base64);
                uploadFile = new UploadFile();
                uploadFile.ContentType = GetMimeType(Path.GetExtension(filename).ToString().ToLower());
                uploadFile.EmpID = EmpNo;
                uploadFile.File = FileByte;
                uploadFile.FileName = filename;
                uploadFile.FileSize = FileByte.Length;
            }
            if (null == RequeridNote) { RequeridNote = ""; }
            DateTime TransDate = DateTime.Now;
            int RequestType = 8;
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_AddHealthServicesRequest");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Comp_num", CompNo);
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@RequestType", RequestType);
                cmd.Parameters.AddWithValue("@RequestTypeHealthServ", RequestTypeHealthServ);
                cmd.Parameters.AddWithValue("@TransDate", TransDate);
                cmd.Parameters.AddWithValue("@RequestDate", RequestDate);
                cmd.Parameters.AddWithValue("@RequeridNote", RequeridNote);
                cmd.Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                cmd.CommandTimeout = COMMAND_TIMEOUT;
                Da.SelectCommand = cmd;
                Da.Fill(dt);
                long ID = (long)cmd.Parameters["@VR_Serial"].Value;
                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 8, EmpNo);

                if (uploadFile != null)
                    if (uploadFile != null)
                    {
                        Parameters = new SqlCommand().Parameters;
                        Parameters.AddWithValue("@CompNo", CompNo);
                        Parameters.AddWithValue("@EmpNo", EmpNo);
                        Parameters.AddWithValue("@VRSerial", ID);
                        Parameters.AddWithValue("@RequestType", RequestType);
                        Parameters.AddWithValue("@RequestTypeHealthServ", RequestTypeHealthServ);
                        Parameters.AddWithValue("@RequestDate", RequestDate);
                        Parameters.AddWithValue("@TransDate", DateTime.Now);
                        Parameters.AddWithValue("@FileName", uploadFile.FileName);
                        Parameters.AddWithValue("@DateUploded", DateTime.Now);
                        Parameters.AddWithValue("@FileData", uploadFile.File);
                        Parameters.AddWithValue("@ContentType", uploadFile.ContentType);
                        Parameters.AddWithValue("@Filesize", uploadFile.FileSize);
                        excute("HRP_web_AddHealthServiceRequestArchives");
                    }

                return Ok(new { result = "تم ارسال طلبك", error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "خطأ : " + ex.Message, error = true });
            }
        }

        [HttpPost("GetAttendance")]
        public object GetAttendance(short CompNo, int EmpNo, DateTime FromDate, DateTime ToDate, short lang = 1)
        {
            List<MyTimeAttModel> result = new List<MyTimeAttModel>();

            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
            Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
            Parameters.Add("@FromEmp", SqlDbType.BigInt).Value = EmpNo;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = lang;
            DataTable dt = (DataTable)excute("HRP_Web_GetAttendance", "", false, false, "", true);

            if (dt.Rows.Count == 0)
                return Ok(new { result });

            result = dt.AsEnumerable().Select(row => new MyTimeAttModel
            {
                EmpNo = Convert.ToInt64(iif(row["EmpNo"] == DBNull.Value, 0, row["EmpNo"])),
                EmpEngName = iif(row["EmpEngName"] == DBNull.Value, "", row["EmpEngName"]).ToString(),
                Emp_In = iif(row["Emp_In"] == DBNull.Value, "", row["Emp_In"]).ToString(),
                Emp_Out = iif(row["Emp_Out"] == DBNull.Value, "", row["Emp_Out"]).ToString(),
                ShiftNo = Convert.ToInt32(iif(row["ShiftNo"] == DBNull.Value, 0, row["ShiftNo"])),
                EngDesc = iif(row["EngDesc"] == DBNull.Value, "", row["EngDesc"]).ToString(),
                SDate = (DateTime)(iif(row["SDate"] == DBNull.Value, null, row["SDate"])),
            }).ToList();

            return Ok(new { result });
        }

        [HttpPost("InsertReqIT")]
        public object InsertReqIT(short CompNo, int EmpNo, int RequestTypeIT, DateTime RequestDate, string RequeridNote)
        {
            DateTime rDate = new DateTime(RequestDate.Year, RequestDate.Month, RequestDate.Day);
            DateTime nDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (rDate < nDate)
                return Ok(new { result = "لا يمكن ادخال تاريخ في الماضي", error = true });

            if (RequeridNote == null)
                RequeridNote = "";

            int RequestType = 9;
            DateTime TransDate = DateTime.Now;
            try
            {
                Parameters.AddWithValue("@Comp_num", CompNo);
                Parameters.AddWithValue("@EmpNo", EmpNo);
                Parameters.AddWithValue("@RequestType", RequestType);
                Parameters.AddWithValue("@RequestTypeIT", RequestTypeIT);
                Parameters.AddWithValue("@TransDate", TransDate);
                Parameters.AddWithValue("@RequestDate", RequestDate);
                Parameters.AddWithValue("@RequeridNote", RequeridNote);
                Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;

                long ID = (long)excute("HRP_Web_AddITRequest", "@VR_Serial");

                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, ID, 9, EmpNo);

                return Ok(new { result = "تم ارسال طلبك", error = false });

            }
            catch (Exception ex)
            {
                return Ok(new { result = ex.Message, error = true });

            }
        }

        private string GetEmpVacBal(short CompNo, int EmpNo, int year, int LVType, string VacDays, DateTime DateNow)
        {
            string VacBal = "0";

            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@Year", SqlDbType.SmallInt).Value = year;
            Parameters.Add("@VacType", SqlDbType.SmallInt).Value = LVType;
            Parameters.Add("@VacDays", SqlDbType.Int).Value = VacDays;
            Parameters.Add("@VacEndDate", SqlDbType.SmallDateTime).Value = DateNow;
            Parameters.Add("@EmpVacBal", SqlDbType.Money).Direction = ParameterDirection.Output;

            string ID = excute("Pay_Web_CalcEmpVacBal", "@EmpVacBal").ToString();

            if (ID == null)
                VacBal = "0";
            else
                VacBal = ID;

            return VacBal;
        }

        [HttpPost("SaveNewLeaveVac")]
        public object SaveNewLeaveVac(short CompNo, int EmpNo, int Type, DateTime StartDate, DateTime EndDate, DateTime StartTime, DateTime EndTime, int LeaveType, int VacationType, string Address, string Substitute, string Notes, bool SendEmail, string LevType, string base64, string path, short Lang = 1)
        {
            if (Notes == null) Notes = "";
            if (Address == null) Address = "";

            if (Type == 0)
            //LVType = VacationType;
            {
                if (ClientNumber == "10343")
                    Parameters.AddWithValue("@EndDate", EndDate);
                Parameters.AddWithValue("@StartDate", StartDate);
                Parameters.AddWithValue("@CompNo", CompNo);
                Parameters.AddWithValue("@EmpNo", EmpNo);
                Parameters.AddWithValue("@VacationType", VacationType);
                Parameters.AddWithValue("@Notes", Notes);
                Parameters.AddWithValue("@Address", Address);
                Parameters.AddWithValue("@Lang", Lang);
                string Vresult = "";
                if (ClientNumber == "10343")
                    Vresult = (string)excute("HRP_Mobile_IsValidVacation_Hilwa", "", false, false, "result");
                else
                    Vresult = (string)excute("HRP_Mobile_IsValidVacation", "", false, false, "result");

                if (Vresult != "ok")
                {
                    return Ok(new { result = " error - " + Vresult, error = true });
                }
            }
            else
            // LVType = LeaveType;
            {
                Parameters.AddWithValue("@StartDate", StartTime);
                Parameters.AddWithValue("@EndDate", EndTime);
                Parameters.AddWithValue("@CompNo", CompNo);
                Parameters.AddWithValue("@EmpNo", EmpNo);
                Parameters.AddWithValue("@VacationType", LeaveType);
                Parameters.AddWithValue("@Notes", Notes);
                Parameters.AddWithValue("@Address", Address);
                Parameters.AddWithValue("@Lang", Lang);
                string Vresult = (string)excute("HRP_Mobile_IsValidLeave", "", false, false, "result");
                if (Vresult != "ok")
                {
                    return Ok(new { result = " error - " + Vresult, error = true });
                }
            }



            //}
            int LVType;

            if (Type == 0)
                LVType = VacationType;
            else
                LVType = LeaveType;

            SendEmail = false;
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select par_value from HRP_Web_CompPar where compno = " + CompNo + " and par_id = 5";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                while (dr.Read())
                    if (dr[0].ToString() == "1")
                        SendEmail = true;

            bool attach = false;

            SqlConnection co = new SqlConnection(connectionstring);
            co.Open();
            SqlCommand cdm = new SqlCommand();
            cdm.Connection = co;
            cdm.CommandText = "SELECT isnull(attach,1) FROM Pay_Vac WHERE(CompNo = " + CompNo + " ) and Vac_Code = " + LVType;
            SqlDataReader Dr__ = cdm.ExecuteReader();
            if (Dr__.HasRows)
                while (Dr__.Read())
                    attach = (bool)Dr__[0];

            co.Dispose();
            if (base64 == null) base64 = "";
            if (base64 == "" && attach && Type == 0)
                return Ok(new { result = " error - يجب تحميل ملف مرفق لهذا النوع من الاجازات", error = true });
            conn.Dispose();

            //if (StartDate.Year > DateTime.Now.Year || EndDate.Year > DateTime.Now.Year)
            //{
            //    return Ok(new { result = "لا يوجد لديك رصيد لهذا التاريخ . يرجى مراجعة قسم الموارد البشرية", error = true });
            //}

            UploadFile uploadFile = null;
            if (base64.Trim() != "")
            {
                Uri uri = new Uri(path);
                string filename = Path.GetFileName(uri.LocalPath);
                byte[] FileByte = Convert.FromBase64String(base64);
                uploadFile = new UploadFile();
                uploadFile.ContentType = GetMimeType(Path.GetExtension(filename).ToString().ToLower());
                uploadFile.EmpID = EmpNo;
                uploadFile.File = FileByte;
                uploadFile.FileName = filename;
                uploadFile.FileSize = FileByte.Length;
            }

            string result;
            string res;

            result = CalcDuration(CompNo, EmpNo, Type, LVType, StartDate, EndDate, StartTime, EndTime, Lang);
            if (result.Contains("error"))
                return Ok(new { result, error = true });


            if (result == "0")
                return Ok(new { result = " error - " + "No Interval ", error = true });


            //chkOld = NewLeaveVacationFunctions.CheckOldReqs( CompNo, EmpNo, Type, LVType, StartDate, EndDate, StartTime, EndTime, DateTime.Now, Lang);
            var due = GetDueDate(CompNo, EmpNo, StartDate.Year, LVType, Type);

            if (due == "0" )
                if (Lang == 1)
                    return Ok(new { result = " error - لا يوجد لديك رصيد الرجاء مراجعة قسم الموارد البشرية", error = true });
                else
                    return Ok(new { result = " error - You have no balance, please see the Human Resources Department", error = true });

            if (Type == 0)
            {
                bool VacBal = false;

                SqlConnection conn_ = new SqlConnection(connectionstring);
                conn_.Open();
                SqlCommand cmd_ = new SqlCommand();
                cmd_.Connection = conn_;
                cmd_.CommandText = "SELECT Vac_Bal  FROM Pay_Vac WHERE(CompNo = " + CompNo + " ) and Vac_Code = " + LVType;
                SqlDataReader dr_ = cmd_.ExecuteReader();
                if (dr_.HasRows)
                {
                    while (dr_.Read())
                        VacBal = (bool)dr_[0];
                }
                conn_.Dispose();



                var VacBalNegative = GetCompParValue(CompNo, 17); // 17 is qustion for level stick system Or Not 

                if (VacBalNegative == 1 && VacBal == true)
                {
                    var EmpVacBal = GetEmpVacBal(CompNo, EmpNo, DateTime.Now.Year, LVType, result, DateTime.Now);
                    if (Convert.ToDecimal(EmpVacBal) <= 0)
                        if (Lang == 1)
                            return Ok(new { result = "error - لا يوجد لديك رصيد كافي", error = true });
                        else
                            return Ok(new { result = "error - You have no Enough balance", error = true });
                }


                if (String.IsNullOrEmpty(Address))
                {
                    VacationTypeList = GetVacationTypeList(CompNo, Lang);
                    foreach (CboLeaveVac item in VacationTypeList)
                        if (item.Code == VacationType)
                            if (item.ForseHeader)
                                if (Lang == 1)
                                    return Ok(new { result = " error - يجب ادخال العنوان", error = true });
                                else
                                    return Ok(new { result = " error - You must insert the address", error = true });
                            else
                                break;
                }



                if (LVType == 2)
                {
                    var vallevelstick = GetCompParValue(CompNo, 14); // 14 is qustion for level stick system Or Not 
                    if (vallevelstick == 1)
                        if (uploadFile == null)
                            if (Lang == 1)
                                return Ok(new { result = " error - يجب تحميل ملف مرفق للاجازة المرضية", error = true });

                            else
                                return Ok(new { result = " error - You must download an attached file for the sick vacation", error = true });
                }
                res = SaveNewVacation(CompNo, EmpNo, VacationType, StartDate, EndDate, double.Parse(result), Address, Substitute, Notes, DateTime.Now, SendEmail, LevType, Lang, uploadFile, Type);

                if (res.Contains("error"))
                    return Ok(new { result = res, error = true });
            }
            else
            {///leave
                if (String.IsNullOrEmpty(Address))
                {
                    LeaveTypeList = GetLeaveTypeList(CompNo, Lang);
                    foreach (CboLeaveVac item in LeaveTypeList)
                        if (item.Code == LeaveType)
                        {
                            if (item.ForseHeader)
                                if (Lang == 1)
                                    return Ok(new { result = " error - يجب ادخال العنوان", error = true });
                                else
                                    return Ok(new { result = " error - You must insert the address", error = true });
                            else
                                break;
                        }
                }


                res = SaveNewLeave(CompNo, EmpNo, LeaveType, StartDate, StartTime, EndTime, double.Parse(result), Address, Substitute, Notes, DateTime.Now, SendEmail, LevType, Lang, Type);

                if (res.Contains("error"))
                {
                    return Ok(new { result = res, error = true });
                }

            }

            return Ok(new { result = res, error = false });
        }

        [HttpPost("MyLog")]
        public object MyLog(short CompNo, int EmpNo, short Lang = 1)
        {
            Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.AddWithValue("@EmpNo", SqlDbType.Int).Value = EmpNo;
            Parameters.AddWithValue("@Lang", SqlDbType.SmallInt).Value = Lang;
            DataTable result = (DataTable)excute("HRP_Mobile_Log", "", false, false, "", true);

            return Ok(new { result, error = false });
        }

        [HttpPost("DeleteLeave")]
        public object DeleteLeave(short CompNo, int EmpNo, long VR_Serial)
        {
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@VR_Serial", SqlDbType.Int).Value = VR_Serial;
            //Parameters.Add("@status", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            short Status = (short)excute("HRP_Mobile_GetStatus", "", false, false, "status");

            bool error = false;
            string result = "";
            if (Status == 1)
                result = _DeleteLeave(CompNo, EmpNo, VR_Serial);
            else if (Status == 2)
            {
                result = _CancelApproved(CompNo, VR_Serial, "Cancel My Approved Request - " + EmpNo.ToString(), EmpNo);
            }
            if (result.Contains("error")) error = true;

            return Ok(new { result, error });
        }

        [HttpPost("GetRequestHealthServicesBy_Id")]
        public object GetRequestHealthServicesBy_Id(string form, short CompNo, int id, short Lang = 1, int RequestType = 0)
        {
            Notifications result = new Notifications();
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@ID", id);
            Parameters.AddWithValue("@Lang ", Lang);
            switch (form)
            {
                case "trans":
                    Parameters.Clear();
                    Parameters.AddWithValue("FID", id);
                    Parameters.AddWithValue("CompNo", CompNo);
                    DataTable result111 = (DataTable)excute("HRP_Mobile_GetTrans", "", false, false, "", true);
                    return Ok(new { result = result111, error = false });
                case "overtime":
                    DataTable result11 = (DataTable)excute("HRP_MOBILE_GetOverTimeDetails", "", false, false, "", true);
                    result = result11.AsEnumerable().Select(row => new Notifications
                    {
                        ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                        PayEmpDesc = "",
                        ServiceTypeDesc = "طلب احتساب عمل اضافي",
                        DepartureDate = iif(row["TrDate"] == DBNull.Value, "", row["TrDate"]).ToString(),
                        TransDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                        Basic_Salary = 0,
                        Remarks = iif(row["OverTimeRequested"] == DBNull.Value, "", row["OverTimeRequested"]).ToString(),
                    }).FirstOrDefault();
                    break;
                case "punshment":
                    DataTable result_ = (DataTable)excute("HRP_Mobile_GetPunshmentDetails", "", false, false, "", true);
                    result = result_.AsEnumerable().Select(row => new Notifications
                    {
                        ID = Convert.ToInt32(iif(row["ID"] == DBNull.Value, 0, row["ID"])),
                        PayEmpDesc = row["EmpEngName"].ToString(),
                        ServiceTypeDesc = row["descr"].ToString(),
                        TransDate = iif(row["sDate"] == DBNull.Value, "", row["sDate"]).ToString(),
                        DepartureDate = iif(row["createdOn"] == DBNull.Value, "", row["createdOn"]).ToString(),
                        Basic_Salary = 0,
                        Remarks = iif(row["Comment"] == DBNull.Value, "", row["Comment"]).ToString(),
                        RemarksJustification = row["EmpName"].ToString(),
                    }).FirstOrDefault();
                    break;
                case "health":

                    DataTable result0 = (DataTable)excute("HRP_Web_GetRequestHealthServicesBy_Id", "", false, false, "", true);
                    string ArchiveData = result0.Rows[0]["ArchiveData"].ToString();
                    if (ArchiveData == "")
                    {
                        result = result0.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                            TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                            Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                            Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            DateUploded = null,
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                        }).FirstOrDefault();
                    }
                    else
                    {
                        result = result0.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                            TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                            Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                            Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            DateUploded = Convert.ToBase64String((byte[])(iif(row["ArchiveData"] != DBNull.Value, (byte[])row["ArchiveData"], null))),
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                        }).FirstOrDefault();
                    }

                    break;
                case "it":
                    DataTable result2 = (DataTable)excute("HRP_Web_GetRequestITBy_Id", "", false, false, "", true);
                    result = result2.AsEnumerable().Select(row => new Notifications
                    {
                        ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                        PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                        ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                        DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                        TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                        Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                        Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString()
                    }).FirstOrDefault();
                    break;

                case "fingerprint":
                    DataTable result02 = (DataTable)excute("HRP_Web_GetRequestForgetFingerprintBy_Id", "", false, false, "", true);
                    result = result02.AsEnumerable().Select(row => new Notifications
                    {
                        ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                        PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                        ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                        FileName = iif(row["KeyFDesc"] == DBNull.Value, "", row["KeyFDesc"]).ToString(),
                        DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                        TransTime = iif(row["Day_Time"] == DBNull.Value, 0, row["Day_Time"]).ToString(),
                        Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString()
                    }).FirstOrDefault();
                    break;
                case "general":
                    //
                    DataTable result3 = (DataTable)excute("HRP_Web_GetRequestPublicServicesBy_Id", "", false, false, "", true);
                    string ArchiveData2 = result3.Rows[0]["ArchiveData"].ToString();
                    if (ArchiveData2 == "")
                    {
                        result = result3.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                            TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                            Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                            Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            DateUploded = null,
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                        }).FirstOrDefault();
                    }
                    else
                    {
                        result = result3.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                            TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                            Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                            Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            DateUploded = Convert.ToBase64String((byte[])(iif(row["ArchiveData"] != DBNull.Value, (byte[])row["ArchiveData"], null))),
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                        }).FirstOrDefault();
                    }
                    break;
                case "finance":
                    if (RequestType == 4) // سلفة
                    {
                        DataTable result4 = (DataTable)excute("HRP_Web_GetRequestAdvanceBy_Id", "", false, false, "", true);
                        string ArchiveData4 = result4.Rows[0]["ArchiveData"].ToString();
                        if (ArchiveData4 == "")
                        {
                            result = result4.AsEnumerable().Select(row => new Notifications
                            {
                                ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                                PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                                ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                                DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                                TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                                RequiredAmount = Convert.ToDouble(iif(row["RequiredAmount"] == DBNull.Value, 0, row["RequiredAmount"])),
                                Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                                MonthNo = Convert.ToInt32(iif(row["MonthNo"] == DBNull.Value, 0, row["MonthNo"])),
                                Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                                Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                                DateUploded = null,
                                FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                                ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            }).FirstOrDefault();
                        }
                        else
                        {
                            result = result4.AsEnumerable().Select(row => new Notifications
                            {
                                ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                                PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                                ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                                DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                                TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                                RequiredAmount = Convert.ToDouble(iif(row["RequiredAmount"] == DBNull.Value, 0, row["RequiredAmount"])),
                                Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                                MonthNo = Convert.ToInt32(iif(row["MonthNo"] == DBNull.Value, 0, row["MonthNo"])),
                                Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                                Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                                DateUploded = Convert.ToBase64String((byte[])(iif(row["ArchiveData"] != DBNull.Value, (byte[])row["ArchiveData"], null))),
                                FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                                ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            }).FirstOrDefault();
                        }


                    }
                    if (RequestType == 3) // معونة
                    {
                        DataTable result4 = (DataTable)excute("HRP_Web_GetRequestSalaryIncreaseBy_Id", "", false, false, "", true);
                        string ArchiveData4 = result4.Rows[0]["ArchiveData"].ToString();
                        if (ArchiveData4 == "")
                        {
                            result = result4.AsEnumerable().Select(row => new Notifications
                            {
                                ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                                PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                                ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                                DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                                TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                                Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                                RequiredAmount = Convert.ToDouble(iif(row["ReqSocialAssistanceVal"] == DBNull.Value, 0, row["ReqSocialAssistanceVal"])),
                                Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                                Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                                DateUploded = null,
                                FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                                ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            }).FirstOrDefault();
                        }
                        else
                        {
                            result = result4.AsEnumerable().Select(row => new Notifications
                            {
                                ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                                PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                                ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                                DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                                TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                                RequiredAmount = Convert.ToDouble(iif(row["ReqSocialAssistanceVal"] == DBNull.Value, 0, row["ReqSocialAssistanceVal"])),
                                Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                                Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString(),
                                Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                                DateUploded = Convert.ToBase64String((byte[])(iif(row["ArchiveData"] != DBNull.Value, (byte[])row["ArchiveData"], null))),
                                FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                                ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            }).FirstOrDefault();
                        }
                    }
                    if (RequestType == 6)
                    {
                        //HRP_Web_GetRequestAdditionalWorkBy_Id
                        DataTable result7 = (DataTable)excute("HRP_Web_GetRequestAdditionalWorkBy_Id", "", false, false, "", true);
                        result = result7.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            TransDate = iif(row["Apt_Date"] == DBNull.Value, "", row["Apt_Date"]).ToString(),
                            Basic_Salary = Convert.ToDouble(iif(row["Basic_Salary"] == DBNull.Value, 0, row["Basic_Salary"])),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            DepartureDate = iif(row["RequestDate"] == DBNull.Value, "", row["RequestDate"]).ToString(),
                            DateExpiry = iif(row["RequestToDate"] == DBNull.Value, "", row["RequestToDate"]).ToString(),
                            RequeridHours = Convert.ToInt32(iif(row["RequeridHours"] == DBNull.Value, 0, row["RequeridHours"])),
                            RequeridMinut = Convert.ToInt32(iif(row["RequeridMinut"] == DBNull.Value, 0, row["RequeridMinut"])),
                            Remarks = iif(row["RequeridNote"] == DBNull.Value, "", row["RequeridNote"]).ToString()
                        }).FirstOrDefault();

                    }
                    break;
                case "vacations":
                    DataTable result5 = (DataTable)excute("HRP_Web_GetRequestLeavesBy_Id", "", false, false, "", true);
                    string ArchiveData5 = result5.Rows[0]["ArchiveData"].ToString();
                    if (ArchiveData5 == "")
                    {
                        result = result5.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            VacType = Convert.ToInt32(iif(row["VacType"] == DBNull.Value, "", row["VacType"])),
                            VacTypeDesc = iif(row["VacTypeDesc"] == DBNull.Value, "", row["VacTypeDesc"]).ToString(),
                            DepartureDate = iif(row["AddDate"] == DBNull.Value, "", row["AddDate"]).ToString(),
                            ReturnDate = iif(row["EndDate"] == DBNull.Value, "", row["EndDate"]).ToString(),
                            StartTime = iif(row["StartTime"] == DBNull.Value, "", row["StartTime"]).ToString(),
                            StartDate = iif(row["StartDate"] == DBNull.Value, "", row["StartDate"]).ToString(),
                            EndDate = iif(row["EndDate"] == DBNull.Value, "", row["EndDate"]).ToString(),
                            EndTime = iif(row["EndTime"] == DBNull.Value, "", row["EndTime"]).ToString(),
                            RouteTo = iif(row["Duration"] == DBNull.Value, "", row["Duration"]).ToString(),
                            TransDate = iif(row["TransDate"] == DBNull.Value, "", row["TransDate"]).ToString(),
                            TransTime = iif(row["TransTime"] == DBNull.Value, "", row["TransTime"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            Remarks = iif(row["Emp_Notes"] == DBNull.Value, "", row["Emp_Notes"]).ToString(),
                            DueBal = iif(row["DueBal"] == DBNull.Value, "0", row["DueBal"]).ToString(),
                            DateUploded = null,
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            ActionStat = Convert.ToInt32(iif(row["ActionStat"] == DBNull.Value, 0, row["ActionStat"])),
                        }).FirstOrDefault();
                    }
                    else
                    {
                        result = result5.AsEnumerable().Select(row => new Notifications
                        {
                            ID = Convert.ToInt32(iif(row["VR_Serial"] == DBNull.Value, 0, row["VR_Serial"])),
                            PayEmpDesc = iif(row["PayEmpDesc"] == DBNull.Value, "", row["PayEmpDesc"]).ToString(),
                            ServiceTypeDesc = iif(row["RequestType"] == DBNull.Value, "", row["RequestType"]).ToString(),
                            VacType = Convert.ToInt32(iif(row["VacType"] == DBNull.Value, "", row["VacType"])),
                            VacTypeDesc = iif(row["VacTypeDesc"] == DBNull.Value, "", row["VacTypeDesc"]).ToString(),
                            DepartureDate = iif(row["AddDate"] == DBNull.Value, "", row["AddDate"]).ToString(),
                            ReturnDate = iif(row["EndDate"] == DBNull.Value, "", row["EndDate"]).ToString(),
                            StartTime = iif(row["StartTime"] == DBNull.Value, "", row["StartTime"]).ToString(),
                            EndTime = iif(row["EndTime"] == DBNull.Value, "", row["EndTime"]).ToString(),
                            StartDate = iif(row["StartDate"] == DBNull.Value, "", row["StartDate"]).ToString(),
                            EndDate = iif(row["EndDate"] == DBNull.Value, "", row["EndDate"]).ToString(),
                            RouteTo = iif(row["Duration"] == DBNull.Value, "", row["Duration"]).ToString(),
                            TransDate = iif(row["TransDate"] == DBNull.Value, "", row["TransDate"]).ToString(),
                            TransTime = iif(row["TransTime"] == DBNull.Value, "", row["TransTime"]).ToString(),
                            Serial = Convert.ToInt64(iif(row["Serial"] == DBNull.Value, 0, row["Serial"])),
                            Remarks = iif(row["Emp_Notes"] == DBNull.Value, "", row["Emp_Notes"]).ToString(),
                            DueBal = iif(row["DueBal"] == DBNull.Value, "0", row["DueBal"]).ToString(),
                            DateUploded = Convert.ToBase64String((byte[])(iif(row["ArchiveData"] != DBNull.Value, (byte[])row["ArchiveData"], null))),
                            FileSize = Convert.ToInt32(iif(row["FileSize"] == DBNull.Value, 0, row["FileSize"])),
                            ContentType = iif(row["ContentType"] == DBNull.Value, "", row["ContentType"]).ToString(),
                            ActionStat = Convert.ToInt32(iif(row["ActionStat"] == DBNull.Value, 0, row["ActionStat"])),
                        }).FirstOrDefault();
                    }

                    break;
                default:
                    Parameters.Clear();
                    Parameters.AddWithValue("FID", id);
                    Parameters.AddWithValue("CompNo", CompNo);
                    Parameters.AddWithValue("form", form);
                    Parameters.AddWithValue("Lang", Lang);
                    DataTable result00 = (DataTable)excute("HRP_Mobile_GetWFDetails", "", false, false, "", true);
                    return Ok(new { result = result00, error = false });
            }
            return Ok(new { result, error = false });
        }

        [HttpPost("InsertInOutPunch")]
        public object InsertInOutPunch(short CompNo, string IsIn, int EmpNo, DateTime DayDate, string DayTime, string Note)
        {

            DateTime UsrDate;
            DateTime UsrTime;
            try
            {
                UsrDate = DayDate;
                UsrTime = DateTime.Parse(DayTime);
            }
            catch
            {
                UsrDate = DayDate;
                UsrTime = DateTime.Parse(DayTime);
            }

            DateTime newDate_Full = new DateTime(UsrDate.Year, UsrDate.Month, UsrDate.Day, UsrTime.Hour, UsrTime.Minute, UsrTime.Second);

            if (Note == null) Note = "";
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@RequestType", 10);
            Parameters.AddWithValue("@TransDate", DateTime.Now);
            Parameters.AddWithValue("@KeyF", IsIn);
            Parameters.AddWithValue("@DayDate", newDate_Full);
            Parameters.AddWithValue("@DayTime", DayTime);
            Parameters.AddWithValue("@RequeridNote", Note);
            Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
            long ID = (long)excute("HRP_Web_InsertForgetFingerprintRequests", "@VR_Serial");

            var valApproval = GetCompParValue(CompNo, 10);

            if (valApproval == 1)
                InsertHRP_WorkFlow(CompNo, ID, 10, EmpNo);

            return Ok(new { result = "تم ارسال طلبك", error = false });
        }

        [HttpPost("Mobile_NewAttendance")]
        public object Mobile_NewAttendance(short CompNo, int EmpNo, short CheckIn, string latitude, string longitude, string imei = "")
        {
            if (imei == null) imei = "";
            bool isNumericLatitude = double.TryParse(latitude, out double n);
            bool isNumericLongitude = double.TryParse(longitude, out double np);

            if (!isNumericLatitude || !isNumericLongitude)
            {
                return Ok(new { result = "الموقع غير صحيح", error = true });
            }

            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNo", EmpNo);
            Parameters.AddWithValue("@CheckIn", CheckIn);
            Parameters.AddWithValue("@latitude", latitude);
            Parameters.AddWithValue("@longitude", longitude);
            Parameters.AddWithValue("@imei", imei);
            string result = (string)excute("HRP_Mobile_NewAttendance", "", false, false, "result");
            return Ok(new { result, error = result == "تم ارسال طلبك" ? false : true });


        }

        [HttpPost("ChangeUserPassword")]
        public object ChangeUserPassword(short CompNo, int EmpID, string OldPassword, string NewPassword, string ConfPassword, short gLang = 1)
        {
            string result = "";
            bool error = false;
            try
            {
                if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(ConfPassword) || string.IsNullOrEmpty(ConfPassword))
                {
                    if (gLang == 1)
                        result = " error - الرجاء تعبئة جميع البيانات";
                    else
                        result = " error - Fill All Data";

                    error = true;
                }
                if (NewPassword != ConfPassword)
                {
                    if (gLang == 2)
                        result = " error - الرقم السري والتأكيد غير متطابقين";
                    else
                        result = " error - password and confirmation dosn't match";

                    error = true;
                }

                if (!error)
                {
                    Parameters.AddWithValue("@CompNo", CompNo);
                    Parameters.AddWithValue("@EmpNo", EmpID);
                    Parameters.AddWithValue("@NewPass", NewPassword);
                    Parameters.AddWithValue("@OldPass", OldPassword);
                    Parameters.AddWithValue("@ConfirmPass", ConfPassword);
                    DataTable r = (DataTable)excute("HRP_Mobile_UpdatePasswod", "", false, false, "", true);

                    error = !(bool)r.Rows[0]["valid"];
                    if (gLang == 1)
                        result = r.Rows[0]["ar"].ToString();
                    else
                        result = r.Rows[0]["en"].ToString();

                }
                return Ok(new { result, error });
            }
            catch (Exception ex)
            {
                result = " error - " + ex.Message;
                return Ok(new { result, error = true });
            }

        }
        #endregion

        #region NonAction
        [NonAction]
        private SalarySlipModel GetMySaralySlip(short CompNo, int EmpNo, short Month, short Year, short gLang = 2)
        {
            SalarySlipModel salaryObject = new SalarySlipModel();
            salaryObject.Month = Month;
            salaryObject.Year = Year;
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@FromEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@ToEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@Month", SqlDbType.SmallInt).Value = Month;
            Parameters.Add("@Year", SqlDbType.SmallInt).Value = Year;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = gLang;
            DataTable dt = (DataTable)excute("HRP_RptEmpHistSalaryCoupon", "", false, false, "", true);
            if (dt.Rows.Count == 0)
                return salaryObject;
            salaryObject.GrossSalary = Convert.ToDouble(dt.Rows[0]["TotalAmt"]);
            salaryObject.TotalNetCash = Convert.ToDouble(dt.Rows[0]["CASH"]);
            salaryObject.AmountTrasnferredToBank = Convert.ToDouble(dt.Rows[0]["BANK"]);
            salaryObject.TotalDeductions = Convert.ToDouble(dt.Rows[0]["TotalDisc"]);
            salaryObject.MonthDays = Convert.ToInt32(dt.Rows[0]["MonDays"]);
            salaryObject.workedDays = Convert.ToInt32(dt.Rows[0]["Days"]);
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@FromEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@ToEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@Month", SqlDbType.SmallInt).Value = Month;
            Parameters.Add("@Year", SqlDbType.SmallInt).Value = Year;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = gLang;
            DataTable dt2 = (DataTable)excute("HRP_RptEmpHistSalaryCouponSub1", "", false, false, "", true);
            salaryObject.BodyTableSubData1 = "";
            foreach (DataRow row in dt2.Rows)
            {
                salaryObject.BodyTableSubData1 += row["Aldd_DescLang"].ToString() + " : ";
                double amount = Convert.ToDouble(iif(row["PayAmt"] == DBNull.Value, 0, row["PayAmt"]));
                salaryObject.BodyTableSubData1 += amount.ToString("0.00");
                salaryObject.BodyTableSubData1 += "***";
            }
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@FromEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@ToEmp", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@Month", SqlDbType.SmallInt).Value = Month;
            Parameters.Add("@Year", SqlDbType.SmallInt).Value = Year;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = gLang;
            DataTable dt3 = (DataTable)excute("HRP_RptEmpHistSalaryCouponSub2", "", false, false, "", true);
            salaryObject.BodyTableSubData2 = "";
            foreach (DataRow row in dt3.Rows)
            {
                salaryObject.BodyTableSubData2 += row["Aldd_DescLang"].ToString() + " : ";
                double amount = Convert.ToDouble(iif(row["PayAmt"] == DBNull.Value, 0, row["PayAmt"]));
                salaryObject.BodyTableSubData2 += amount.ToString("0.00");
                salaryObject.BodyTableSubData2 += "***";
            }
            return salaryObject;
        }


        [NonAction]
        private string _DeleteLeave(short CompNo, int EmpNo, long VR_Serial)
        {
            try
            {
                Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
                Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
                Parameters.Add("@VRSerial", SqlDbType.BigInt).Value = VR_Serial;
                excute("HRP_DeleteLeave");
                { return " تم حذف الطلب "; }

            }
            catch (Exception ex)
            { return " error - " + ex.Message; }
        }
        [NonAction]
        private string _CancelApproved(short CompNo, long VR_Serial, string CancelNote, int EmpNo)
        {

            try
            {
                Parameters.Add("@VRSerial", SqlDbType.BigInt).Value = VR_Serial;
                Parameters.Add("@EmpNote", SqlDbType.VarChar).Value = CancelNote;
                excute("HRP_CancelApprovedReq");
                var valApproval = GetCompParValue(CompNo, 10); // 10 is qustion for approval system Or Not 
                if (valApproval == 1)
                    InsertHRP_WorkFlow(CompNo, VR_Serial, 2, EmpNo);
                { return " تم ارسال طلب الغاء "; }
            }
            catch (Exception ex)
            { return " error - " + ex.Message; }

        }

        [NonAction]
        private string CalcDuration(short CompNo, int EmpNo, int type, int LVType, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime, short lang = 1)
        {
            DateTime now = DateTime.Now;
            if ((type == 0 && startDate > endDate) || (type == 1 && startTime > endTime))
                if (lang == 1)
                    return " error - تاريخ/وقت البداية يجب ان يكون اقل من تاريخ/وقت النهاية";
                else
                    return " error - Start date/time must be less than end date/time ";


            if (type == 0)
            {
                double par = GetCompParValue(CompNo, 2); // 2 is Vacation Parameter

                //TimeSpan tsDays = endDate.Date - startDate.Date;
                //if (tsDays.TotalDays + 1 > par) 
                //    if (lang == 1)
                //        return " error - لا تستطيع ادخال اجازة لانتهاء فترة سماح ادخالها";
                //    else
                //        return " error - Expired Data Entry";


                TimeSpan tsDays = DateTime.Now.Date - startDate.Date;

                if (tsDays.TotalDays + 1 > par)
                    if (lang == 1)
                        return " error - لا تستطيع ادخال اجازة لانتهاء فترة سماح ادخالها";
                    else
                        return " error - Expired Data Entry";



                return GetEmpVacDays(CompNo, EmpNo, LVType, startDate, endDate).ToString();
            }
            else
            {

                // TimeSpan tsTimes = endTime - startTime;

                //if (tsTimes.TotalHours <= par)
                //{
                //    return tsTimes.TotalHours.ToString();
                //}
                //else
                //{
                //    if (lang == 1)
                //        return " error - لا تستطيع إدخال مغادرة اكثر من  " + par.ToString() + " ساعات";
                //    else
                //        return " error - You Can't Insert Leave More Than " + par.ToString() + " Hours ";
                //}

                double par = GetCompParValue(CompNo, 2); // 2 is Vacation Parameter

                TimeSpan tsDays = DateTime.Now.Date - startDate.Date;

                if (tsDays.TotalDays + 1 > par)
                    if (lang == 1)
                        return " error - لا تستطيع ادخال مغادرة لانتهاء فترة سماح ادخالها";
                    else
                        return " error - Expired Data Entry";


                if (LVType != 4)
                    par = GetCompParValue(CompNo, 1);// 1 is Leave Parameter
                else
                    par = GetCompParValue(CompNo, 13);// 13 is Leave Parameter

                TimeSpan tsTimes = endTime - startTime;



                if (tsTimes.TotalHours <= par)
                {
                    par = GetCompParValue(CompNo, 9);// 9 is Leave Parameter

                    tsTimes = endTime - startTime;
                    if (ClientNumber == "10235")
                    {
                        int PerMonth = GetCalcleavePerMonth(CompNo, EmpNo, LVType, startDate, tsTimes.TotalMinutes);
                        if (PerMonth == 1)
                        {
                            if (lang == 1)
                                return " error - لقد تجاوز الحد المطلوب للمغادرة خلال الشهر الحالي";
                            else
                                return " error - He has exceeded the threshold required to leave within the current month";
                        }
                    }
                   

                    if (tsTimes.TotalMinutes >= par)
                    {
                        return tsTimes.TotalHours.ToString();
                    }
                    else
                    {
                        if (lang == 1)
                            return " error - لا تستطيع إدخال مغادرة اقل من  " + par.ToString() + " دقائق";
                        else
                            return " error - You Can't Insert Leave less Than " + par.ToString() + " Minutes ";
                    }
                }
                else
                {
                    if (lang == 1)
                        return " error - لا تستطيع إدخال مغادرة اكثر من  " + par.ToString() + " ساعات";
                    else
                        return " error - You Can't Insert Leave More Than " + par.ToString() + " Hours ";
                }


            }
        }

        [NonAction]
        public string SaveNewLeave(short compNo, int empNo, int LeaveType, DateTime startDate, DateTime startTime, DateTime endTime, double period, string address, string substitute, string notes, DateTime now, bool sendEmail, string LevType, short gLang, int Type)
        {
            try
            {
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startTime.Hour, startTime.Minute, startTime.Second);
                DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, endTime.Hour, endTime.Minute, endTime.Second);

                int chkLeave = CheckVacation(compNo, empNo, startDate, endDate, 1);

                if (chkLeave != 0)
                    if (gLang == 1)
                        return " error - " + "يوجد مغادرة بنفس الموعد";
                    else
                        return " error - " + "there is leave in the same time";

                Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = compNo;
                Parameters.Add("@EmpNo", SqlDbType.Int).Value = empNo;
                Parameters.Add("@LType", SqlDbType.SmallInt).Value = LeaveType;
                Parameters.Add("@LClass", SqlDbType.SmallInt).Value = 1;
                Parameters.Add("@LStartD", SqlDbType.SmallDateTime).Value = startDate;
                Parameters.Add("@LEndD", SqlDbType.SmallDateTime).Value = endDate;
                Parameters.Add("@Lperiod", SqlDbType.Money).Value = period;
                Parameters.Add("@LAddress", SqlDbType.VarChar).Value = address;
                Parameters.Add("@RDate", SqlDbType.SmallDateTime).Value = now;
                Parameters.Add("@AltervativeEmp", SqlDbType.VarChar).Value = 0;
                Parameters.Add("@LNotes", SqlDbType.VarChar).Value = notes;
                Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                long ID = (long)excute("HRP_AddNewLeave", "@VR_Serial");
                var valApproval = GetCompParValue(compNo, 10); // 10 is qustion for approval system Or Not 
                if (valApproval == 1)
                    InsertHRP_WorkFlow(compNo, ID, 1, empNo);

                var val = GetCompParValue(compNo, 5); // 5 is qustion for Send Email Or Not 
                LogStatus("Is USing Email SendEmail " + val.ToString(), "SaveNewLeave");
                if (val == 1 && sendEmail)
                    SendEmailToSuperVisor(compNo, empNo, startDate, endDate, startTime, endTime, 1, address, notes, period, LevType, Type);

                if (gLang == 1)
                    return "تم ارسال الطلب بنجاح";
                else
                    return "request sent successfuly";
            }
            catch (Exception ex)
            { return " error - " + ex.Message; }

        }

        [NonAction]
        private IEnumerable<CboLeaveVac> GetLeaveTypeList(short CompNo, short lang = 1)
        {
            List<CboLeaveVac> result = new List<CboLeaveVac>();
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = lang;
            DataTable dt = (DataTable)excute("Pay_GetAllLeavesInfo", "", false, false, "", true);

            if (dt.Rows.Count == 0)
                return result;

            result = dt.AsEnumerable().Select(row => new CboLeaveVac
            {
                CompNo = Convert.ToInt16(iif(row["CompNo"] == DBNull.Value, 0, row["CompNo"])),
                Code = Convert.ToInt16(iif(row["Lve_Code"] == DBNull.Value, 0, row["Lve_Code"])),

                Desc = iif(row["Lve_Desc"] == DBNull.Value, "", row["Lve_Desc"]).ToString(),
                EngDesc = iif(row["Lve_EngDesc"] == DBNull.Value, "", row["Lve_EngDesc"]).ToString(),

                ForseHeader = Convert.ToBoolean(iif(row["ForceHeader"] == DBNull.Value, false, row["ForceHeader"])),
                IsWebService = Convert.ToBoolean(iif(row["Lve_WebService"] == DBNull.Value, false, row["Lve_WebService"]))
            }).Where(m => m.IsWebService == true).ToList();
            return result;
        }

        [NonAction]
        public IEnumerable<CboLeaveVac> GetVacationTypeList(short CompNo, short lang = 1)
        {
            List<CboLeaveVac> result = new List<CboLeaveVac>();

            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@glang", SqlDbType.SmallInt).Value = lang;
            DataTable dt = (DataTable)excute("Pay_GetAllVacsInfo", "", false, false, "", true);
            if (dt.Rows.Count == 0)
                return result;

            result = dt.AsEnumerable().Select(row => new CboLeaveVac
            {
                CompNo = Convert.ToInt16(iif(row["CompNo"] == DBNull.Value, 0, row["CompNo"])),
                Code = Convert.ToInt16(iif(row["Vac_Code"] == DBNull.Value, 0, row["Vac_Code"])),

                Desc = iif(row["Vac_Desc"] == DBNull.Value, "", row["Vac_Desc"]).ToString(),
                EngDesc = iif(row["Vac_EngDesc"] == DBNull.Value, "", row["Vac_EngDesc"]).ToString(),

                ForseHeader = Convert.ToBoolean(iif(row["ForceHeader"] == DBNull.Value, false, row["ForceHeader"])),
                IsWebService = Convert.ToBoolean(iif(row["Vac_WebService"] == DBNull.Value, false, row["Vac_WebService"]))

            }).Where(m => m.IsWebService == true).ToList();
            return result;
        }

        [NonAction]
        private string GetDueDate(short CompNo, int empNum, int year, int VacType, int Type)
        {
            string DueVaca = "0";
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNO", empNum);
            Parameters.AddWithValue("@BalYear", year);
            Parameters.AddWithValue("@VacType", VacType);
            Parameters.AddWithValue("@Type", Type);
            DueVaca = excute("HRP_Mobile_GetDutVacLeav", "", false, false, "DueBal").ToString();
            return DueVaca;
        }

        [NonAction]
        private int GetEmpVacDays(short CompNo, int EmpNo, int LVType, DateTime startDate, DateTime endDate)
        {
            int res;


            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@VacType", SqlDbType.SmallInt).Value = LVType;
            Parameters.Add("@FromDate", SqlDbType.SmallDateTime).Value = startDate;
            Parameters.Add("@ToDate", SqlDbType.SmallDateTime).Value = endDate;
            Parameters.Add("@EmpVacDays", SqlDbType.Int).Direction = ParameterDirection.Output;
            res = (int)excute("Pay_GetEmpVacDays", "@EmpVacDays");
            return res;
        }

        [NonAction]
        private string SaveNewVacation(short compNo, int empNo, int vacationType, DateTime startDate, DateTime endDate, double period, string address, string substitute, string notes, DateTime now, bool sendEmail, string LevType, short gLang, UploadFile uploadFile, int Type)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT Vac_Desc FROM Pay_Vac WHERE(CompNo = " + compNo + " ) and Vac_Code = " + vacationType;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    LevType = dr[0].ToString();
                }
            }
            conn.Dispose();

            try
            {
                int chkVac = CheckVacation(compNo, empNo, startDate, endDate, 0);

                if (chkVac != 0)
                    if (gLang == 1)
                        return " error - " + "يوجد اجازة بنفس التاريخ";
                    else
                        return " error - " + "there is vacation in the same date";

                Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = compNo;
                Parameters.Add("@EmpNo", SqlDbType.Int).Value = empNo;
                Parameters.Add("@LType", SqlDbType.SmallInt).Value = vacationType;
                Parameters.Add("@LClass", SqlDbType.SmallInt).Value = 0;
                Parameters.Add("@LStartD", SqlDbType.SmallDateTime).Value = startDate;
                Parameters.Add("@LEndD", SqlDbType.SmallDateTime).Value = endDate;
                Parameters.Add("@Lperiod", SqlDbType.Money).Value = period;
                Parameters.Add("@LAddress", SqlDbType.VarChar).Value = address;
                Parameters.Add("@RDate", SqlDbType.SmallDateTime).Value = now;
                Parameters.Add("@AltervativeEmp", SqlDbType.VarChar).Value = substitute;
                Parameters.Add("@LNotes", SqlDbType.VarChar).Value = notes;
                Parameters.Add("@VR_Serial", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                long ID = (long)excute("HRP_AddNewLeave", "@VR_Serial");

                if (uploadFile != null)
                {
                    Parameters.AddWithValue("@CompNo", compNo);
                    Parameters.AddWithValue("@EmpNo", empNo);
                    Parameters.AddWithValue("@VRSerial", ID);
                    Parameters.AddWithValue("@Start_Date", startDate);
                    Parameters.AddWithValue("@End_Date", endDate);
                    Parameters.AddWithValue("@TransDate", DateTime.Now);
                    Parameters.AddWithValue("@FileName", uploadFile.FileName);
                    Parameters.AddWithValue("@DateUploded", DateTime.Now);
                    Parameters.AddWithValue("@FileData", uploadFile.File);
                    Parameters.AddWithValue("@ContentType", uploadFile.ContentType);
                    Parameters.AddWithValue("@Filesize", uploadFile.FileSize);
                    excute("HRP_web_AddNewLeaveArchives");
                }
                var valApproval = GetCompParValue(compNo, 10); // 10 is qustion for approval system Or Not 

                if (valApproval == 1)
                    InsertHRP_WorkFlow(compNo, ID, 1, empNo);



                var val = GetCompParValue(compNo, 5); // 5 is qustion for Send Email Or Not 

                if (val == 1 && sendEmail)
                    SendEmailToSuperVisor(compNo, empNo, startDate, endDate, startDate, endDate, 0, address, notes, period, LevType, Type);

                if (gLang == 1)
                    return "تم ارسال الطلب بنجاح";
                else
                    return "request sent successfuly";

            }
            catch (Exception ex)
            { return " error - " + ex.Message; }
        }

        [NonAction]
        public void LogStatus(string Msg, string source)
        {

        }

        [NonAction]
        public string GetDepartment(short CompNo, int empNum)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@EmpNO", empNum);
            return excute("GetDepartment", "", false, false, "WPlaceDesc").ToString();
        }

        [NonAction]
        private void SendEmailToSuperVisor(short compNo, int empNo, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime, int Leave, string address, string notes, double period, string LevType, int Type)
        {
            try
            {
                LogStatus("Start seinding Email", "SendEmailToSuperVisor");
                string EmpName = "";
                string EmpEngName = "";
                string Supervisor_No = "";
                string Supervisor_Name = "";
                string Supervisor_EmpEngName = "";
                string Supervisor_Email = "";
                string WebsiteLink = "";
                string CompNo = "";
                string SmtpAddress = "";
                string SmtpPort = "";
                string EmailAddress = "";
                string Username = "";
                string Password = "";
                string IsUsingSSL = "";
                string IsHtmlBody = "";
                string vacationsbalance = GetDueDate(compNo, empNo, DateTime.Now.Year, Leave, Type);
                string Section = GetDepartment(compNo, empNo);


                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable Dr = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_EmailGetInfo");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = compNo;
                cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = empNo;
                cmd.CommandTimeout = 90;
                Da.SelectCommand = cmd;
                Da.Fill(Dr);

                if (Dr.Rows.Count == 0)
                {
                    LogStatus("Seinding Email Faild there is no supervisor for this employee number" + empNo.ToString(), "SendEmailToSuperVisor");
                    return;
                }
                else
                {
                    for (int i = 0; i < Dr.Rows.Count; i++)
                    {
                        var dr = Dr.Rows[i];
                        CompNo = dr["CompNo"].ToString();
                        EmpName = dr["EmpName"].ToString();
                        EmpEngName = dr["EmpEngName"].ToString();
                        Supervisor_No = dr["Supervisor_No"].ToString();
                        Supervisor_Name = dr["Supervisor_Name"].ToString();
                        Supervisor_EmpEngName = dr["Supervisor_EmpEngName"].ToString();
                        Supervisor_Email = dr["Supervisor_Email"].ToString();
                        WebsiteLink = dr["WebsiteLink"].ToString();
                        SmtpAddress = dr["SmtpAddress"].ToString();
                        SmtpPort = dr["SmtpPort"].ToString();
                        EmailAddress = dr["EmailAddress"].ToString();
                        Username = dr["Username"].ToString();
                        Password = dr["Password"].ToString();
                        IsUsingSSL = dr["IsUsingSSL"].ToString();
                        IsHtmlBody = dr["IsHtmlBody"].ToString();
                        if (Supervisor_Email != null && Supervisor_Email != "")
                        {
                            try
                            {
                                var fromAddress = new MailAddress(EmailAddress, "HRP Alpha System");
                                var toAddress = new MailAddress(Supervisor_Email, "To " + Supervisor_Name);
                                string abc = fromAddress.Address;
                                string xyz = Password;
                                string gg = EmailAddress;
                                Console.Out.WriteLine(fromAddress.Address);
                                Console.Out.WriteLine(EmailAddress);
                                Console.Out.WriteLine(gg);
                                var smtp = new SmtpClient
                                {
                                    Host = SmtpAddress,
                                    Port = Convert.ToInt32(SmtpPort),
                                    EnableSsl = Convert.ToBoolean(IsUsingSSL),
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(fromAddress.Address, Password)
                                };
                                if (Leave == 1)
                                {
                                    var body = new StringBuilder();
                                    body.AppendLine(@"<div dir=""rtl"">");
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "طلب مغادرة من قبل الموظف", EmpName.ToString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "القسم", Section.ToString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "يرجى الموفقة على منحي مغادرة لمدة", period.ToString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "التاريخ", startDate.ToShortDateString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "من الساعة", startTime.ToShortTimeString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "ولغاية الساعة", endTime.ToShortTimeString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "نوع المغادرة", LevType.ToString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "سبب المغادرة", notes.ToString()));
                                    body.AppendLine(string.Format("<p> للموافقة او الرفض من خلال التطبيق  </p>", WebsiteLink));
                                    body.AppendLine("</div>");

                                    using (var message = new MailMessage(fromAddress, toAddress)
                                    {
                                        IsBodyHtml = true,
                                        Subject = "Alpha ESS - Employee Self Service",
                                        Body = body.ToString()
                                    })
                                    {
                                        LogStatus("Seinding Email...", "SendEmailToSuperVisor");
                                        smtp.Send(message);
                                        LogStatus("Seinding Email done successfuly", "SendEmailToSuperVisor");
                                    };
                                }
                                else
                                {
                                    var body1 = new StringBuilder();
                                    body1.AppendLine(@"<div dir=""rtl"">");
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "طلب إجازة من قبل الموظف", EmpName.ToString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "يرجى الموفقة على منحي إجازة لمدة", period.ToString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "ابتداء من صباح يوم", startDate.ToShortDateString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "ولغاية مساء يوم", endDate.ToShortDateString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "نوع الإجازة", LevType.ToString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "سبب الإجازة", notes.ToString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "رصيد الاجازات ", vacationsbalance.ToString()));
                                    body1.AppendLine(string.Format("<p> للموافقة او الرفض من خلال التطبيق  </p>", WebsiteLink));
                                    body1.AppendLine("</div>");
                                    using (var message = new MailMessage(fromAddress, toAddress)
                                    {
                                        IsBodyHtml = true,
                                        Subject = "Alpha ESS - Employee Self Service",
                                        Body = body1.ToString()

                                    })
                                    {
                                        LogStatus("Seinding Email...", "SendEmailToSuperVisor");
                                        smtp.Send(message);
                                        LogStatus("Seinding Email done successfuly", "SendEmailToSuperVisor");
                                    };
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        }
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            catch
            {
            }
        }

        [NonAction]
        private void SendEmailToSuperVisorReject(short compNo,long id)
        {
            try
            {
                LogStatus("Start seinding Email", "SendEmailToSuperVisorReject");
                string EmpName = "";
                string EmpEngName = "";
                string Supervisor_No = "";
                string Supervisor_Name = "";
                string Supervisor_EmpEngName = "";
                string Supervisor_Email = "";
                string WebsiteLink = "";
                string CompNo = "";
                string SmtpAddress = "";
                string SmtpPort = "";
                string EmailAddress = "";
                string Username = "";
                string Password = "";
                string IsUsingSSL = "";
                string IsHtmlBody = "";
                DataTable DataRejectRequestVaction = GetLeveRequest(compNo, id);
                var EmpNo = DataRejectRequestVaction.Rows[0]["EmpNo"].ToString();
                DateTime Start_Date = Convert.ToDateTime(DataRejectRequestVaction.Rows[0]["Start_Date"]);
                DateTime End_Date = Convert.ToDateTime(DataRejectRequestVaction.Rows[0]["End_Date"]);
                var LevType = DataRejectRequestVaction.Rows[0]["LevType"].ToString();
                var DaysHrs = DataRejectRequestVaction.Rows[0]["DaysHrs"].ToString();
                var Duration = DataRejectRequestVaction.Rows[0]["Duration"].ToString();
                var EmpDesc = DataRejectRequestVaction.Rows[0]["EmpDesc"].ToString();


                SqlConnection conn = new SqlConnection(connectionstring);
                DataTable Dr = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("HRP_Web_EmailGetInfo");
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = compNo;
                cmd.Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
                cmd.CommandTimeout = 90;
                Da.SelectCommand = cmd;
                Da.Fill(Dr);

                if (Dr.Rows.Count == 0)
                {
                    LogStatus("Seinding Email Faild there is no supervisor for this employee number" + EmpNo.ToString(), "SendEmailToSuperVisor");
                    return;
                }
                else
                {
                    for (int i = 0; i < Dr.Rows.Count; i++)
                    {
                        var dr = Dr.Rows[i];
                        CompNo = dr["CompNo"].ToString();
                        EmpName = dr["EmpName"].ToString();
                        EmpEngName = dr["EmpEngName"].ToString();
                        Supervisor_No = dr["Supervisor_No"].ToString();
                        Supervisor_Name = dr["Supervisor_Name"].ToString();
                        Supervisor_EmpEngName = dr["Supervisor_EmpEngName"].ToString();
                        Supervisor_Email = dr["Supervisor_Email"].ToString();
                        WebsiteLink = dr["WebsiteLink"].ToString();
                        SmtpAddress = dr["SmtpAddress"].ToString();
                        SmtpPort = dr["SmtpPort"].ToString();
                        EmailAddress = dr["EmailAddress"].ToString();
                        Username = dr["Username"].ToString();
                        Password = dr["Password"].ToString();
                        IsUsingSSL = dr["IsUsingSSL"].ToString();
                        IsHtmlBody = dr["IsHtmlBody"].ToString();
                        if (Supervisor_Email != null && Supervisor_Email != "")
                        {
                            try
                            {
                                var fromAddress = new MailAddress(EmailAddress, "HRP Alpha System");
                                var toAddress = new MailAddress(Supervisor_Email, "To " + Supervisor_Name);

                                var smtp = new SmtpClient
                                {
                                    Host = SmtpAddress,
                                    Port = Convert.ToInt32(SmtpPort),
                                    EnableSsl = Convert.ToBoolean(IsUsingSSL),
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(fromAddress.Address, Password)
                                };
                                if (DaysHrs == "1")
                                {
                                    var body = new StringBuilder();
                                    body.AppendLine(@"<div dir=""rtl"">");
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "تم رفض طلب مغادرة للموظف", EmpDesc.ToString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "التاريخ", Start_Date.ToShortDateString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "من الساعة", End_Date.ToShortTimeString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "ولغاية الساعة", End_Date.ToShortTimeString()));
                                    body.AppendLine(string.Format("<p>{0} : {1} </p>", "نوع المغادرة", LevType.ToString()));
                                    body.AppendLine("</div>");

                                    using (var message = new MailMessage(fromAddress, toAddress)
                                    {
                                        IsBodyHtml = true,
                                        Subject = "Alpha ESS - Employee Self Service",
                                        Body = body.ToString()
                                    })
                                    {
                                        LogStatus("Seinding Email...", "SendEmailToSuperVisor");
                                        smtp.Send(message);
                                        LogStatus("Seinding Email done successfuly", "SendEmailToSuperVisor");
                                    };
                                }
                                else
                                {
                                    var body1 = new StringBuilder();
                                    body1.AppendLine(@"<div dir=""rtl"">");
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "تم رفض طلب إجازة للموظف", EmpDesc.ToString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "ابتداء من صباح يوم", Start_Date.ToShortDateString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "ولغاية مساء يوم", End_Date.ToShortDateString()));
                                    body1.AppendLine(string.Format("<p>{0} : {1} </p>", "نوع الإجازة", LevType.ToString()));
                                    body1.AppendLine("</div>");
                                    
                                    using (var message = new MailMessage(fromAddress, toAddress)
                                    {
                                        IsBodyHtml = true,
                                        Subject = "Alpha ESS - Employee Self Service",
                                        Body = body1.ToString()

                                    })
                                    {
                                        LogStatus("Seinding Email...", "SendEmailToSuperVisor");
                                        smtp.Send(message);
                                        LogStatus("Seinding Email done successfuly", "SendEmailToSuperVisor");
                                    };
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        }
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            catch
            {
            }
        }
        [NonAction]
        public DataTable GetLeveRequest(short CompNo, long Id)
        {

            Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.AddWithValue("@Id", SqlDbType.BigInt).Value = Id;
            Parameters.AddWithValue("@lang", SqlDbType.BigInt).Value = 1;
            DataTable dt = (DataTable)excute("HRP_Web_GetEmpRejectRequestVaction", "", false, false, "", true);
            return dt;
        }
        [NonAction]
        private int CheckVacation(short CompNo, int EmpNo, DateTime startDate, DateTime endDate, int LClass)
        {
            int res = 0;
            Parameters.Add("@CompNo", SqlDbType.SmallInt).Value = CompNo;
            Parameters.Add("@EmpNo", SqlDbType.Int).Value = EmpNo;
            Parameters.Add("@VRSerial", SqlDbType.Int).Value = -1;
            Parameters.Add("@LStartD", SqlDbType.SmallDateTime).Value = startDate;
            Parameters.Add("@LEndD", SqlDbType.SmallDateTime).Value = endDate;
            Parameters.Add("@LClass", SqlDbType.SmallInt).Value = LClass;
            Parameters.Add("@RCount", SqlDbType.SmallInt).Direction = ParameterDirection.Output;
            bool HasRows = (bool)excute("HRP_CheckLev_New", "", false, true);
            if (HasRows)
                res = 1;
            else
                res = 0;

            return res;
        }

        [NonAction]
        public string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException("extension");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }
            string mime;
            return new Mappings().mappings.TryGetValue(extension, out mime) ? mime : "application/octet-stream";
        }
        #endregion

        #region Archive

        private string sName
        {
            get
            {
                return Configuration["server"];
            }
        }

        private string AlphaHRFireBase
        {
            get
            {

                return Configuration["AlphaHRFireBase"];
            }
        }

        private string ClientNumber
        {
            get
            {
                return Configuration["ClientNumber"];
            }
        }

        private string dbName
        {
            get
            {
                return Configuration["database"];
            }
        }

        private string ArchivePath
        {
            get
            {
                return Configuration["ArchivePath"];
            }
        }

        [AllowAnonymous]
        [Route("GetAPI")]
        public IActionResult GetAPI()
        {
            string startPath = Directory.GetCurrentDirectory();
            string zipPath = string.Format(@".\api {0}.zip", DateTime.Now.ToString("yyyy.MM.dd"));
            if (System.IO.File.Exists(zipPath))
            {
                System.IO.File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(startPath, zipPath);
            var stream = System.IO.File.OpenRead(zipPath);
            return File(stream, "application/zip");
        }

        [HttpPost("GetFiles")]
        public DataTable GetFiles([FromBody] ArchiveB b)
        {
            string path = getPath(b);

            DataTable dt = new DataTable();
            if (path == "") return dt;
            dt.Columns.Add("File");
            dt.Columns.Add("Download");
            if (Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path);
                foreach (string fileName in fileEntries)
                    dt.Rows.Add(Path.GetFileName(fileName), Path.GetFileName(fileName));

                string doc = Path.Combine(path, "doc");
                if (Directory.Exists(doc))
                {
                    foreach (string docF in Directory.GetFiles(doc).Where(x => Path.GetExtension(x).ToLower() == ".pdf"))
                        dt.Rows.Add("doc/" + Path.GetFileName(docF), "doc/" + Path.GetFileName(docF).Replace(".pdf", ".doc"));
                }

                string docx = Path.Combine(path, "docx");
                if (Directory.Exists(docx))
                {
                    foreach (string docF in Directory.GetFiles(docx).Where(x => Path.GetExtension(x).ToLower() == ".pdf"))
                        dt.Rows.Add("docx/" + Path.GetFileName(docF), "docx/" + Path.GetFileName(docF).Replace(".pdf", ".docx"));
                }

                string xls = Path.Combine(path, "xls");
                if (Directory.Exists(xls))
                {
                    foreach (string docF in Directory.GetFiles(xls).Where(x => Path.GetExtension(x).ToLower() == ".pdf"))
                        dt.Rows.Add("xls/" + Path.GetFileName(docF), "xls/" + Path.GetFileName(docF).Replace(".pdf", ".xls"));
                }

                string xlsx = Path.Combine(path, "xlsx");
                if (Directory.Exists(xlsx))
                {
                    foreach (string docF in Directory.GetFiles(xlsx).Where(x => Path.GetExtension(x).ToLower() == ".pdf"))
                        dt.Rows.Add("xlsx/" + Path.GetFileName(docF), "xlsx/" + Path.GetFileName(docF).Replace(".pdf", ".xlsx"));
                }

            }
            return dt;
        }

        [AllowAnonymous]
        [Route("GetFile/{k1}/{k2}/{k3}/{k4}/{k5}/{FileName}")]
        public IActionResult GetFilex(string k1, string k2, string k3, string k4, string k5, string FileName)
        {
            string file = string.Format("{0}{1}\\{2}\\{3}\\{4}\\{5}\\{6}", ArchivePath, k1, k2, k3, k4, k5, FileName);
            if (!System.IO.File.Exists(file))
            {
                return NotFound();
            }

            var stream = new FileStream(file, FileMode.Open);

            if (Path.GetExtension(FileName).ToLower() == ".txt")
            {
                StreamWriter output = new StreamWriter(stream, Encoding.UTF8, 2 << 22);
                output.Flush();
                stream.Seek(0, SeekOrigin.Begin);
            }

            var fileResult = new FileStreamResult(stream, contentType(FileName));
            return fileResult;
        }

        [AllowAnonymous]
        [Route("GetFileSX/{k1}/{k2}/{k3}/{k4}/{k5}/{k6}/{FileName}")]
        public IActionResult GetFileSX(string k1, string k2, string k3, string k4, string k5, string k6, string FileName)
        {
            string file = string.Format("{0}{1}\\{2}\\{3}\\{4}\\{5}\\{6}\\{7}", ArchivePath, k1, k2, k3, k4, k5, k6, FileName);
            if (!System.IO.File.Exists(file))
            {
                return NotFound();
            }

            var stream = new FileStream(file, FileMode.Open);

            if (Path.GetExtension(FileName).ToLower() == ".txt")
            {
                StreamWriter output = new StreamWriter(stream, Encoding.UTF8, 2 << 22);
                output.Flush();
                stream.Seek(0, SeekOrigin.Begin);
            }

            var fileResult = new FileStreamResult(stream, contentType(FileName));
            return fileResult;
        }

        string contentType(string FileName)
        {
            string contentType;
            new FileExtensionContentTypeProvider().TryGetContentType(FileName, out contentType);
            return contentType ?? "application/octet-stream";
        }

        [HttpPost("ArchiveFile")]
        public void ArchiveFile([FromBody] ArchiveB b)
        {
            b.fileName = b.fileName.Replace("+", " ");

            if (!Directory.Exists(getPath(b))) Directory.CreateDirectory(getPath(b));
            if (b.Obase64 == "")
            {
                string p = getPath(b);
                byte[] bytes = Convert.FromBase64String(b.base64);
                if (System.IO.File.Exists(Path.Combine(p, b.fileName)))
                    System.IO.File.Delete(Path.Combine(p, b.fileName));

                System.IO.File.WriteAllBytes(Path.Combine(p, b.fileName), bytes);
            }
            else
            {
                string p = Path.Combine(getPath(b), b.ext.Replace(".", ""));
                if (!Directory.Exists(p)) Directory.CreateDirectory(p);
                // write the file
                if (System.IO.File.Exists(Path.Combine(p, b.fileName)))
                    System.IO.File.Delete(Path.Combine(p, b.fileName));
                System.IO.File.WriteAllBytes(Path.Combine(p, b.fileName), Convert.FromBase64String(b.base64));
                // write the orginal file
                string Oname = Path.GetFileNameWithoutExtension(b.fileName) + b.ext.ToLower();
                if (System.IO.File.Exists(Path.Combine(p, Oname)))
                    System.IO.File.Delete(Path.Combine(p, Oname));
                System.IO.File.WriteAllBytes(Path.Combine(p, Oname), Convert.FromBase64String(b.Obase64));

            }


        }

        [HttpPost("RemoveFile")]
        public void RemoveFile([FromBody] ArchiveB b)
        {
            string f = getPath(b) + "\\" + b.fileName;

            if (System.IO.File.Exists(f))
                System.IO.File.Delete(f);

            string pdf = Path.ChangeExtension(f, "pdf");
            if (System.IO.File.Exists(pdf))
                System.IO.File.Delete(pdf);
        }

        [HttpPost("RemoveAllFiles")]
        public void RemoveAllFiles([FromBody] ArchiveB b)
        {
            DirectoryInfo di = new DirectoryInfo(getPath(b));

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public class ArchiveB
        {
            public string k1 { get; set; }
            public string k2 { get; set; }
            public string k3 { get; set; }
            public string k4 { get; set; }
            public string k5 { get; set; }
            public string ext { get; set; }
            public string base64 { get; set; }
            public string Obase64 { get; set; }
            public string fileName { get; set; }
        }

        //[Route("api/{sp}")]
        [HttpPost("sp/{spn}")]
        [AllowAnonymous]
        public object sp(string spn)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(spn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            int limit = -1;
            foreach (string key in Request.Form.Keys)
            {
                if (key.ToString().ToLower() == "_limit")
                    limit = int.Parse($"{Request.Form[key]}");
                else
                    cmd.Parameters.AddWithValue($"@{key}", $"{Request.Form[key]}");
            }


            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            try
            {
                Da.Fill(dt);
                if (limit != -1)
                {
                    dt = dt.AsEnumerable().Take(limit).CopyToDataTable();
                }
                return Ok(new { error = false, total = dt.Rows.Count, data = dt });
            }
            catch (Exception p)
            {
                return Ok(new { error = false, total = dt.Rows.Count, data = p.Message });
            }

        }

        string getPath(ArchiveB b)
        {
            if (b == null) return "";
            return string.Format("{0}{1}\\{2}\\{3}\\{4}\\{5}", ArchivePath, b.k1, b.k2, b.k3, b.k4, b.k5);
        }

        private SqlParameterCollection Parameters = new SqlCommand().Parameters;

        [NonAction]
        private object excute(string ProcedureName, string outPut = "", bool row = false, bool HasRows = false, string value0 = "", bool dataTable = false, bool dataSet = false)
        {

            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(ProcedureName);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = Parameters.Count - 1; i >= 0; i--)
            {
                var p = Parameters[i];
                Parameters.Remove(p);
                cmd.Parameters.Add(p);
            }
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            if (dataSet == true)
            {
                DataSet sDs = new DataSet();
                Da.Fill(sDs);
                return sDs;
            }
            Da.Fill(dt);
            Parameters = new SqlCommand().Parameters;

            if (dataTable == true)
            {
                return dt;
            }
            if (value0 != "")
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][value0];
                }
                return "0";
            }
            if (row == true)
            {
                return dt.Rows[0];
            }
            if (HasRows == true)
            {
                if (dt.Rows.Count == 0) { return false; } else { return true; }
            }
            if (outPut != "") { return cmd.Parameters[outPut].Value; } else { return 0; }
        }
        #endregion
    }
}
