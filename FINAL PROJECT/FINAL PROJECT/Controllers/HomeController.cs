using FINAL_PROJECT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


using System.Net;
using System.Net.Mail;


namespace FINAL_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult ContactForm()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact record)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("stariaasta77@gmail.com", "Complaza Admin")
            };
            mail.To.Add(new MailAddress(record.Email));

            mail.Subject = record.Subject;
            string message = "Hello, " + record.SenderName + "!<br/><br/>" +
                    "Thank you for contacting us. We have recieved your inquiry. <br/>" +
                    "Here are the detailsy: <br/><br/>" +
                    "Contact Number: <strong>" + record.ContactNo + "</strong><br/>" +
                    "Message:<br/><strong>" + record.Message + "</strong><br/><br/>" +
                    "Please wait for our reply and be updated in futher notices. Thank you!";
            mail.Body = message;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            using System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("stariaasta77@gmail.com", "blackclover"),
                EnableSsl = true
            };
            smtp.Send(mail);
            ViewBag.Message = "Inquiry Sent.";
            return View();
        }
    }
}

