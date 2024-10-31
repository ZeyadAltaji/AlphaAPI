using AlphaAPI.BasicAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AlphaAPI.Models;
using System;
using System.Threading.Tasks;
using RestSharp;
using System.Runtime.ConstrainedExecution;

namespace AlphaAPI.Controllers
{
    [ActivatorUtilitiesConstructor]
    [ApiController]
    [BasicAuth]
    public class AlphaProdController : ControllerBase
    {
        private readonly IHubContext<HRHub> hb;
        private IMemoryCache cache;
        private readonly IHubContext<HRHub> _hubContext;
        string cs = "";
        private SqlParameterCollection Parameters = new SqlCommand().Parameters;
        public AlphaProdController(IHubContext<HRHub> hubContext, IMemoryCache memoryCache)
        {
            cache = memoryCache;
            _hubContext = hubContext;
            cs = string.Format("Server={0};Database={1};User ID=Admin;Password=GceSoft01042000", sName, dbName);
        }
        [HttpPost("LoginProd")]
        [AllowAnonymous]
        public ActionResult LoginProd(string UserName, string Password)
        {
            LoginModel a = new LoginModel()
            {
                Username = UserName.Trim(),
                Password = Password.Trim(),
            };

            Employee result = LoginEMP(a);
            if (result.IsLogin)
            {
                DataTable notis = new DataTable();
                DataTable functions = new DataTable();
                Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = result.EmpNum;
                functions = (DataTable)excute("ALPHA_ProdCost_LoadTasksStage", "", false, false, "", true);

                Parameters.AddWithValue("@CompNo", SqlDbType.SmallInt).Value = result.CompNo;
                Parameters.AddWithValue("@UserID", SqlDbType.Int).Value = result.EmpNum;
                notis = (DataTable)excute("ALPHA_ProdCost_LoadOrderTaskDetailsText", "", false, false, "", true);

                return Ok(new { result, functions, notis });
            }
            else
            {
                Employee error = new Employee();
                error.ErrorMessage = result.ErrorMessage;
                return Ok(new { result = error });
            }
        }
        [HttpPost("GetLoadTasks")]
        public object GetLoadTasks(short CompNo,  string UserID)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@UserID", UserID);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadTasks", "", false, false, "", true);
            return Ok(new { result, error = false });
        }
        [HttpPost("GetMonitorDitals")]
        public object GetMonitorDitals(short CompNo, int OrderYear)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadTasksMonitor", "", false, false, "", true);
            return Ok(new { result, error = false });
        }
        [HttpPost("GetMonitorDitalsText")]
        public object GetMonitorDitalsText(short CompNo, int OrderYear, int OrderNo,int OrderCode)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderNo);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadMonitorDetailsText", "", false, false, "", true);

            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderCode);
            DataTable resultMonitorTasks = (DataTable)excute("ALPHA_ProdCost_LoadDetOrderMonitorTasks", "", false, false, "", true);

            return Ok(new { result, resultMonitorTasks, error = false });
        }
        [HttpPost("GetMonitorSubDitalsText")]
        public ActionResult GetMonitorSubDitalsText(short CompNo, int OrderYear, int OrderNo, int stageCode)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderNo);
            Parameters.AddWithValue("@stageCode", stageCode);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadMonitorSubDetailsText", "", false, false, "", true);
            return Ok(new { result, error = false });
        }
        [HttpPost("StageActivityForm")]
        public ActionResult StageActivityForm(short CompNo, int OrderYear, int OrderNo, int stageCode)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderNo);
            Parameters.AddWithValue("@stageCode", stageCode);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadStageActivityForm", "", false, false, "", true);
            return Ok(new { result });
        }
        [HttpPost("GetDetOrderTasks")]
        public object GetDetOrderTasks(short CompNo, int OrderYear, int OrderNo,string UserID)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderNo);
            Parameters.AddWithValue("@UserID", UserID);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadDetOrderTasks", "", false, false, "", true);
            return Ok(new { result, error = false });
        }
        [HttpPost("GetOrderTasksText")]
        public ActionResult GetOrderTasksText(short CompNo, int OrderYear, int OrderNo, int stageCode, string UserID, int gLang)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@OrderYear", OrderYear);
            Parameters.AddWithValue("@OrderNo", OrderNo);
            Parameters.AddWithValue("@stageCode", stageCode);
            Parameters.AddWithValue("@UserID", UserID);
            Parameters.AddWithValue("@gLang", gLang);
            DataTable result = (DataTable)excute("ALPHA_ProdCost_LoadOrderTaskDetailsText", "", false, false, "", true);
            return Ok(new { result, error = false });
        }

        [Route("notifyTasks"), HttpPost("notifyTasks")]
        [AllowAnonymous]
        public void notifyTasks([FromBody] NotificationTasksBulk c)
        {
            if (c == null)
                return;


            Task.Factory.StartNew(() => NotifyTaskJob(c));
        }
        private void NotifyTaskJob(NotificationTasksBulk c)
        {
            Task.Factory.StartNew(() => SendGoogleTasks("nTask", c.OrderYear, c.CompNo, c.OrderNo, c.StageCode, c.UserID,c.StageStatus,c.fDescAr));
            Task.Factory.StartNew(() => SendSignalRTasks("newAlert", c.OrderYear, c.CompNo, c.OrderNo, c.StageCode, c.UserID, c.StageStatus));
        }
        [Route("SendGoogleTasks"), HttpGet("SendGoogleTasks"), HttpPut("SendGoogleTasks")]
        public object SendGoogleTasks(string CRR, int OrderYear, short CompNo, int OrderNo, int StageCode, string UserID, int StageStatus, string fDescAr)
        {

            var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "key=AAAAutseYrM:APA91bEoVdqZryae-ICNYjmZu4iUzexi54tFTKd3m5NLDMg_Wfz-j6cridoCapS_Wn19Xn2VUJVUIrhnbPqCsKblNwzagV-ZNpIzd71_NMdPd3_U3ItjZIzsnZhOrN_HeXrNPw8QQIOW");
            request.AddHeader("Content-Type", "application/json");
            string body = @"{""to"": ""/topics/Prod-CRR-ClientNumber-CompNox-UsersTarget"",""notification"": {""title"": ""نظام الانتاج"",""body"":  ""fDescArx"",""sound"": ""alert.caf""},""data"":{""Type"":""CRR"",""OrderYear"": ""OrderYearx"",""OrderNo"": ""OrderNox"",""StageCode"": ""StageCodex"",""fDescAr"": ""fDescArx"",""UserID"": ""UserIDx""},""time_to_live"": 600}";
            body = body.Replace("ClientNumber", ClientNumber);
            body = body.Replace("UserIDx", UserID.ToString());
            body = body.Replace("fDescArx", fDescAr.ToString());
            body = body.Replace("OrderYearX", OrderYear.ToString());
            body = body.Replace("OrderNox", OrderNo.ToString());
            body = body.Replace("StageCodex", StageCode.ToString());
            body = body.Replace("CRR", CRR.ToLower());
            body = body.Replace("CompNox", CompNo.ToString());
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;

        }
        private void SendSignalRTasks(string CRR, int OrderYear, short CompNo, int OrderNo, int StageCode, string UserID, int StageStatus)
        {
            hb.Clients.All.SendCoreAsync(
                   CRR,
                   new object[] {
                        OrderYear,
                        OrderNo,
                        StageCode,
                        CompNo,
                        UserID,
                        StageStatus
             });
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
        private object excute(string ProcedureName, string outPut = "", bool row = false, bool HasRows = false, string value0 = "", bool dataTable = false, bool dataSet = false)
        {
            SqlConnection conn = new SqlConnection(cs);
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
                return dt.Rows[0][value0];
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

        private string sName
        {
            get
            {
                return Configuration["server"];
            }
        }

        private string dbName
        {
            get
            {
                return Configuration["database"];
            }
        }
        private int COMMAND_TIMEOUT = 90;
        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database={1};User ID=Admin;Password=GceSoft01042000", sName, dbName);
            }
        }

        private string ClientNumber
        {
            get
            {
                return Configuration["ClientNumber"];
            }
        }
    }
}
