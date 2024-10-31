using AlphaAPI.BasicAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AlphaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[VoltAuth]
    public class voltController : ControllerBase
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
        public object PostSalaryVoucher([FromBody]CompanyModel model)
        {
            CompanyInfo companyInfo = new CompanyInfo
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
            else if ( model == null )
            {
                companyInfo.message = "false";
                companyInfo.Success = "1";
                return companyInfo;
            }
            else if ( model.PayrollVoucherDetail == null )
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
            SqlCommand cmd = new SqlCommand("VOLT_SaveData");
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

        void setParameters(CompanyModel model, SqlCommand cmd)
        {
            DataTable master = new DataTable();
            DataTable details = new DataTable();
            #region HEADER
            master.Columns.Add("trx_id");
            master.Columns.Add("Detl_Ser");
            master.Columns.Add("gltrans_notes");
            master.Columns.Add("PostingDate");
            master.Columns.Add("TransType");
            foreach (var mster in model.PayrollVoucherMaster)
            {
                master.Rows.Add(mster.trx_id, mster.Detl_Ser, mster.gltrans_notes, mster.PostingDate,mster.TransType);
            }

            #endregion


            #region DETAIL
            details.Columns.Add("Detl_Trx_Desc");
            details.Columns.Add("AR_AP_Code");
            details.Columns.Add("detl_ser");
            details.Columns.Add("Month");
            details.Columns.Add("Year");
            details.Columns.Add("CompanyID");
            details.Columns.Add("Trx_Debit");
            details.Columns.Add("Trx_Credit");
            details.Columns.Add("Remarks");
            details.Columns.Add("PostingDate");
            details.Columns.Add("Dim1");
            foreach (var det in model.PayrollVoucherDetail)
            {
                details.Rows.Add(det.Detl_Trx_Desc, det.AR_AP_Code, det.detl_ser, det.Month, det.Year, det.CompanyID, det.Trx_Debit, det.Trx_Credit, det.Remarks, det.PostingDate, det.Dim1);
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
    public class CompanyInfo
    {
        public string Success { get; set; }
        public string message { get; set; }
    }
    public class CompanyModel
    {
        public List<PayrollVoucherMaster> PayrollVoucherMaster { get; set; }
        public List<PayrollVoucherDetails> PayrollVoucherDetail { get; set; }
    }
    public class PayrollVoucherMaster
    {
        public string trx_id { get; set; } // Transaction ID always set to 1
        public string Detl_Ser { get; set; } // empty string, not used
        public string gltrans_notes { get; set; } // Payroll month/year note
        public string PostingDate { get; set; } // posted date
        public int TransType { get; set; } // posted date
    }
    public class PayrollVoucherDetails
    {
        public string Detl_Trx_Desc { get; set; } // Transaction type
        public string AR_AP_Code { get; set; } // Account code
        public string detl_ser { get; set; } // Transaction type
        public string Month { get; set; } // Payroll month
        public string Year { get; set; } // Payroll year
        public string CompanyID { get; set; } // Company id
        public double Trx_Debit { get; set; } // Account Debit
        public double Trx_Credit { get; set; } // Account Credit
        public string Remarks { get; set; } // Extra notes
        public string PostingDate { get; set; } // Posted Date
        public string Dim1 { get; set; } // Department Code
    }
}
