namespace AlphaAPI.Models
{
    public class PayCode
    {
        public int ID { get; set; }

        public string MinCode1 { get; set; }

        public int MinCode { get; set; }

        public string CodeDesc { get; set; }

        public string CodeDescEn { get; set; }

        public int lvl { get; set; }

        public int RequestLevel { get; set; }

        public bool DirectManger { get; set; }
    }

    public class Vac
    {
        public decimal openingBal { get; set; }

        public decimal roundedBal { get; set; }

        public decimal dueBal { get; set; }

        public decimal consBal { get; set; }

        public decimal remBal { get; set; }

        public string Vac_EngDesc { get; set; }
        public decimal? Added_Hrs { get; set; }
    }
}