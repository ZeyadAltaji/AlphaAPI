namespace AlphaAPI.Models
{

    public class _general
    {
        public short CompNo { get; set; }
        public int ID { get; set; }
        public int RequestType { get; set; }
        public string Reject { get; set; }
        public int EmpNo { get; set; }
    }

    public class menu
    {
        public int id { get; set; }
        public string descr { get; set; }
    }

    public class submenu
    {
        public int id { get; set; }
        public int id2 { get; set; }
        public int disabled { get; set; }
        public string descr { get; set; }
        public string link { get; set; }
        public string color { get; set; }
        public string img { get; set; }
    }

    public class def
    {
        public int parID { get; set; }
        public double parValue { get; set; }
        public string parNameAr { get; set; }
        public string par_NameEn { get; set; }
        public double Value { get; set; }
    }

}