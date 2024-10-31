using AlphaAPI.BasicAuth;
using AlphaAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace AlphaAPI.Controllers
{
    public class IntegrationController : ControllerBase
    {
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

        [AllowAnonymous]
        [HttpGet("getUsers")]
        [IntegrationAuth]
        public object getUsers()
        {
            DataTable dt = GetDataTable(string.Format(" exec HRP_Mobile_KasihInt"));
            return Ok(new { result = dt, error = false });
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public object SignIn(string username, string password)
        {
            DataTable dt = GetDataTable(string.Format("select isnull((SELECT EmpNum FROM HRP_Users where username = '{0}' and UserPass = '{1}'),0) as empno", username, Encode(password)));
            int empno = (int)dt.Rows[0]["empno"];
            string response = "Wrong username or password";
            bool success = false;
            bool userstopped = false;
            if (empno != 0)
            {
                response = "Login success";
                success = true;

            }
            return Ok(new { response, success, userstopped });
        }

        private DataTable GetDataTable(string query)
        {
            SqlConnection conn = new SqlConnection(string.Format("Server={0};Database={1};User ID=admin;Password=GceSoft01042000", sName, dbName));
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 120;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            return dt;
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
        [NonAction]
        private string Encode(string pWord)
        {
            int intCounter;
            int intSubCount;
            string strEncodedWord;
            strEncodedWord = "";
            intSubCount = 0;

            for (intCounter = 0; intCounter < pWord.Length; intCounter++)
            {
                intSubCount = intSubCount + 1;

                var s1 = pWord.Substring(intCounter, 1);
                var s2 = (int)s1[0];
                var s3 = s2 + intSubCount;
                var s4 = (char)s3;

                strEncodedWord = strEncodedWord + s4;

                if (intSubCount >= 2) intSubCount = 0;
            }

            return strEncodedWord;
        }

        [AllowAnonymous]
        [Route("getsales/{date}/{date2}/{CompNo}/{FromItem}/{ToItem}.json")]

        public object getsales(DateTime date, DateTime date2, int CompNo, string FromItem, string ToItem)
        {
            try
            {
                DataTable dt = GetDataTable(string.Format(" exec RG_Junidi_SalesManItemsSales_withtax @FromDate = '{0}' ,@ToDate ='{1}' ,@FromItem ='{2}' ,@ToItem ='{3}',@CompNo={4}", date.ToString("yyyy-MM-dd"), date2.ToString("yyyy-MM-dd"), FromItem,ToItem, CompNo));
                return dt;
            }
            catch (Exception g)
            {
                return "[ERORR]";
            }
        }
    }



}
