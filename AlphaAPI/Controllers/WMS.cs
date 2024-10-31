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
using System.Xml.Serialization;

namespace AlphaAPI.Controllers
{
    public class WMS : ControllerBase
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
        private string WMS_Username
        {
            get
            {
                return Configuration["WMS-Username"];
            }
        }
        private string WMS_Password
        {
            get
            {
                return Configuration["WMS-Password"];
            }
        }
        string connectionstring
        {
            get
            {
                return string.Format("Server={0};Database=Integration;User ID=Admin;Password=GceSoft01042000", sName);
            }
        }

        [HttpPost("WMS/PushItem")]
        public object PushItem(short CompNo, string ItemNo)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("WMS_GET_ITEM");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CompNo", CompNo);
            cmd.Parameters.AddWithValue("ItemNo", ItemNo);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            if (dt.Rows.Count == 0)
                return Ok(new { Result = "Error: Could not load item from SQL", StatusCode = 500 });

            var client = new RestClient($"{Configuration["WMS-url"]}/INFOR_ENTERPRISE/items");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            var body = getItemJson(dt.Rows[0]);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), body, response.Content, client.BaseUrl.ToString());
            return Ok(new { Request = "Done", StatusCode = response.StatusCode, Result = response.Content });
        }

        [HttpPost("WMS/PushItems")]
        public object PushItems()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("WMS_GET_ITEMS");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("CompNo", CompNo);
            //cmd.Parameters.AddWithValue("ItemNo", ItemNo);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            if (dt.Rows.Count == 0)
                return Ok(new { Result = "Error: Could not load item from SQL", StatusCode = 500 });

            var client = new RestClient($"{Configuration["WMS-url"]}/INFOR_ENTERPRISE/items/list");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");

            List<string> blocks = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                blocks.Add(getItemJson(row));
            }
            string filter = String.Join(",", blocks.ToArray());
            string body = $"[{filter}]";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), body, response.Content, client.BaseUrl.ToString());
            return Ok(new { Request = "Done", StatusCode = response.StatusCode, Result = response.Content });
        }

        private string getItemJson(DataRow row)
        {
            if (row["itemcharacteristic1"].ToString().Trim() == "") row["itemcharacteristic1"] = "null";
            if (row["itemcharacteristic2"].ToString().Trim() == "") row["itemcharacteristic2"] = "null";
            if (row["style"].ToString().Trim() == "") row["style"] = "null";
            var body = @"{" +
            @"    ""storerkey"": """ + row["storerkey"] + @"""," +
            @"    ""sku"": """ + row["sku"] + @"""," +
            @"    ""descr"": """ + row["descr"] + @"""," +
            @"    ""stockcategory"": """ + row["stockcategory"] + @"""," +
            @"    ""commodityclass"": """ + row["commodityclass"] + @"""," +
            @"    ""collection"": """ + row["collection"] + @"""," +
            @"    ""style"": """ + row["style"] + @"""," +
            @"    ""itemcharacteristic1"": """ + row["itemcharacteristic1"] + @"""," +
            @"    ""itemcharacteristic2"": """ + row["itemcharacteristic2"] + @"""," +
            @"    ""shelflifeonreceiving"": " + row["shelflifeonreceiving"] + @"," +
            @"    ""stdcube"": " + row["stdcube"] + @"," +
            @"    ""stdgrosswgt"": " + row["stdgrosswgt"] + @"," +
            @"    ""notes1"": """ + row["notes1"] + @"""," +
            @"    ""altsku"": """ + row["altsku"] + @"""," +
            @"    ""countryoforigin"": """ + row["countryoforigin"] + @"""" +
            @"}";
            return body;
        }


        private string getItemJson2(DataRow row)
        {
            var body = @"{" +
            @"    ""storerkey"": """ + row["storerkey"] + @"""," +
            @"    ""sku"": """ + row["sku"] + @"""," +
            @"    ""externreceiptkey"": """ + row["externreceiptkey"] + @"""," +
            @"    ""externlineno"": """ + row["externlineno"] + @"""," +
            @"    ""lottable03"": """ + row["lottable03"] + @"""," +
            @"    ""susr1"": """ + row["susr1"] + @"""," +
            @"    ""qtyexpected"": " + row["qtyexpected"] + @"," +
            @"    ""uom"": """ + row["uom"] + @"""" +
            @"}";
            return body;
        }

        private string getItemJson3(DataRow row, int x)
        {
            var body = "";
            if (row["susr1"].ToString() == "null")
                body = @"{" +
                            @"    ""storerkey"": """ + row["storerkey"] + @"""," +
                            @"    ""sku"": """ + row["sku"] + @"""," +
                            @"    ""externlineno"": """ + x.ToString() + @"""," +
                            @"    ""externorderkey"": """ + row["externlineno"] + @"""," +
                            @"    ""lottable03"": """ + row["lottable03"] + @"""," +
                            @"    ""susr1"": " + row["susr1"] + @"," +
                            @"    ""openqty"": " + row["qtyexpected"] + @"," +
                            @"    ""originalqty"": " + row["qtyexpected"] + @"," +
                            @"    ""uom"": """ + row["uom"] + @"""" +
                            @"}";
            else
                body = @"{" +
                @"    ""storerkey"": """ + row["storerkey"] + @"""," +
                @"    ""sku"": """ + row["sku"] + @"""," +
                @"    ""externlineno"": """ + row["externlineno"] + @"""," +
                @"    ""lottable03"": """ + row["lottable03"] + @"""," +
                @"    ""susr1"": """ + row["susr1"] + @"""," +
                @"    ""openqty"": " + row["qtyexpected"] + @"," +
                @"    ""originalqty"": " + row["qtyexpected"] + @"," +
                @"    ""uom"": """ + row["uom"] + @"""" +
                @"}";
            return body;
        }

        [HttpPost("WMS/PushASN")]
        public object PushASN(short CompNo, short OrderYear, string OrderNo, string TawreedNo, string InbboundSer, string type)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dtHF = new DataTable();
            DataTable dtDF = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("WMS_GET_ASN");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CompNo", CompNo);
            cmd.Parameters.AddWithValue("OrderYear", OrderYear);
            cmd.Parameters.AddWithValue("TawreedNo", TawreedNo);
            cmd.Parameters.AddWithValue("OrderNo", OrderNo);
            cmd.Parameters.AddWithValue("InbboundSer", InbboundSer);
            cmd.Parameters.AddWithValue("type", type);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.TableMappings.Add("Table", "Header");
            Da.TableMappings.Add("Table1", "Details");
            DataSet ds = new DataSet();
            Da.Fill(ds);
            dtHF = ds.Tables["Header"];
            dtDF = ds.Tables["Details"];

            Da.Fill(dtHF);
            if (dtHF.Rows.Count == 0 || dtHF.Rows.Count == 0)
                return Ok(new { Result = "Error: Could not load voucher from SQL", StatusCode = 500 });



            List<string> blocks = new List<string>();
            foreach (DataRow row in dtDF.Rows)
            {
                blocks.Add(getItemJson2(row));
            }
            string filter = String.Join(",", blocks.ToArray());
            string details = $"[{filter}]";


            var body = "";
            if (type == "16")
                body = @"{" +
               @"    ""externreceiptkey"": """ + $"{ dtHF.Rows[0]["externreceiptkey"]}" + @"""," +
               @"    ""storerkey"": ""KASIH""," +
               @"    ""type"": """ + dtHF.Rows[0]["type"] + @"""," +
               @"    ""ext_udf_str2"": """ + dtHF.Rows[0]["warehousereference"] + @"""," +
               @"    ""externalreceiptkey2"": """ + dtHF.Rows[0]["externreceiptkey2"] + @"""," +
               @"    ""ext_udf_str1"": """ + dtDF.Rows[0]["susr1"] + @"""," +
               @"    ""receiptdetails"": " + details + @"}";
            else
                body = @"{" +
               @"    ""externreceiptkey"": """ + $"{ dtHF.Rows[0]["externreceiptkey"]}" + @"""," +
               @"    ""storerkey"": ""KASIH""," +
               @"    ""suppliercode"": """ + dtHF.Rows[0]["suppliercode"] + @"""," +
               @"    ""type"": """ + dtHF.Rows[0]["type"] + @"""," +
               @"    ""ext_udf_str2"": """ + dtHF.Rows[0]["warehousereference"] + @"""," +
               @"    ""susr5"": """ + dtHF.Rows[0]["susr5"] + @"""," +
               @"    ""externalreceiptkey2"": """ + dtHF.Rows[0]["externreceiptkey2"] + @"""," +
               @"    ""ext_udf_str1"": """ + dtDF.Rows[0]["susr1"] + @"""," +
               @"    ""receiptdetails"": " + details + @"}";


            var client = new RestClient($"{Configuration["WMS-url"]}/INFOR_KAPRD_{dtHF.Rows[0]["whseid"].ToString().ToLower().Trim()}/receipts");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            //var body = getItemJson(dtHF.Rows[0]);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), body, response.Content, client.BaseUrl.ToString());
         
            return Ok(new { Request = "Done", StatusCode = response.StatusCode, Result = response.Content });
        }

        [HttpPost("WMS/PushSO")]
        public object PushSO(short CompNo, short OrderYear, int OrderNo, int type)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            DataTable dtDF = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand($"WMS_GET_SO_TYPE{type}");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("CompNo", CompNo);
            cmd.Parameters.AddWithValue("OrderYear", OrderYear);
            cmd.Parameters.AddWithValue("OrderNo", OrderNo);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.TableMappings.Add("Table", "Header");
            Da.TableMappings.Add("Table1", "Details");
            DataSet ds = new DataSet();
            Da.Fill(ds);
            dt = ds.Tables["Header"];
            dtDF = ds.Tables["Details"];

            if (dt.Rows.Count == 0 || dtDF.Rows.Count == 0)
                return Ok(new { StatusCode = 500 });

            List<string> blocks = new List<string>();
            foreach (DataRow row in dtDF.Rows)
            {
                blocks.Add(getItemJson3(row, dtDF.Rows.IndexOf(row) + 1));
            }
            string filter = String.Join(",", blocks.ToArray());
            string details = $"[{filter}]";
            DataRow dr = dt.Rows[0];

            var body = @"{" +
@"    ""externorderkey"": """ + $"{ OrderNo}" + @"""," +
@"    ""ext_udf_str1"": """ + $"{ dr["ext_udf_str1"]}" + @"""," +
@"    ""destinationnestid"": """ + $"{ dr["destinationnestid"]}" + @"""," +
@"    ""externalorderkey2"": """ + $"{ dr["externalorderkey2"]}" + @"""," +
@"    ""consigneekey"": """ + $"{ dr["consigneekey"]}" + @"""," +
@"    ""storerkey"": ""KASIH""," +
@"    ""type"": """ + $"{ dr["type"]}" + @"""," +
@"    ""ext_udf_str1"": """ + $"{ dr["ext_udf_str1"]}" + @"""," +
@"    ""ext_udf_str2"": """ + $"{ dr["ext_udf_str2"]}" + @"""," +
@"    ""orderdetails"": " + details + @"}";


            var client = new RestClient($"{Configuration["WMS-url"]}/INFOR_KAPRD_{dr["whseid"].ToString().ToLower().Trim()}/shipments");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            //var body = getItemJson(dtHF.Rows[0]);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), body, response.Content, client.BaseUrl.ToString());

            return Ok(new {  StatusCode = response.StatusCode });
        }

        [HttpPost("WMS/GetAsnVerified")]
        public object GetAsnVerified(string warehouse, string updatestatus)
        {
            var client = new RestClient($"{Configuration["WMS-url"]}/{warehouse}/exports?type=AsnVerified&asJson=true" + updatestatus);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string sc = response.Content;
            var data = JsonConvert.DeserializeObject<List<Wms_Class>>(sc);
            XmlSerializer serializer = new XmlSerializer(typeof(AsnVerified));
            AsnVerified result;

            foreach (Wms_Class hf in data)
            {
                using (TextReader reader = new StringReader(hf.message))
                {
                    try
                    {
                        result = (AsnVerified)serializer.Deserialize(reader);

                    }
                    catch (Exception f)
                    {

                        throw;
                    }
                    SqlConnection conn = new SqlConnection(connectionstring);
                    DataTable dt = new DataTable();
                    SqlDataAdapter Da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("WMS_SaveAsnVerified");
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    setAsnVerifiedParameters(result, cmd);
                    cmd.CommandTimeout = 90;
                    Da.SelectCommand = cmd;
                    try
                    {
                        Da.Fill(dt);
                    }
                    catch(Exception e)
                    {
                        WriteLog(response.StatusCode.ToString(), "", e.Message, client.BaseUrl.ToString());
                    }
                    //Da.Fill(dt);
                }
            }
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), "", response.Content, client.BaseUrl.ToString());

            return Ok(new { result = "", DataCount = data.Count });
        }

        [HttpPost("WMS/GetORDERSHIPPED")]
        public object GetORDERSHIPPED(string warehouse, string updatestatus)
        {
            var client = new RestClient($"{Configuration["WMS-url"]}/{warehouse}/exports?type=ORDERSHIPPED&asJson=yes" + updatestatus);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string sc = response.Content;
            var data = JsonConvert.DeserializeObject<List<Wms_Class>>(sc);
            XmlSerializer serializer = new XmlSerializer(typeof(ShipmentConfirmation));
            ShipmentConfirmation result;

            foreach (Wms_Class hf in data)
            {
                using (TextReader reader = new StringReader(hf.message))
                {
                    try
                    {
                        result = (ShipmentConfirmation)serializer.Deserialize(reader);
                        SqlConnection conn = new SqlConnection(connectionstring);
                        DataTable dt = new DataTable();
                        SqlDataAdapter Da = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("WMS_SaveORDERSHIPPED");
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        setORDERSHIPPEDParameters(result, cmd);
                        cmd.CommandTimeout = 90;
                        Da.SelectCommand = cmd;
                        Da.Fill(dt);
                    }
                    catch (Exception ddd)
                    {
                        WriteLog(response.StatusCode.ToString(), "", response.Content, client.BaseUrl.ToString());

                    }

                }
            }
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), "", response.Content, client.BaseUrl.ToString());

            return Ok(new { result = "", DataCount = data.Count });

        }

        [HttpPost("WMS/GetADJUSTMENT")]
        public object GetADJUSTMENT(string warehouse)
        {
            int rows = 0;
            //var client = new RestClient($"{Configuration["WMS-url"]}/{warehouse}/exports?type=ADJUSTMENT&asJson=yes&updatestatus=0");
            var client = new RestClient($"{Configuration["WMS-url"]}/{warehouse}/exports?type=ADJUSTMENT&asJson=yes");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string sc = response.Content;
            var data = JsonConvert.DeserializeObject<List<ADJUSTMENTCLS>>(sc);
            XmlSerializer serializer = new XmlSerializer(typeof(Adjustment));
            Adjustment result;
            foreach (ADJUSTMENTCLS hf in data)
            {
                using (TextReader reader = new StringReader(hf.message))
                {
                    try
                    {
                        try
                        {
                            result = (Adjustment)serializer.Deserialize(reader);

                        }
                        catch (Exception f)
                        {

                            throw;
                        }
                        SqlConnection conn = new SqlConnection(connectionstring);
                        DataTable dt = new DataTable();
                        SqlDataAdapter Da = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand("WMS_SaveADJUSTMENT");
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        setADJUSTMENTParameters(result, cmd);
                        cmd.CommandTimeout = 90;
                        Da.SelectCommand = cmd;
                        Da.Fill(dt);
                        rows++;
                    }
                    catch (Exception fff)
                    {


                    }

                }
            }
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), "", response.Content, client.BaseUrl.ToString());

            return Ok(new { result = "", DataCount = rows });
        }

        [HttpPost("WMS/GetINVENTORYHOLD")]
        public object GetINVENTORYHOLD(string warehouse, string updatestatus)
        {
            var client = new RestClient($"{Configuration["WMS-url"]}/{warehouse}/exports?type=INVENTORYHOLD&asjson=true" + updatestatus);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Tenant", "INFOR");
            request.AddHeader("Username", WMS_Username);
            request.AddHeader("Password", WMS_Password);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string sc = response.Content;
            var data = JsonConvert.DeserializeObject<List<INVHOLD>>(sc);
            XmlSerializer serializer = new XmlSerializer(typeof(InventoryHold));
            InventoryHold result;
            //foreach (INVHOLD hf in data)
            //{
            //    using (TextReader reader = new StringReader(hf.message))
            //    {
            //        try
            //        {
            //            result = (InventoryHold)serializer.Deserialize(reader);
            //            SqlConnection conn = new SqlConnection(connectionstring);
            //            DataTable dt = new DataTable();
            //            SqlDataAdapter Da = new SqlDataAdapter();
            //            SqlCommand cmd = new SqlCommand("WMS_SaveINVENTORYHOLD");
            //            cmd.Connection = conn;
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            setINVENTORYHOLDParameters(result, cmd);
            //            cmd.CommandTimeout = 90;
            //            Da.SelectCommand = cmd;
            //            Da.Fill(dt);
            //        }
            //        catch (Exception ex)
            //        {

            //            WriteLog("500", "", hf.message, client.BaseUrl.ToString());
            //        }

            //    }
            //}

            foreach (INVHOLD hf in data)
            {
                using (TextReader reader = new StringReader(hf.message))
                {
                    try
                    {
                        result = (InventoryHold)serializer.Deserialize(reader);

                    }
                    catch (Exception f)
                    {

                        throw;
                    }
                    SqlConnection conn = new SqlConnection(connectionstring);
                    DataTable dt = new DataTable();
                    SqlDataAdapter Da = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand("WMS_SaveINVENTORYHOLD");
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    setINVENTORYHOLDParameters(result, cmd);
                    cmd.CommandTimeout = 90;
                    Da.SelectCommand = cmd;
                    Da.Fill(dt);
                }
            }
            if (response.StatusCode != HttpStatusCode.Created && response.StatusCode != HttpStatusCode.OK)
                WriteLog(response.StatusCode.ToString(), "", response.Content, client.BaseUrl.ToString());

            return Ok(new { result = "", DataCount = data.Count });
        }

        void setAsnVerifiedParameters(AsnVerified asn, SqlCommand cmd)
        {
            DataTable tbl = new DataTable();
            DataTable tbl2 = new DataTable();
            #region HEADER
            tbl.Columns.Add("SerialKey");
            tbl.Columns.Add("TransmitLogKey");
            tbl.Columns.Add("AddDate");
            tbl.Columns.Add("ExternReceiptKey");
            tbl.Columns.Add("ReceiptKey");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("StatusCode");
            tbl.Columns.Add("b_StorerKey");
            tbl.Columns.Add("Facility_a_StorerKey");
            tbl.Columns.Add("PlanDays");
            tbl.Columns.Add("ArchivePlanningDays");
            tbl.Columns.Add("ArchiveReportingData");
            tbl.Columns.Add("PlanEnabled");
            tbl.Columns.Add("DefaultHourlyRate");
            tbl.Columns.Add("SaveStandardsAudit");
            tbl.Columns.Add("Notes");
            tbl.Columns.Add("ext_udf_str1");
            tbl.Columns.Add("EXTERNALRECEIPTKEY2");
            tbl.Columns.Add("SupplierCode");
            tbl.Columns.Add("ext_udf_str2");
            tbl.Columns.Add("susr1");
            tbl.Columns.Add("susr5");
            DateTime dt = DateTime.ParseExact(asn.AddDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            tbl.Rows.Add(
                asn.SerialKey,
                asn.TransmitLogKey,
                dt.ToString("yyyy-MM-dd HH:mm:ss"),
                asn.AsnHeader.ExternReceiptKey,
                asn.AsnHeader.ReceiptKey,
                asn.AsnHeader.Type,
                asn.AsnHeader.StatusCode,
                asn.AsnHeader.b_StorerKey,
                asn.AsnHeader.Facility.a_StorerKey,
                asn.AsnHeader.Facility.PlanDays,
                asn.AsnHeader.Facility.ArchivePlanningDays,
                asn.AsnHeader.Facility.ArchiveReportingData,
                asn.AsnHeader.Facility.PlanEnabled,
                asn.AsnHeader.Facility.DefaultHourlyRate,
                asn.AsnHeader.Facility.SaveStandardsAudit,
                asn.AsnHeader.Notes,
                asn.AsnHeader.ext_udf_str1,
                asn.AsnHeader.EXTERNALRECEIPTKEY2,
                asn.AsnHeader.SupplierCode,
                asn.AsnHeader.ext_udf_str2,
                asn.AsnHeader.susr1,
                asn.AsnHeader.susr5
                );
            #endregion


            #region DETAIL
            tbl2.Columns.Add("WhseID");
            tbl2.Columns.Add("ReceiptKey");
            tbl2.Columns.Add("ReceiptLineNumber");
            tbl2.Columns.Add("Sku");
            tbl2.Columns.Add("Descr");
            tbl2.Columns.Add("Qty");
            tbl2.Columns.Add("PackUOM3");
            tbl2.Columns.Add("Lottable01");
            tbl2.Columns.Add("Lottable02");
            tbl2.Columns.Add("Lottable03");
            tbl2.Columns.Add("Lottable04");
            tbl2.Columns.Add("Lottable05");
            tbl2.Columns.Add("Lottable06");
            tbl2.Columns.Add("Lottable07");
            tbl2.Columns.Add("Lottable08");
            tbl2.Columns.Add("Lottable09");
            tbl2.Columns.Add("Lottable10");
            tbl2.Columns.Add("QtyExpected");
            tbl2.Columns.Add("QtyReceived");
            tbl2.Columns.Add("QtyRejected");
            tbl2.Columns.Add("PackingSlipQty");
            tbl2.Columns.Add("PackKey");
            tbl2.Columns.Add("ExternLineNo");
            tbl2.Columns.Add("ToLot");
            tbl2.Columns.Add("ToID");
            tbl2.Columns.Add("StorerKey");
            tbl2.Columns.Add("NonStockedIndicator");
            tbl2.Columns.Add("StdGrossWgt");
            tbl2.Columns.Add("StdCube");
            tbl2.Columns.Add("TareWgt");
            tbl2.Columns.Add("CountSequence");
            foreach (var det in asn.AsnHeader.AsnDetail)
            {
                DateTime? Lottable05 = null;
                if (det.Lottable05 != "")
                    Lottable05 = DateTime.ParseExact(det.Lottable05, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime? Lottable04 = null;
                if (det.Lottable04 != "")
                    Lottable04 = DateTime.ParseExact(det.Lottable04, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                tbl2.Rows.Add(
                    det.WhseID,
                    asn.AsnHeader.ReceiptKey,
                    det.ReceiptLineNumber,
                    det.Sku,
                    det.Commodity.Descr,
                    det.ITRNHoldCodes.Qty,
                    det.Pack.PackUOM3,
                    det.Lottable01,
                    det.Lottable02,
                    det.Lottable03,
                    Lottable04,
                    Lottable05,
                    det.Lottable06,
                    det.Lottable07,
                    det.Lottable08,
                    det.Lottable09,
                    det.Lottable10,
                    det.QtyExpected,
                    det.QtyReceived,
                    det.QtyRejected,
                    det.PackingSlipQty,
                    det.PackKey,
                    det.ExternLineNo,
                    det.ToLot,
                    det.ToID,
                    det.StorerKey,
                    det.NonStockedIndicator,
                    det.StdGrossWgt,
                    det.StdCube,
                    det.TareWgt,
                    det.ITRNCountSequence.CountSequence
                    );
            }

            #endregion

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@asn";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;

            SqlParameter Parameter2 = new SqlParameter();
            Parameter2.ParameterName = "@details";
            Parameter2.SqlDbType = SqlDbType.Structured;
            Parameter2.Value = tbl2;


            cmd.Parameters.Add(Parameter);
            cmd.Parameters.Add(Parameter2);
        }

        void setORDERSHIPPEDParameters(ShipmentConfirmation asn, SqlCommand cmd)
        {
            DataTable tbl = new DataTable();
            DataTable tbl2 = new DataTable();
            DataTable tbl3 = new DataTable();
            #region HEADER
            tbl.Columns.Add("SerialKey");
            tbl.Columns.Add("TransmitLogKey");
            tbl.Columns.Add("AddDate");
            tbl.Columns.Add("OrderKey");
            tbl.Columns.Add("StorerKey");
            tbl.Columns.Add("ExternOrderKey");
            tbl.Columns.Add("ExternalOrderKey2");
            tbl.Columns.Add("Priority");
            tbl.Columns.Add("ConsigneeKey");
            tbl.Columns.Add("OpenQty");
            tbl.Columns.Add("Status");
            tbl.Columns.Add("UpdateSource");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("Item_Number");
            tbl.Columns.Add("AddWho");
            tbl.Columns.Add("EditWho");
            tbl.Columns.Add("Shiptogether");
            tbl.Columns.Add("WhseId");
            tbl.Columns.Add("ext_udf_str1");
            tbl.Columns.Add("externreceiptkey2");
            tbl.Columns.Add("ext_udf_str2");
            tbl.Columns.Add("susr1");

            tbl.Rows.Add(
                asn.SerialKey,
asn.TransmitLogKey,
asn.AddDate,
asn.ShipmentOrderHeader.OrderKey,
asn.ShipmentOrderHeader.StorerKey,
asn.ShipmentOrderHeader.ExternOrderKey,
asn.ShipmentOrderHeader.ExternalOrderKey2,
asn.ShipmentOrderHeader.Priority,
asn.ShipmentOrderHeader.ConsigneeKey,
asn.ShipmentOrderHeader.OpenQty,
asn.ShipmentOrderHeader.Status,
asn.ShipmentOrderHeader.UpdateSource,
asn.ShipmentOrderHeader.Type,
asn.ShipmentOrderHeader.Item_Number,
asn.ShipmentOrderHeader.AddWho,
asn.ShipmentOrderHeader.EditWho,
asn.ShipmentOrderHeader.Shiptogether,
asn.ShipmentOrderHeader.WhseId,
asn.ShipmentOrderHeader.ext_udf_str1,
"",
"",
""
                );
            #endregion

            #region DETAIL
            tbl2.Columns.Add("OrderKey");
            tbl2.Columns.Add("OrderLineNumber");
            tbl2.Columns.Add("OrderDetailSysID");
            tbl2.Columns.Add("ExternOrderKey");
            tbl2.Columns.Add("ExternLineNo");
            tbl2.Columns.Add("Sku");
            tbl2.Columns.Add("TariffKey");
            tbl2.Columns.Add("StorerKey");
            tbl2.Columns.Add("OriginalQty");
            tbl2.Columns.Add("OpenQty");
            tbl2.Columns.Add("ShippedQty");
            tbl2.Columns.Add("AdjustedQty");
            tbl2.Columns.Add("QtyPreallocated");
            tbl2.Columns.Add("QtyAllocated");
            tbl2.Columns.Add("QtyPicked");
            tbl2.Columns.Add("UOM");
            tbl2.Columns.Add("PackKey");
            tbl2.Columns.Add("CartonGroup");
            tbl2.Columns.Add("Status");
            tbl2.Columns.Add("Lottable01");
            tbl2.Columns.Add("Lottable02");
            tbl2.Columns.Add("Lottable03");
            tbl2.Columns.Add("Lottable04");
            tbl2.Columns.Add("Lottable05");
            tbl2.Columns.Add("Lottable06");
            tbl2.Columns.Add("Lottable07");
            tbl2.Columns.Add("Lottable08");
            tbl2.Columns.Add("Lottable09");
            tbl2.Columns.Add("Lottable10");
            tbl2.Columns.Add("AddWho");
            tbl2.Columns.Add("EditWho");
            tbl2.Columns.Add("Forte_Flag");
            tbl2.Columns.Add("SkuRotation");
            tbl2.Columns.Add("ShelfLife");
            tbl2.Columns.Add("Rotation");
            tbl2.Columns.Add("RunInQTY");
            tbl2.Columns.Add("RunOutQTY");
            tbl2.Columns.Add("Product_Weight");
            tbl2.Columns.Add("Product_Cube");
            tbl2.Columns.Add("Descr");
            tbl2.Columns.Add("PDQty");
            tbl2.Columns.Add("PDQtyRejected");
            tbl2.Columns.Add("CountSequence");
            foreach (var det in asn.ShipmentOrderHeader.ShipmentOrderDetail)
            {
                tbl2.Rows.Add(
                    det.OrderKey,
det.OrderLineNumber,
det.OrderDetailSysID,
det.ExternOrderKey,
det.ExternLineNo,
det.Sku,
det.TariffKey,
det.StorerKey,
det.OriginalQty,
det.OpenQty,
det.ShippedQty,
det.AdjustedQty,
det.QtyPreallocated,
det.QtyAllocated,
det.QtyPicked,
det.UOM,
det.PackKey,
det.CartonGroup,
det.Status,
det.Lottable01,
det.Lottable02,
det.Lottable03,
det.Lottable04,
det.Lottable05,
det.Lottable06,
det.Lottable07,
det.Lottable08,
det.Lottable09,
det.Lottable10,
det.AddWho,
det.EditWho,
det.Forte_Flag,
det.SkuRotation,
det.ShelfLife,
det.Rotation,
det.RunInQTY,
det.RunOutQTY,
det.Product_Weight,
det.Product_Cube,
det.Descr,
det.PDQty,
det.PDQtyRejected,
1
                    );
            }

            #endregion

            #region PICK
            tbl3.Columns.Add("TransmitLogKey");
            tbl3.Columns.Add("OrderKey");
            tbl3.Columns.Add("PickDetailKey");
            tbl3.Columns.Add("Sku");
            tbl3.Columns.Add("OrderLineNumber");
            tbl3.Columns.Add("DropID");
            tbl3.Columns.Add("CaseID");
            tbl3.Columns.Add("ContainerTypev");
            tbl3.Columns.Add("Qty");
            tbl3.Columns.Add("ID");
            tbl3.Columns.Add("Descr");
            tbl3.Columns.Add("StdGrossWgt");
            tbl3.Columns.Add("StdNetWgt");
            tbl3.Columns.Add("StdCube");
            tbl3.Columns.Add("Class");
            tbl3.Columns.Add("ExternOrderKey");
            tbl3.Columns.Add("Lottable03");
            tbl3.Columns.Add("Lottable04");
            tbl3.Columns.Add("Lottable05");
            tbl3.Columns.Add("UOM");
            foreach (var pic in asn.ShipmentOrderHeader.PickDetail)
            {
                tbl3.Rows.Add(
                    asn.TransmitLogKey,
pic.OrderKey,
pic.PickDetailKey,
pic.Sku,
pic.OrderLineNumber,
pic.DropID,
pic.CaseID,
pic.ContainerType,
pic.Qty,
pic.ID,
pic.Descr,
pic.StdGrossWgt,
pic.StdNetWgt,
pic.StdCube,
pic.Class,
pic.ExternOrderKey,
pic.Lottable03,
pic.Lottable04,
pic.Lottable05,
pic.PackUOM3

                    );
            }

            #endregion

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@asn";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;

            SqlParameter Parameter2 = new SqlParameter();
            Parameter2.ParameterName = "@details";
            Parameter2.SqlDbType = SqlDbType.Structured;
            Parameter2.Value = tbl2;

            SqlParameter Parameter3 = new SqlParameter();
            Parameter3.ParameterName = "@picks";
            Parameter3.SqlDbType = SqlDbType.Structured;
            Parameter3.Value = tbl3;

            cmd.Parameters.Add(Parameter);
            cmd.Parameters.Add(Parameter2);
            cmd.Parameters.Add(Parameter3);
        }

        void setADJUSTMENTParameters(Adjustment asn, SqlCommand cmd)
        {
            DataTable tbl = new DataTable();
            DataTable tbl2 = new DataTable();
            #region HEADER
            tbl.Columns.Add("SerialKey");
            tbl.Columns.Add("TransmitLogKey");
            tbl.Columns.Add("AddDate");
            tbl.Columns.Add("ItrnKey");
            tbl.Columns.Add("TranType");
            tbl.Columns.Add("StorerKey");
            tbl.Columns.Add("SkuKey");
            tbl.Columns.Add("Lot");
            tbl.Columns.Add("SourceKey");
            tbl.Columns.Add("SourceType");
            tbl.Columns.Add("Status");
            tbl.Columns.Add("Lottable01");
            tbl.Columns.Add("Lottable02");
            tbl.Columns.Add("Lottable03");
            tbl.Columns.Add("Lottable04");
            tbl.Columns.Add("Lottable05");
            tbl.Columns.Add("Quantity");
            tbl.Columns.Add("PackKey");
            tbl.Columns.Add("UnitOfMeasure");
            tbl.Columns.Add("Facility");
            tbl.Columns.Add("ReasonCode");
            tbl.Columns.Add("ext_udf_str1");

            DateTime dt = DateTime.ParseExact(asn.AddDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            tbl.Rows.Add(
               asn.SerialKey,
               asn.TransmitLogKey,
               dt,
               asn.ItrnKey,
               asn.TranType,
               asn.StorerKey,
               asn.SkuKey,
               asn.Lot,
               asn.SourceKey,
               asn.SourceType,
               asn.Status,
               asn.Lottable01,
               asn.Lottable02,
               asn.Lottable03,
               asn.Lottable04,
               asn.Lottable05,
               asn.Quantity,
               asn.PackKey,
               asn.UnitOfMeasure,
               asn.Storer.Facility,
               asn.AdjustmentDetail.ReasonCode,
               asn.ext_udf_str1
                );
            #endregion


            #region DETAIL
            tbl2.Columns.Add("StorerKey");
            tbl2.Columns.Add("Sku");
            tbl2.Columns.Add("Descr");
            tbl2.Columns.Add("NonStockedIndicator");
            tbl2.Columns.Add("OCDFlag");
            tbl2.Columns.Add("OCDLabel1");
            tbl2.Columns.Add("OCDLabel2");
            tbl2.Columns.Add("AccountingEntity");
            tbl2.Columns.Add("FillQtyUOM");
            tbl2.Columns.Add("RecurCode");
            tbl2.Columns.Add("WgtUOM");
            tbl2.Columns.Add("DimenUOM");
            tbl2.Columns.Add("CubeUOM");
            tbl2.Columns.Add("StorageType");
            tbl2.Columns.Add("NMFCClass");
            tbl2.Columns.Add("MateabilityCode");
            var det = asn.Commodity;

            tbl2.Rows.Add(
                det.StorerKey,
                det.Sku,
                det.Descr,
                det.NonStockedIndicator,
                det.OCDFlag,
                det.OCDLabel1,
                det.OCDLabel2,
                det.AccountingEntity,
                det.FillQtyUOM,
                det.RecurCode,
                det.WgtUOM,
                det.DimenUOM,
                det.CubeUOM,
                det.StorageType,
                det.NMFCClass,
                det.MateabilityCode
                );


            #endregion

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@asn";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;

            SqlParameter Parameter2 = new SqlParameter();
            Parameter2.ParameterName = "@details";
            Parameter2.SqlDbType = SqlDbType.Structured;
            Parameter2.Value = tbl2;


            cmd.Parameters.Add(Parameter);
            cmd.Parameters.Add(Parameter2);
        }

        void setINVENTORYHOLDParameters(InventoryHold asn, SqlCommand cmd)
        {
            DataTable tbl = new DataTable();
            #region HEADER
            tbl.Columns.Add("ext_udf_str1");
            tbl.Columns.Add("SerialKey");
            tbl.Columns.Add("TransmitLogKey");
            tbl.Columns.Add("AddDate");
            tbl.Columns.Add("Origin");
            tbl.Columns.Add("HoldTrnGroup");
            tbl.Columns.Add("StorerKey");
            tbl.Columns.Add("sku");
            tbl.Columns.Add("Lot");
            tbl.Columns.Add("Loc");
            tbl.Columns.Add("HoldTRNAddDate");
            tbl.Columns.Add("CountSequence");
            tbl.Columns.Add("Comments");
            tbl.Columns.Add("ProdStageLoc");
            tbl.Columns.Add("ALTSKU");
            tbl.Columns.Add("PACKUOM3");
            tbl.Columns.Add("Lottable03");
            tbl.Columns.Add("Lottable04");
            tbl.Columns.Add("HoldCode");
            tbl.Columns.Add("Qty");
            foreach (var row in asn.InventoryHoldHeader.InventoryHoldDetail)
            {
                tbl.Rows.Add(
                asn.InventoryHoldHeader.ext_udf_str1,
                asn.SerialKey,
                asn.TransmitLogKey,
                asn.AddDate,
                asn.InventoryHoldHeader.Origin,
                asn.InventoryHoldHeader.HoldTrnGroup,
                asn.InventoryHoldHeader.StorerKey,
                asn.InventoryHoldHeader.SKU,
                asn.InventoryHoldHeader.Lot,
                asn.InventoryHoldHeader.Loc,
                asn.InventoryHoldHeader.HoldTRNAddDate,
                asn.InventoryHoldHeader.CountSequence,
                asn.InventoryHoldHeader.Comments,
                asn.InventoryHoldHeader.ProdStageLoc,
                asn.InventoryHoldHeader.SkuInfo.ALTSKU,
                asn.InventoryHoldHeader.SkuInfo.PACKUOM3,
                asn.InventoryHoldHeader.LotAttribute.Lottable03,
                asn.InventoryHoldHeader.LotAttribute.Lottable04,
                row.HoldCode,
                row.Qty
                );
            }
            
            #endregion

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@asn";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;
            cmd.Parameters.Add(Parameter);
        }

        private void WriteLog(string StatusCode, string RequestBody, string ResponseBody, string EndPoint)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            DataTable dtDF = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand($"WMS_WRITE_LOG");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("StatusCode", StatusCode);
            cmd.Parameters.AddWithValue("RequestBody", RequestBody);
            cmd.Parameters.AddWithValue("ResponseBody", ResponseBody);
            cmd.Parameters.AddWithValue("EndPoint", EndPoint);
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            Da.Fill(ds);
        }

    }
}











