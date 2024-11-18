namespace CRMSystem.DTOs
{
    public class VisaApplicationDTO
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public IFormFile PassPortCopy { get; set; }
        public string VisaType { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
   
}
