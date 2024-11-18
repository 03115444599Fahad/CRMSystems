using VisaApplicationSystem.DTOs;
using VisaApplicationSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace VisaApplicationSystem.Controllers
{
    
    
    public class AccountController : Controller
    {
        ApplicationDBContext _dbContext;
        public AccountController(ApplicationDBContext dBContext )
        {
            _dbContext=dBContext;
        }
      
        public IActionResult Index()
        {
            return View ();
        }
        public IActionResult Login(LoginDT  login)
        {
            try { 
            
           var user= _dbContext.User.FirstOrDefault(x=>x.Email==login.Email&&x.Password==login.Password);

            if (user!=null) 
            {
                    HttpContext.Session.SetString("UserID", user.ID.ToString());
                    HttpContext.Session.SetString("FirstName", user.FirstName);
                    HttpContext.Session.SetString("LastName", user.LastName);
                    return Json(new { result = true, message = "success" });
            }
            else
            {
                return Json(new { result = true, message = "Invalid username or password" });
            }
            }
            catch (Exception ex) 
            {
                return Json(new { result = true, message = ex.Message });
            }
           
        }
    }
}
