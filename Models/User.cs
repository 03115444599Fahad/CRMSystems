using Microsoft.AspNetCore.Identity;
namespace VisaApplicationSystem.Models
{
    public class User 
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime EntryDate { get; set; }
        public int EnterBy { get; set; }


    }
}
