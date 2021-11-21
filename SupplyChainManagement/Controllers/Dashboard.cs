using Entities;
using Entities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SupplyChainManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyChainManagement.Controllers
{
    public class Dashboard : Controller
    {
        private readonly RepositoryContext _context;
        public int messageCount;
        public List<Notification> messageList; 
        // public static int 

        public Dashboard(RepositoryContext context)
        {
            //int messageCount = 0;
            _context = context;
            //Account.
            //ApplicationUser applicationUser = await UserManager.GetUserAsync(User);
            // string userEmail = applicationUser?.Email;
            if (GlobalVariables.currentLoggedInEmail != null)
            { 
                //messageCount = _context.Notification.Where(s => s.To == GlobalVariables.currentLoggedInEmail).Count();
                messageCount = _context.Notification.Where(s => s.To == GlobalVariables.currentLoggedInEmail && s.IsRead.Equals(false) || s.Cc == GlobalVariables.currentLoggedInEmail && s.IsRead.Equals(false)).Count();
            }
            // need to add a boolean in DB for last read message and start the count from there
            //messageList = _context.Notification.ToList().FindAll(x => x.To == GlobalVariables.currentLoggedInEmail && x.DateCreated < DateTime.Now);
            //messageList = _context.Notification.ToList().FindAll(x => x.To == GlobalVariables.currentLoggedInEmail && x.IsRead.Equals(false) || x.Cc == GlobalVariables.currentLoggedInEmail && x.IsRead.Equals(false)).OrderByDescending;
            messageList = _context.Notification.Where(x => x.To == GlobalVariables.currentLoggedInEmail && x.IsRead.Equals(false) || x.Cc == GlobalVariables.currentLoggedInEmail && x.IsRead.Equals(false)).OrderByDescending(x => x.RequisitionId).ToList();
            //OrderByDescending

             GlobalVariables.messageCount = messageCount;
             GlobalVariables.messageList = messageList;

             ViewData["MessageCount"] = messageCount;
             ViewData["MessageList"] = messageList;

        }
        public IActionResult Index()
        {
            ViewData["MessageCount"] = messageCount;
            //ViewData["MessageList"] = GlobalVariables.messageList;
            ViewData["MessageList"] = messageList;

            return View();
        }
    }
}
