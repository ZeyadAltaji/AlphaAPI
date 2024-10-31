
namespace AlphaAPI.Models
{
    public partial class CboLeaveVac
    {
        public short CompNo { get; set; }
        public int Code { get; set; }
        public string Desc = "";
        public string EngDesc = "";
        public bool ForseHeader = false;
        public bool IsWebService = false;
    }

}
