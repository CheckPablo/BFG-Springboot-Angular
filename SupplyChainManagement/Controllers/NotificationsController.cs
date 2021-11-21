using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services;

namespace SupplyChainManagement.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IEmailSender _emailSender;
        private IConfiguration _configuration;

        private readonly UserManager<IdentityUser> _userManager;

        public static string Action;
        public static string From;
        public static string To;
        public static string Comment;
        public static DateTime DateCreated;
      
        // GET: NotificationsController

        public NotificationsController(RepositoryContext context, IEmailSender emailSender, IConfiguration iConfig, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _configuration = iConfig;
            _userManager = userManager;
            //ViewData["MessageCount"] = 1;

        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: NotificationsController/Details/5
        public ActionResult ReadNotifications(int? notificationId)
        {
            //place read noitfication value here
            // and return a list of where read = false
            
            var ViewNotification = _context.Notification.FirstOrDefault(x => x.NotificationId == notificationId);
            //Action = ViewNotification.;
            //From = ViewNotification.To;
            //Comment = ViewNotification.Comment;
            //DateCreated = ViewNotification.DateCreated; 
            //var check = ViewNotification.From;
            ViewData["notificationMessage"] = ViewNotification;
            return View(ViewNotification);
        }

        [HttpGet]
        public async Task<IActionResult> SubmitRequisition(int? id, string action, string comment)
        {

            if (id == null)
            {

                return NotFound();
            }

            var requisition = await _context.Requisition.FindAsync(id);
            if (requisition == null)
            {
                return NotFound();
            }

            return (await SubmitUserRequisition(id, action, comment));
        }

        [HttpPost]
        public async Task<IActionResult> SubmitUserRequisition(int? id, string action, string comment)
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            string email = identityUser.Email;
            var requisition = _context.Requisition.Where(r => r.RequisitionId.Equals(id)).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (requisition.RequisitionId > 0)
                {
                    var notification = new Notification();
                    notification.RequisitionId = requisition.RequisitionId;
                    notification.DateCreated = DateTime.Now;
                    notification.From = email;
                    notification.To = "tinashe@qisolutions.co.za";
                    notification.Action = action;
                    notification.Comment = comment;
                    notification.Link = _configuration.GetValue<string>("RequisitionSettings:RedirectLink").Replace("{RequisitionId}", $"{id}");
                    notification.Message = "New requisition has been created:" + " " + notification.Link;
                    notification.IsRead.Equals(false);

                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                    var rng = new Random();
                    SmtpClient client = new SmtpClient("smtp.office365.com")
                    {
                        //Port = 587, //outlook port 587
                        //Port = 587,
                        Port = 25,
                        EnableSsl = true,
                        //UseDefaultCredentials
                        UseDefaultCredentials = false,
                        TargetName = "STARTTLS/smtp.office365.com",
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        //Credentials = new NetworkCredential("tinashe@qisolutions.co.za","H#.VZlFCj$=c"),
                        Credentials = new NetworkCredential("thandeka@qisolutions.co.za", "MissT@2021!"),
                    };

                    MailMessage message = new MailMessage()
                    {
                        //From = new MailAddress(SubmissionNotfication.From), 
                        // From = new MailAddress("tinashe@qisolutions.co.za"),
                        From = new MailAddress("thandeka@qisolutions.co.za"),
                        //2.The authentication email address is the same as the emails "From" address.
                        Subject = "New Requisition",
                        Body = "New requisition has been created:" + " " + requisition.RequisitionNo,
                        IsBodyHtml = true,
                    };

                    message.To.Add("tinashe@qisolutions.co.za");
                    //message.CC.Add(SubmissionNotfication.Cc);
                    //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                    //message.Attachments.Add(attachment);
                    client.Send(message);
                }
                //var message = new Message(new string[] { notification.To }, "New Requisition", "New requisition has been created:" + " " + requisition.RequisitionNo, null);
                //    await _emailSender.SendEmailAsync(message);
               // }


            }
            return View();
        }

        // GET: NotificationsController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return (await Edit(id, notification));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                notification.IsRead = true;
                _context.Update(notification);
                await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));
            }
            return View(notification);
        }

        // GET: NotificationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
