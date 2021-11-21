using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyChainManagement.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
     public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<string> SendEmail(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
          
            try
            { 
                var rng = new Random();
                attachments = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
                var message = new Message();
                {
                    message.To = new List<MailboxAddress>();
                    message.Subject = subject;
                    message.Content = content;
                    message.Attachments = attachments;
                };
                message.To.AddRange(to.Select(x => new MailboxAddress(x)));
                await _emailSender.SendEmailAsync(message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return "Email sent successfully!!";
        }
        }
    }

