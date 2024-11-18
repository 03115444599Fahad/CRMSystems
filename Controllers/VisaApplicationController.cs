
using VisaApplicationSystem.Models;
using VisaApplicationSystem.Data;
using VisaApplicationSystem.Models;
using VisaApplicationSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRMSystem.DTOs;
using Microsoft.AspNetCore.Hosting;

namespace VisaApplicationSystem.Controllers
{
   
    public class VisaApplicationController : Controller
    {
        ApplicationDBContext _dbContext;
        IWebHostEnvironment _webHostEnvironment;

        public VisaApplicationController(ApplicationDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           var VisaApplications= _dbContext.VisaApplications.ToList();
            return View(VisaApplications);
        }
        public IActionResult Add(VisaApplicationDTO VisaApplication, IFormFile image)
        {
            try {
                
                VisaApplication visa = new VisaApplication();
                visa = _dbContext.VisaApplications.FirstOrDefault(x=>x.UserName== VisaApplication.UserName && x.Status !="Approved");

                if (visa != null)
                {
                    return Json(new { result = false, message = "VisaApplication "+ VisaApplication.UserName + " already exist" });
                }
                visa = new VisaApplication();
                visa.UserName = VisaApplication.UserName;
                visa.Country = VisaApplication.Country;
                visa.VisaType = VisaApplication.VisaType;
                visa.SubmissionDate = DateTime.Now;
                visa.Status = "Pending";

                // Define the folder path
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(VisaApplication.PassPortCopy.FileName);

                // Full path to save the file
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     VisaApplication.PassPortCopy.CopyTo(stream);
                }


                visa.PassPortCopy ="/Images/"+ fileName;
                var VisaApplications = _dbContext.VisaApplications.Add(visa);
                var result=_dbContext.SaveChanges();
               
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else {
                    return Json(new { result = false, message = "error saving VisaApplication" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }

            
        }
        public IActionResult Update(VisaApplicationDTO VisaApplication)
        {
            try
            {
                
                var visa = _dbContext.VisaApplications.FirstOrDefault(x => x.ID == VisaApplication.ID );

                if (visa == null)
                {
                    return Json(new { result = false, message = "VisaApplication " + VisaApplication.UserName + " does not exist" });
                }
                
                visa.UserName = VisaApplication.UserName;
                visa.Country = VisaApplication.Country;
                visa.VisaType = VisaApplication.VisaType;
                visa.SubmissionDate = DateTime.Now;
                visa.Status = "Pending";

                // Define the folder path
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(VisaApplication.PassPortCopy.FileName);

                // Full path to save the file
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    VisaApplication.PassPortCopy.CopyTo(stream);
                }


                visa.PassPortCopy = "/Images/" + fileName;
                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error updating VisaApplication" });
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

                var VisaApplication = _dbContext.VisaApplications.FirstOrDefault(x => x.ID == ID);
                _dbContext.Entry(VisaApplication).State = EntityState.Deleted;
                var result = _dbContext.SaveChanges();
                if (result > 0)
                {

                    return Json(new { result = true, message = "success" });
                }
                else
                {
                    return Json(new { result = false, message = "error deleting VisaApplication" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = ex.Message });
            }



        }
    }
}
