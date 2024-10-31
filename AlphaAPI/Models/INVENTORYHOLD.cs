using System;

namespace AlphaAPI.Models
{
    public class INVHOLD
    {
        public Fieldoverridess fieldOverrides { get; set; }
        public Hrefs[] hrefs { get; set; }
        public string transmitlogkey { get; set; }
        public DateTime adddate { get; set; }
        public string addwho { get; set; }
        public string billingtransmitflag { get; set; }
        public DateTime editdate { get; set; }
        public string editwho { get; set; }
        public string eventcategory { get; set; }
        public int eventfailurecount { get; set; }
        public int eventstatus { get; set; }
        public string key1 { get; set; }
        public string key2 { get; set; }
        public string key3 { get; set; }
        public string key4 { get; set; }
        public string key5 { get; set; }
        public string labortransmitflag { get; set; }
        public string message { get; set; }
        public int serialkey { get; set; }
        public string tablename { get; set; }
        public string tmtransmitflag { get; set; }
        public string transmitbatch { get; set; }
        public string transmitflag { get; set; }
        public string transmitflag2 { get; set; }
        public string transmitflag3 { get; set; }
        public string transmitflag4 { get; set; }
        public string transmitflag5 { get; set; }
        public string transmitflag6 { get; set; }
        public string transmitflag7 { get; set; }
        public string transmitflag8 { get; set; }
        public string transmitflag9 { get; set; }
        public string whseid { get; set; }
        public object jsonMessage { get; set; }
    }

    public class Fieldoverridess
    {
    }

    public class Hrefs
    {
        public string _ref { get; set; }
        public string url { get; set; }
    }


}
