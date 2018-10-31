using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForMySQLdb.Models;
using WebApplicationForMySQLdb.Services;

namespace WebApplicationForMySQLdb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin" )]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EmailSender()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EmailSender2(string email, string subject, string message)
        {
            _emailSender.SendEmailAsync(email,subject,message);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
