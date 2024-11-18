
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;
using VisaApplicationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace VisaApplicationSystem.Controllers
{
   
    public class UserController : Controller
    {
        ApplicationDBContext _dbContext;

        public UserController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
           var users= _dbContext.User.Where(x => x.IsActive != false).ToList();
            return View(users);
        }
        public IActionResult Add(User user)
        {
            try {
                user.EntryDate = DateTime.Now;
                user.IsActive = true;
                user.Email = user.Email.ToLower();
                var existingUser= _dbContext.User.FirstOrDefault(x=>x.Email== user.Email && x.IsActive == true);
                if (existingUser != null)
                {
                    return Json(new { result = false, message = "User "+ user.Email + " already exist" });
                }
                var users = _dbContext.User.Add(user);
                var result=_dbContext.SaveChanges();
               
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else {
                    return Json(new { result = false, message = "error saving user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }

            
        }
        public IActionResult Update(User user)
        {
            try
            {
                user.EntryDate = DateTime.Now;
                user.IsActive = true;
                var users = _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error updating user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }


            
        }
        public IActionResult Delete(int ID)
        {
            try
            {

                var user = _dbContext.User.FirstOrDefault(x => x.ID == ID);
                user.IsActive = false; 

                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error updating user" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }



        }
    }
}
