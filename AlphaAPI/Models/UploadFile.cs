namespace AlphaAPI.Models
{
    public class UploadFile
    {
      
        public int EmpID { set; get; }
       
        public byte[] File { set; get; }
       
        public string ContentType { get; set; }
     
        public string FileName { get; set; }
       
        public int? FileSize { get; set; }

    }
}