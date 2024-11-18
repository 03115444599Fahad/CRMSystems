namespace VisaApplicationSystem.Models
{
    public class VisaApplication
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassPortCopy { get; set; }
        public string VisaType { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
