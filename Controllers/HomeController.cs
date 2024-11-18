
using VisaApplicationSystem.Data;
using VisaApplicationSystem.DTOs;
using VisaApplicationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Net.Mail;

namespace VisaApplicationSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDBContext _dbContext;
        private IMemoryCache _memoryCache;
        public HomeController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}