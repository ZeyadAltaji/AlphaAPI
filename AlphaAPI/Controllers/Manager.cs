using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AlphaAPI.Controllers
{
    public class Manager : Controller
    {
        string connectionstring = string.Format("Server=192.168.12.18;Database=MobileApps;User ID=sa2;Password=sa2");
        string connectionstring2 = string.Format("Server=192.168.12.6;Database=db;User ID=admin;Password=GceSoft01042000");

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

        [NonAction]
        private object excute2(string ProcedureName, string outPut = "", bool row = false, bool HasRows = false, string value0 = "", bool dataTable = false, bool dataSet = false)
        {

            SqlConnection conn = new SqlConnection(connectionstring2);
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


        [Route("M/General")]
        public object General(Dictionary<string, string> Parameter)
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

        [Route("M/General6")]
        public object General6(Dictionary<string, string> Parameter)
        {
            if (!Parameter.ContainsKey("pn")) return Ok(new { result = "pn error!!", error = true });
            string Procedure = Parameter.Where(x => x.Key == "pn").FirstOrDefault().Value;
            foreach (var p in Parameter.Where(x => x.Key != "pn"))
            {
                Parameters.AddWithValue("@" + p.Key, p.Value);
            }
            DataTable result = (DataTable)excute2(Procedure, "", false, false, "", true);
            return Ok(new { result, error = false });
        }

    }
}
