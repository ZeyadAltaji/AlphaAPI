using AlphaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AlphaAPI.Controllers
{
    public class PaidInvoices : ControllerBase
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
       
        private string SecretKey
        {
            get
            {
                return Configuration["Secret-Key"];
            }
        }
        
        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database=DB;User ID=Admin;Password=GceSoft01042000", sName);
            }
        }

        [NonAction]
        private DataTable Fire(string ProcedureName)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(ProcedureName)
            {
                Connection = conn,
                CommandType = CommandType.StoredProcedure
            };

            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            return dt;
        }
        [HttpPost("PaidInvoices/GetPaidInvoices")]
        public object GetPaidInvoices()
        {
            DataTable x = Fire("GL_PaidInvoices_GetInoivceid");
            long inoivceid = x.Rows[0].Field<long>("InvoiceId");
            var client = new RestClient($"{Configuration["API-Link"]}/PaidInvoices?lastInvoiceId={inoivceid}&numberOfRows=25");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Secret-Key", SecretKey);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            Invoice data = JsonConvert.DeserializeObject<Invoice>(response.Content);
            if (data != null)
                Task.Factory.StartNew(() => InsertData(data.data.ToList()));


            return Ok(new { data = data.data.ToList().Count(), StatusCode = response.StatusCode });
        }
        [HttpPost("PaidInvoices/GetPaidInvoicesDate")]
        public object GetPaidInvoicesDate()
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            var client = new RestClient($"{Configuration["API-Link"]}/PaidInvoicesByDate?lastDate={date}&numberOfRows=25");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Secret-Key", SecretKey);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            Invoice data = JsonConvert.DeserializeObject<Invoice>(response.Content);
            if (data != null)
                Task.Factory.StartNew(() => InsertData(data.data.ToList()));


            return Ok(new { data = data.data.ToList().Count(), StatusCode = response.StatusCode });
        }
        void InsertData(List<Invo> inv)
        {

            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("GL_PaidInvoices_SaveDataAPI");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(HDT(inv));
            cmd.Parameters.Add(DDT(inv));
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);

        }
        SqlParameter HDT(List<Invo> inv)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("InvoiceId");
            tbl.Columns.Add("InvoiceReference");
            tbl.Columns.Add("InvicePaidDate");
            tbl.Columns.Add("PaymentType");
            tbl.Columns.Add("InvoiceAmount");
            tbl.Columns.Add("InstitutionId");
            tbl.Columns.Add("TaxNumber");
            tbl.Columns.Add("CommercialName");
            tbl.Columns.Add("InstitutionName");
            tbl.Columns.Add("s");
            foreach (var i in inv)
            {
                tbl.Rows.Add(
                    i.InvoiceId,
                    i.InvoiceReference,
                    i.InvicePaidDate.ToString("yyyy/MM/dd"),
                    i.PaymentType,
                    i.InvoiceAmount,
                    i.InstitutionId,
                    i.TaxNumber,
                    i.CommercialName,
                    i.InstitutionName,
                    inv.IndexOf(i) + 1
                    );
            }
            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@Headers";
            Parameter.SqlDbType = SqlDbType.Structured;

            Parameter.Value = tbl;
            return Parameter;
        }
        SqlParameter DDT(List<Invo> inv)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Id");
            tbl.Columns.Add("InvoiceId");
            tbl.Columns.Add("ServiceName");
            tbl.Columns.Add("Year");
            tbl.Columns.Add("PeriodCode");
            tbl.Columns.Add("Amount");
            tbl.Columns.Add("Penalty");
            tbl.Columns.Add("Value");
            tbl.Columns.Add("ServiceType");
            tbl.Columns.Add("ReferenceNumber");
            tbl.Columns.Add("CountryId");
            foreach (var h in inv)
            {
                if (h.InvoiceItems != null)
                {
                    foreach (var i in h.InvoiceItems)
                    {
                        tbl.Rows.Add(tbl.Rows.Count + 1, h.InvoiceId, i.ServiceName, i.Year, i.PeriodCode, i.Amount, i.Penalty, i.Value, i.ServiceType, i.ReferenceNumber,i.CountryId);
                    }
                }

            }
            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@Details";
            Parameter.SqlDbType = SqlDbType.Structured;

            Parameter.Value = tbl;
            return Parameter;
        }
    }
}











