using System;
using System.Collections.Generic;

namespace AlphaAPI.Models
{
    public class Invoice
    {
        public List<Invo> data { get; set; }
    }
    public class Invo
    {
        public long InvoiceId { get; set; }
        public long InvoiceReference { get; set; }
        public DateTime InvicePaidDate { get; set; }
        public int PaymentType { get; set; }
        public float InvoiceAmount { get; set; }
        public string InstitutionId { get; set; }
        public string TaxNumber { get; set; }
        public string CommercialName { get; set; }
        public string InstitutionName { get; set; }
        public List<InvoiceItems> InvoiceItems { get; set; }
    }
    public class InvoiceItems
    {
        public string ServiceName { get; set; }
        public int Year { get; set;}
        public int? PeriodCode { get; set;}
        public double Amount { get; set;}
        public double Penalty { get; set;}
        public double Value { get; set;}
        public string ServiceType { get; set;}
        public string ReferenceNumber { get; set;}
        public int CountryId { get; set; }
    }
}
