using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace AlphaAPI.Controllers
{
    public class GeneralController : ControllerBase
    {
        [AllowAnonymous]
        [Route("files/employees/{Comp_num}/{Emp_num}/{Profile}")]
        public async Task<IActionResult> GetImage(short Comp_num, int Emp_num, string v)
        {
            string connectionstring = "";
            connectionstring = string.Format("Server={0};Database={1};User ID=Admin;Password=GceSoft01042000", sName, dbName);
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("HRP_Mobile_EmployeePhoto");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Emp_num", SqlDbType.Int).Value = Emp_num;
            cmd.Parameters.Add("@Comp_num", SqlDbType.SmallInt).Value = Comp_num;
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Response.Headers.Add("Last-Modified", "Mon, 04 Jan 2021 15:01:02 GMT");
            Response.Headers.Add("Accept-Ranges", "bytes");
            Response.Headers.Add("ETag", "1d6e2aa6aeb0ab6");

            await Task.Run(() => Da.Fill(dt));
            string img = "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";
            byte[] imgData = Convert.FromBase64String(img);
            if (dt.Rows.Count > 0)
            {
                imgData = dt.Rows[0].Field<byte[]>("image");
                if (imgData == null || imgData.Length == 1)
                {
                    imgData = Convert.FromBase64String(img);
                }
            }
            return File(imgData, "image/png");
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

    }
}
