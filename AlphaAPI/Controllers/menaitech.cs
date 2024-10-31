using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AlphaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class menaitech : ControllerBase
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
        private string sName
        {
            get
            {
                return Configuration["server"];
            }
        }
        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database=Integration;User ID=Admin;Password=GceSoft01042000", sName);
            }
        }

        [HttpPost("PostSalaryVoucher")]
        public object PostSalaryVoucher([FromBody] CompanyModels model)
        {
            CompanyInfos companyInfo = new CompanyInfos
            {
                Success = "false",
                message = "can't cast the data"
            };
            if (!ModelState.IsValid)
            {
                companyInfo.message = "false";
                companyInfo.Success = "0";
                return companyInfo;

            }
            else if (model == null)
            {
                companyInfo.message = "false";
                companyInfo.Success = "1";
                return companyInfo;
            }
            else if (model.PayrollVoucherDetail == null)
            {
                companyInfo.message = "false";
                companyInfo.Success = "2";
                return companyInfo;
            }
            else if (model.PayrollVoucherMaster == null)
            {
                companyInfo.message = "false";
                companyInfo.Success = "3";
                return companyInfo;
            }

            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Payroll_SaveData");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            setParameters(model, cmd);
            int TransType = model.PayrollVoucherMaster.Select(x => x.TransType).FirstOrDefault();
            cmd.Parameters.Add("@TransType", SqlDbType.Int).Value = TransType;

            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;

            try
            {
                Da.Fill(dt);
                companyInfo.message = "true";
                companyInfo.Success = "Done";
            }
            catch (System.Exception e)
            {
                companyInfo.message = e.Message;
            }
            return companyInfo;
        }

        void setParameters(CompanyModels model, SqlCommand cmd)
        {
            DataTable master = new DataTable();
            DataTable details = new DataTable();
            #region HEADER
            master.Columns.Add("gltrans_notes");
            master.Columns.Add("PostingDate");
            master.Columns.Add("TransType");
            foreach (var mster in model.PayrollVoucherMaster)
            {
                master.Rows.Add(mster.gltrans_notes, mster.PostingDate, mster.TransType);
            }

            #endregion


            #region DETAIL
            details.Columns.Add("Detl_Trx_Desc");
            details.Columns.Add("AR_AP_Code");
            details.Columns.Add("Month");
            details.Columns.Add("Year");
            details.Columns.Add("CompanyID");
            details.Columns.Add("Trx_Debit");
            details.Columns.Add("Trx_Credit");
            details.Columns.Add("Remarks");
            details.Columns.Add("Dept");
            foreach (var det in model.PayrollVoucherDetail)
            {
                details.Rows.Add(det.Detl_Trx_Desc, det.AR_AP_Code,  det.Month, det.Year, det.CompanyID, det.Trx_Debit, det.Trx_Credit, det.Remarks,  det.Dept);
            }

            #endregion

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@master";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = master;

            SqlParameter Parameter2 = new SqlParameter();
            Parameter2.ParameterName = "@details";
            Parameter2.SqlDbType = SqlDbType.Structured;
            Parameter2.Value = details;


            cmd.Parameters.Add(Parameter);
            cmd.Parameters.Add(Parameter2);

        }
    }
    public class CompanyInfos
    {
        public string Success { get; set; }
        public string message { get; set; }
    }
    public class CompanyModels
    {
        public List<PayrollVoucherMasters> PayrollVoucherMaster { get; set; }
        public List<PayrollVoucherDetailss> PayrollVoucherDetail { get; set; }
    }
    public class PayrollVoucherMasters
    {
        public string gltrans_notes { get; set; } // Payroll month/year note
        public string PostingDate { get; set; } // posted date
        public int TransType { get; set; } // posted date
    }
    public class PayrollVoucherDetailss
    {
        public string Detl_Trx_Desc { get; set; } // Transaction type
        public string AR_AP_Code { get; set; } // Account code
        public string Month { get; set; } // Payroll month
        public string Year { get; set; } // Payroll year
        public string CompanyID { get; set; } // Company id
        public double Trx_Debit { get; set; } // Account Debit
        public double Trx_Credit { get; set; } // Account Credit
        public string Remarks { get; set; } // Extra notes
        public string Dept { get; set; } // Department Code
    }
}
