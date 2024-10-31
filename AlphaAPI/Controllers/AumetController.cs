using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using System;
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
    public class AumetController : ControllerBase
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
        [HttpGet("Amuet/GetData")]
        public object GetData(DateTime fromDate, DateTime toDate, string set_processing)
        {

            var client = new RestClient($"{Configuration["Aumet-url"]}/order?from_datetime={fromDate.ToString("yyyy-MM-dd")}&to_datetime={toDate.ToString("yyyy-MM-dd")}&set_processing={set_processing}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("API-KEY", Configuration["AumetKey"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            AumetData data = JsonConvert.DeserializeObject<AumetData>(response.Content);
            if (data != null)
                Task.Factory.StartNew(() => InsertData(data.data.Where(x => x.pharmacy_id.ToUpper() != "NULL").ToList()));
            return Ok(new { data = data.data.Where(x => x.pharmacy_id.ToUpper() != "NULL").ToList().Count(), StatusCode = response.StatusCode });

        }

        [AllowAnonymous]
        [HttpGet("Amuet/GetPaidData")]
        public object GetPaidData(DateTime fromDate, DateTime toDate, string set_processing)
        {

            var client = new RestClient($"{Configuration["Aumet-url"]}/order?from_datetime={fromDate.ToString("yyyy-MM-dd")}&to_datetime={toDate.ToString("yyyy-MM-dd")}&set_processing={set_processing}&status=10&payment_status=paid");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("API-KEY", Configuration["AumetKey"]);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            IRestResponse response = client.Execute(request);
            AumetData data = JsonConvert.DeserializeObject<AumetData>(response.Content);
            if (data != null)
                Task.Factory.StartNew(() => InsertData(data.data.Where(x => x.pharmacy_id.ToUpper() != "NULL").ToList()));
            return Ok(new { data = data.data.Where(x => x.pharmacy_id.ToUpper() != "NULL").ToList().Count(), StatusCode = response.StatusCode });

        }

        [AllowAnonymous]
        [HttpGet("Amuet/ChangeOrderStatus")]
        public object ChangeOrderStatus(int order_id, int status_id)
        {
            var client = new RestClient($"{Configuration["Aumet-url"]}/order");
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AlwaysMultipartFormData = false;
            request.AddHeader("API-KEY", Configuration["AumetKey"]);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                order_id = order_id,
                status_id = status_id
            };
            request.AddJsonBody(body);
            IRestResponse response = client.Execute(request);
            return Ok(new { data = response.Content, StatusCode = 200 });
        }

        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database={1};User ID=admin;Password=GceSoft01042000", sName, dbName);
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

        void InsertData(List<Inv> inv)
        {
            //foreach (var item in inv.Where(x => x.pharmacy_id.ToUpper() != "NULL"))
            //{
            //    List<Inv> inv0 = new List<Inv>();
            //    inv0.Add(item);
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("int_Aumet_SaveData");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(HDT(inv));
            cmd.Parameters.Add(DDT(inv));
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            //}

        }

        SqlParameter HDT(List<Inv> inv)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("id");
            tbl.Columns.Add("total");
            tbl.Columns.Add("subtotal");
            tbl.Columns.Add("status");
            tbl.Columns.Add("discount");
            tbl.Columns.Add("vat");
            tbl.Columns.Add("created_at");
            tbl.Columns.Add("pharmacy_id");
            tbl.Columns.Add("billing_number");
            tbl.Columns.Add("bill_status");
            tbl.Columns.Add("salesman_id");
            tbl.Columns.Add("salesman_name");
            tbl.Columns.Add("s");
            foreach (var i in inv)
            {
                if (i.salesman == null)
                    i.salesman = new Salesman() { id = "", name = "" };

                string billing_number = "";
                string bill_status = "";
                if (i.billing != null)
                {
                    billing_number = i.billing.billing_number;
                    bill_status = i.billing.bill_status;
                }
                tbl.Rows.Add(
                    i.id,
                    i.total,
                    i.sub_total,
                    i.status,
                    i.discount,
                    i.vat,
                    i.created_at,
                    i.pharmacy_id.Trim(),
                    billing_number,
                    bill_status,
                    i.salesman.id,
                    i.salesman.name,
                    inv.IndexOf(i) + 1
                    );
            }
            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@Headers";
            Parameter.SqlDbType = SqlDbType.Structured;

            Parameter.Value = tbl;
            return Parameter;
        }

        SqlParameter DDT(List<Inv> inv)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("id");
            tbl.Columns.Add("name");
            tbl.Columns.Add("quantity");
            tbl.Columns.Add("discount");
            tbl.Columns.Add("item_code");
            tbl.Columns.Add("tax");
            tbl.Columns.Add("price");
            tbl.Columns.Add("bonus");
            tbl.Columns.Add("total");
            tbl.Columns.Add("s");
            foreach (var h in inv)
            {
                if (h.items != null)
                {
                    foreach (var i in h.items)
                    {
                        tbl.Rows.Add(h.id, i.name, i.quantity, i.discount, i.item_code, i.tax, i.price, i.bonus, i.total, tbl.Rows.Count + 1);
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

public class AumetData
{
    public List<Inv> data { get; set; }
}

public class Inv
{
    public int id { get; set; }
    public string total { get; set; }
    public string sub_total { get; set; }
    public int status { get; set; }
    public string discount { get; set; }
    public string vat { get; set; }
    public string created_at { get; set; }
    public string pharmacy_id { get; set; }
    public List<Item> items { get; set; }
    public Billing? billing { get; set; }
    public Salesman? salesman { get; set; }
}

public class Salesman
{
    public string id { get; set; }
    public string name { get; set; }
}

public class Billing
{
    public int? id { get; set; }
    public string billing_number { get; set; }
    public string bill_status { get; set; }
    public string updated_at { get; set; }
}

public class Item
{
    public string name { get; set; }
    public int? quantity { get; set; }
    public string discount { get; set; }
    public string item_code { get; set; }
    public string tax { get; set; }
    public string price { get; set; }
    public int? bonus { get; set; }
    public float? total { get; set; }
}
