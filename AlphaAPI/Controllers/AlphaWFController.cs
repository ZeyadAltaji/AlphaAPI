using AlphaAPI.BasicAuth;
using AlphaAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AlphaAPI.Controllers
{
    [ActivatorUtilitiesConstructor]
    [ApiController]
    [BasicAuth]
    public class AlphaWFController : ControllerBase
    {

        private IMemoryCache cache;
        private readonly IHubContext<HRHub> _hubContext;
        string cs = "";
        private SqlParameterCollection Parameters = new SqlCommand().Parameters;
        public AlphaWFController(IHubContext<HRHub> hubContext, IMemoryCache memoryCache)
        {
            cache = memoryCache;
            _hubContext = hubContext;
            //cs = string.Format("Server={0};Database={1};User ID=Admin;Password=@LphaGce$0ft#5", sName, dbName);
            cs = string.Format("Server={0};Database={1};User ID=Admin;Password=GceSoft01042000", sName, dbName);
        }

        [HttpPost("LoginWF")]
        [AllowAnonymous]
        public ActionResult LoginWF(string UserName, string Password, short gLang)
        {
            DataTable functions = new DataTable();
            DataTable notis = new DataTable();
            DataTable result = new DataTable();
            Parameters.AddWithValue("@UserID", UserName);
            Parameters.AddWithValue("@UserPWD", Password);
            result = (DataTable)excute("Alpha_MWF_Login", "", false, false, "", true);
            if (result.Rows.Count > 0)
            {
                functions = (DataTable)excute("Alpha_MWF_Functions", "", false, false, "", true);
                Parameters.AddWithValue("@UserID", UserName);
                Parameters.AddWithValue("@gLang", gLang);
                notis = (DataTable)excute("Alpha_MWF_LoadWorkFlowLog", "", false, false, "", true);
            }
            return Ok(new { result, functions, notis });
        }

        [HttpPost("WorkFlowLog")]
        public ActionResult WorkFlowLog(string UserID, short CompNo, short gLang = 1)
        {
            Parameters.AddWithValue("@UserD", UserID);
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@gLang", gLang);
            DataTable result = (DataTable)excute("Alpha_LoadWorkFlowLog", "", false, false, "", true);
            return Ok(new { result });
        }

        [HttpPost("WFOrderText")]
        public ActionResult WFOrderText(short CompNo, string K1, string K2, string K3, string K4, short gLang, short FID, string rAction)
        {
            if (rAction == null) rAction = "CR";
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@K1", K1);
            Parameters.AddWithValue("@K2", K2);
            Parameters.AddWithValue("@K3", K3);
            Parameters.AddWithValue("@K4", K4);
            Parameters.AddWithValue("@gLang", gLang);
            Parameters.AddWithValue("@FID", FID);
            DataTable result = new DataTable();
            result = (DataTable)excute("ALPHA_MWF_ViewData", "", false, false, "", true);
            return Ok(new { result });
        }
        [HttpPost("AttachmentsForm")]
        public object AttachmentsForm(short CompNo, string K1, string K2, string K3, string K4, short FID)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@K1", K1);
            Parameters.AddWithValue("@K2", K2);
            Parameters.AddWithValue("@K3", K3);
            Parameters.AddWithValue("@K4", K4);
            Parameters.AddWithValue("@FID", FID);
            DataTable result = new DataTable();
            result = (DataTable)excute("ALPHA_MWF_AttachmentsData", "", false, false, "", true);
            return Ok(new { result });
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

        [HttpPost("ManageWorkFlowLog")]
        public object ManageWorkFlowLog(long TId, string UserAction, string Notes)
        {
            SqlTransaction transaction;
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = new SqlConnection(cs);
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "Alpha_ManageWorkFlowLog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@TrID", SqlDbType.Decimal)).Value = TId;
            cmd.Parameters.Add(new SqlParameter("@UserAction", SqlDbType.VarChar, 1)).Value = UserAction;
            cmd.Parameters.Add(new SqlParameter("@UserNotes", SqlDbType.VarChar, 300)).Value = Notes;
            cmd.Parameters.Add(new SqlParameter("@FinalApprove", SqlDbType.Bit)).Direction = ParameterDirection.Output;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            cmd.ExecuteScalar();
            // int ErrNo = Convert.ToInt32(cmd.Parameters["@FinalApprove"].Value);
            // if (ErrNo == 0)
            // {
            transaction.Commit();
            cn.Dispose();
            // }
            //  else
            // {
            //      transaction.Rollback();
            //      cn.Dispose();
            //  }
            return Ok(new { ErrNo = 0 });
        }

        [HttpPost("GoodsForm")]
        public ActionResult GoodsForm(short CompNo, string K1, string K2, string K3, string K4, short FID)
        {
            Parameters.AddWithValue("@CompNo", CompNo);
            Parameters.AddWithValue("@K1", K1);
            Parameters.AddWithValue("@K2", K2);
            Parameters.AddWithValue("@K3", K3);
            Parameters.AddWithValue("@K4", K4);
            Parameters.AddWithValue("@FID", FID);
            DataTable result = (DataTable)excute("Alpha_MWF_GoodsForm", "", false, false, "", true);
            return Ok(new { result });
        }

        [HttpPost("QtyInquiry")]
        public ActionResult QtyInquiry(short CompNo, string ItemNo)
        {
            SqlConnection conn = new SqlConnection(cs);
            DataTable Dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(@$"SELECT sum(QtyOH) as qty FROM     InvBatchsMF where CompNo = @CompNo AND ItemNo = @ItemNo");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CompNo", CompNo);
            cmd.Parameters.AddWithValue("@ItemNo", ItemNo);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(Dt);
            DataTable result = Dt;
            return Ok(new { result });
        }
        [Route("WFGeneral")]
        public object WFGeneral(Dictionary<string, string> Parameter)
        {
            if (!Parameter.ContainsKey("pn")) return Ok(new { result = "pn error!!", error = true });
            string Procedure = Parameter.Where(x => x.Key == "pn").FirstOrDefault().Value;
            foreach (var p in Parameter.Where(x => x.Key != "pn"))
            {
                Parameters.AddWithValue("@" + p.Key, p.Value);
            }
            DataTable result = (DataTable)excute(Procedure, "", false, false, "", true);
            return Ok(new { result, error = false });
        }

        [HttpPost("wfcr")]
        public void wfcr([FromBody] wfCL c)
        {
            if (c == null) return;
            Task.Factory.StartNew(() => DOwfcr(c));
        }
        private void DOwfcr([FromBody] wfCL c)
        {
            if (c == null) return;
            var client = new RestClient("https://fcm.googleapis.com/fcm/send");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", AlphaWFFireBase);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{" + "\n" +
                  @"    ""to"": ""/topics/wf-ClientNumber-BUUserX"",                " + "\n"
                + @"    ""notification"": {                " + "\n"
                + @"        ""title"": ""نظام الموافقات"",                " + "\n"
                + @"        ""body"": ""functionDescX""" + "\n"
                + @"        ""sound"": ""alert.caf""" + "\n"
                + @"    },                " + "\n"
                + @"    ""data"": {                " + "\n"
                + @"		""TID"": ""TIDX"",                " + "\n"
                + @"		""CompNo"": ""CompNoX"",                " + "\n"
                + @"		""FID"": ""FIDX"",                " + "\n"
                + @"		""K1"": ""K1X"",                " + "\n"
                + @"		""K2"": ""K2X"",                " + "\n"
                + @"		""K3"": ""K3X"",                " + "\n"
                + @"		""K4"": ""K4X"",                " + "\n"
                + @"		""RAction"": ""RActionX"",                " + "\n"
                + @"		""TrDesc"": ""TrDescX"",                " + "\n"
                + @"		""functionDesc"": ""functionDescX"",                " + "\n"
                + @"		""functionDescEn"": ""functionDescEnX"",                " + "\n"
                + @"		""DateAdded"": ""DateAddedX""                " + "\n"
                + @"    },                " + "\n"
                + @"    ""time_to_live"": 600                " + "\n"
                + @"}";
            body = body.Replace("ClientNumber", ClientNumber);
            body = body.Replace("BUUserX", c.BUUser);
            body = body.Replace("TIDX", c.TID.ToString());
            body = body.Replace("CompNoX", c.CompNo.ToString());
            body = body.Replace("FIDX", c.FID.ToString());
            body = body.Replace("K1X", c.K1.ToString());
            body = body.Replace("K2X", c.K2.ToString());
            body = body.Replace("K3X", c.K3.ToString());
            body = body.Replace("K4X", c.K4.ToString());
            body = body.Replace("RActionX", c.RAction.ToString());
            body = body.Replace("TrDescX", c.TrDesc.ToString());
            body = body.Replace("functionDescX", c.FunctionDesc);
            body = body.Replace("functionDescEnX", c.FunctionDescEn);
            body = body.Replace("DateAddedX", c.DateAdded.ToString("yyyy-MM-dd"));

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            client.Execute(request);
        }
        private List<SignalRUser> users
        {
            get
            {
                var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(cache) as dynamic;
                List<SignalRUser> x = new List<SignalRUser>();
                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    x.Add(
                        new SignalRUser()
                        {
                            Type = cacheItemValue.Value.ToString().Split('-')[0],
                            UserID = cacheItemValue.Value.ToString().Split('-')[1],
                            connection = cacheItemValue.Key.ToString(),
                        });
                }
                return x.Where(c => c.Type == "user").ToList();
            }
        }

        private object Encrypt(string value, string key)
        {
            AESCryp.Key = key;
            var Encrypt = AESCryp.Encrypt(value);
            return Ok(new { Encrypt });
        }

        private object Decrypt(string value, string key)
        {
            AESCryp.Key = key;
            var Decrypt = AESCryp.Decrypt(value);
            return Ok(new { Decrypt });
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
        private string AlphaWFFireBase
        {
            get
            {
                return Configuration["AlphaWFFireBase"];
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
