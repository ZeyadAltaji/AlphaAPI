namespace AlphaAPI.Models
{
    public class compConnection
    {
        public string compNo { get; set; }
        public string adunit { get; set; }
        public string image { get; set; }
        public string company { get; set; }
        public string myURL { get; set; }
        public string myProtocol { get; set; }
        public string shortcut { get; set; }
        public int maxUsers { get; set; }
    }
    public class compUser
    {
        public string compNo { get; set; }
        public string deviceID { get; set; }
        public string deviceMODEL { get; set; }
        public string deviceManufacturer { get; set; }
        public string myIP { get; set; }
        public string fingerprint { get; set; }
    }
}
