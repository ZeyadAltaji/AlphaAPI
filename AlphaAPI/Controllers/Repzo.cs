using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace AlphaAPI.Controllers
{

    public class Repzo : ControllerBase
    {
        private string dbName
        {
            get =>  Configuration["database"];
        }
        private string sName
        {
            get => Configuration["server"];
        }
        public Repzo()
        {
            connectionstring = string.Format("Server={0};Database={1};User ID=admin;Password=GceSoft01042000", sName, dbName);
        }
        private SqlParameterCollection Parameters = new SqlCommand().Parameters;
        string connectionstring = "";
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
        private string Value(string k) => Configuration[k];
        

        [AllowAnonymous]
        [Route("repzo/SaveInv")]
        public object SaveInv([FromBody] INV inv)
        {

            if (!ModelState.IsValid)
            {
                return Ok(new { error = true, details = UnprocessableEntity(ModelState) });
            }

            InsertData(inv);
            //Parameters.AddWithValue("@Number", Number);
            //DataTable dt = excute("Repzo_Client");
            return Ok(new { data = "Saved" });
        }
        void InsertData(INV inv)
        {
            //foreach (var item in inv.Where(x => x.pharmacy_id.ToUpper() != "NULL"))
            //{
            //    List<Inv> inv0 = new List<Inv>();
            //    inv0.Add(item);
            SqlConnection conn = new SqlConnection(connectionstring);
            DataTable dt = new DataTable();
            SqlDataAdapter Da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("int_Repzo_SaveData");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(HDT(inv));
            cmd.Parameters.Add(DDT(inv));
            cmd.CommandTimeout = 90;
            Da.SelectCommand = cmd;
            Da.Fill(dt);
            //}

        }

        SqlParameter HDT(INV inv)
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
            tbl.Columns.Add("s");

            float t = 0;

            tbl.Rows.Add(
                0,
                inv.total * 0.001,
                inv.subtotal * 0.001,
                inv.status,
                inv.discount_amount * 0.001,
                t,
                inv.createdAt,
                inv.client_code,
                "",
                0
                );

            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@Headers";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;
            return Parameter;
        }

        SqlParameter DDT(INV inv)
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

            if (inv.items != null)
            {
                foreach (var i in inv.items)
                {
                    tbl.Rows.Add(
                      inv.items.IndexOf(i),
                        i.variant.product_name,
                        i.qty,
                        i.discount_value * 0.001,
                        i.variant.product_sku,
                        i.tax.rate,
                        i.price * 0.001,
                        i.deduction * 0.001, // bonus
                        i.line_total * 0.001, // total
                        inv.items.IndexOf(i)
                        );
                }
            }


            SqlParameter Parameter = new SqlParameter();
            Parameter.ParameterName = "@Details";
            Parameter.SqlDbType = SqlDbType.Structured;
            Parameter.Value = tbl;
            return Parameter;
        }
        private DataTable excute(string ProcedureName)
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
            Da.Fill(dt);
            Parameters = new SqlCommand().Parameters;
            return dt;
        }
    }

    public class INV
    {
        [Required]
        public string client_name { get; set; }
        [Required(ErrorMessage = "يجب ادخال هذا الحقل")]
        public long client_code { get; set; }
        public List<string> company_namespace { get; set; }
        public List<object> promotions { get; set; }
        public List<object> priceLists { get; set; }
        public List<object> teams { get; set; }
        public Editor editor { get; set; }
        [Required]
        public string status { get; set; }

        [Required]
        public List<Item> items { get; set; }
     
        [Required]
        [Range(0, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int subtotal { get; set; }
       
        [Required]
        [Range(0, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int discount_amount { get; set; }
       
        [Required]
        [Range(0, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int taxable_subtotal { get; set; }
        
        [Required]
        [Range(0, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int tax_amount { get; set; }
        
        [Required]
        [Range(0, 2147483647, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int total { get; set; }
       
        public int pre_subtotal { get; set; }
        
        public int pre_discount_amount { get; set; }
        
        public int pre_taxable_subtotal { get; set; }
        
        public int pre_tax_amount { get; set; }
        
        public int pre_total { get; set; }
        
        public int return_subtotal { get; set; }
        
        public int return_discount_amount { get; set; }
        
        public int return_taxable_subtotal { get; set; }
        
        public int return_tax_amount { get; set; }
        
        public int return_total { get; set; }
        
        public int deductionRatio { get; set; }
        
        public int deductionFixed { get; set; }
        
        public int totalDeductedTax { get; set; }
        
        public int totalDeduction { get; set; }
        
        public int totalDeductionBeforeTax { get; set; }
        
        public Taxes taxes { get; set; }
        
        public bool overwriteTaxExempt { get; set; }
        
        public bool tax_exempt { get; set; }
        
        public int shipping_price { get; set; }
        
        public int shipping_tax { get; set; }
        
        public int shipping_charge { get; set; }
        
        public int payment_charge { get; set; }
        
        public int total_with_charges { get; set; }
        
        public DateTime createdAt { get; set; }
        
        public DateTime updatedAt { get; set; }
    }

    public class Creator
    {
        public string _id { get; set; }
        public string type { get; set; }
        public string admin { get; set; }
        public string name { get; set; }
    }

    public class Serial_Number
    {
        public string identifier { get; set; }
        public string formatted { get; set; }
        public int count { get; set; }
        public string _id { get; set; }
    }

    public class Editor
    {
        public string _id { get; set; }
        public string type { get; set; }
        public string admin { get; set; }
        public string name { get; set; }
    }

    public class Taxes
    {
        public NoTax NoTax { get; set; }
    }

    public class NoTax
    {
        public string name { get; set; }
        public int rate { get; set; }
        public int total { get; set; }
        public string type { get; set; }
    }

    public class Item
    {
        public bool isAdditional { get; set; }
        
        public Variant variant { get; set; }
     
        [Required]
        public int qty { get; set; }
      
        public Measureunit measureunit { get; set; }
      
        public Tax tax { get; set; }
      
        public int base_unit_qty { get; set; }
       
        public object overwritePrice { get; set; }
        
        [Required]
        public int price { get; set; }
       
        [Required]
        public int discounted_price { get; set; }
      
        [Required]
        public int tax_amount { get; set; }
        [Required]
        public int tax_total { get; set; }
        [Required]
        public int discount_value { get; set; }
        public int gross_value { get; set; }
        public int line_total { get; set; }
        public int total_before_tax { get; set; }
        public int modifiers_total { get; set; }
        public int modifiers_total_before_tax { get; set; }
        public int modifiers_tax_total { get; set; }
        public int tax_total_without_modifiers { get; set; }
        public int line_total_without_modifiers { get; set; }
        public int total_before_tax_without_modifiers { get; set; }
        public int deductionRatio { get; set; }
        public int deductedTax { get; set; }
        public int deduction { get; set; }
        public int deductionBeforeTax { get; set; }
        public int lineTotalAfterDeduction { get; set; }
        public Promotions promotions { get; set; }
        public List<object> used_promotions { get; set; }
        public List<object> general_promotions { get; set; }
        public List<object> applicable_promotions { get; set; }
        public List<object> company_namespace { get; set; }
        public string _id { get; set; }
        public List<object> modifiers_groups { get; set; }
    }

    public class Variant
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string variant_id { get; set; }
        public string variant_name { get; set; }
        public int listed_price { get; set; }
        public string _id { get; set; }
        public string variant_sku { get; set; }
        public string product_sku { get; set; }
        public object variant_barcode { get; set; }
        public string product_barcode { get; set; }
    }

    public class Measureunit
    {
        public object parent { get; set; }
        public string name { get; set; }
        public int factor { get; set; }
        public bool disabled { get; set; }
        public List<string> company_namespace { get; set; }
        public string _id { get; set; }
    }

    public class Tax
    {
        public string name { get; set; }
        public int rate { get; set; }
        public string type { get; set; }
        public bool disabled { get; set; }
        public string _id { get; set; }
    }

    public class Promotions
    {
        public bool isGet { get; set; }
        public int taken { get; set; }
        public int free { get; set; }
        public List<object> bookings { get; set; }
        public bool highlight { get; set; }
    }

}