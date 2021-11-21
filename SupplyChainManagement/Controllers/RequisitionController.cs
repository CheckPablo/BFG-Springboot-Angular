using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contract;
using Services;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Collections.Generic;
//using Microsoft.Exchange.WebServices.Data;
using Attachment = Entities.Models.Attachment;
using Microsoft;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using SupplyChainManagement.Data;
using System.Security.Claims;
//using Microsoft.Extensions;
namespace SupplyChainManagement.Controllers
{
    public class RequisitionController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly ApplicationDbContext _userContext; 
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        private IConfiguration _configuration;
        //private IConfiguration configuration;
        private readonly UserManager<IdentityUser> _userManager;



        public RequisitionController(ApplicationDbContext userContext, RepositoryContext context, IEmailSender emailSender, IRepositoryWrapper repositoryWrapper, IWebHostEnvironment IWebHostEnvironment,UserManager<IdentityUser> userManager ,  IConfiguration iConfig)
        {
            _context = context;
            _userContext = userContext;
            _emailSender = emailSender;
            _repositoryWrapper = repositoryWrapper;
            _env = IWebHostEnvironment;
            _userManager = userManager;
            _configuration = iConfig;

        }


        // GET: Requisitions
        //[Authorize(Roles = "Manager,CFO,CEO")]
        public async Task<IActionResult> Index()
        {
            var requisitions = _repositoryWrapper.Requisition.GetAllNewRequisitions();
                IdentityUser identityUser = await _userManager.GetUserAsync(User);
                string email = identityUser.
                string email = identityUser.Email;
                string email = identityUser.Email;
 
                 return View(await requisitions);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllInprogressRequisitions()
        {
            if (User.IsInRole("CEO") || User.IsInRole("Manager") || User.IsInRole("CFO"))
            {
                var requisitions = _repositoryWrapper.Requisition.GetAllInprogressRequisitions();
                return View(await requisitions);
            }
            else
            {
                return RedirectToAction("GetUserInprogressRequisition", "Requisition");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllApprovedRequisitions()
        {
            if (User.IsInRole("CEO") || User.IsInRole("Manager") || User.IsInRole("CFO"))
            {
                var requisitions = _repositoryWrapper.Requisition.GetAllApprovedRequisitions();
                return View(await requisitions);
            }
            else
            {
                return RedirectToAction("GetUserApprovedREquisition", "Requisition");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDeclinedRequisitions()
        {
            var requisitions = _repositoryWrapper.Requisition.GetAllDeclinedRequisitions();
            return View(await requisitions);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllDeclinedRequisition()
        {
            
            if (User.IsInRole("CEO") || User.IsInRole("Manager") || User.IsInRole("CFO"))
            {
                return RedirectToAction("GetDeclinedRequisitions", "Requisition");
            }
            else
            {
                return RedirectToAction("GetUserDeclinedRequisition", "Requisition");
            }

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserSavedRequisitions()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
         

            string email = identityUser.Email;
            var requisitions = _context.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Include(r => r.ContractType)
                                                            .Include(r => r.City)
                                                            .Include(r => r.DemandPlan)
                                                            .Include(r => r.Commodity)
                                                            .Where(r => r.QueriesEmail.Equals(email) && r.IsComplete.Equals(false));

            return View(requisitions);


        }

        public async Task<IActionResult> GetUserInprogressRequisition()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string email = identityUser.Email;
            var requisitions = _context.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Include(r => r.ContractType)
                                                            .Include(r => r.City)
                                                            .Include(r => r.DemandPlan)
                                                            .Include(r => r.Commodity)
                                                            .Where(r => r.QueriesEmail.Equals(email) && r.Status.Equals("Inprogress"));
            return View(requisitions);

        }


        public async Task<IActionResult> GetUserDeclinedRequisition()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string email = identityUser.Email;

            {
                var requisitions = _context.Requisition.Include(r => r.Department)
                                                                .Include(r => r.ShippingMethod)
                                                                .Include(r => r.RequisitionType)
                                                                .Include(r => r.ContractType)
                                                                .Include(r => r.City)
                                                                .Include(r => r.DemandPlan)
                                                                .Include(r => r.Commodity)
                                                                .Where(r => r.QueriesEmail.Equals(email) && r.Status.Equals("Declined"));
                return View(requisitions);
            }

        }

        public async Task<IActionResult> GetUserApprovedRequisition()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string email = identityUser.Email;
            var requisitions = _context.Requisition.Include(r => r.Department)
                                                            .Include(r => r.ShippingMethod)
                                                            .Include(r => r.RequisitionType)
                                                            .Include(r => r.ContractType)
                                                            .Include(r => r.City)
                                                            .Include(r => r.DemandPlan)
                                                            .Include(r => r.Commodity)
                                                            .Where(r => r.QueriesEmail.Equals(email) && r.Status.Equals("Approved"));
            return View(requisitions);

        }

        [HttpPost]
        public IActionResult SearchRequisition(IFormCollection Form)
        {
            ViewBag.Name = Form["reqNumber"];
            var reqNumber = ViewBag.Name;
            Guid RequisitionNo = Guid.Parse(reqNumber);
            var requisition = _context.Requisition.Where(r => r.RequisitionNo.Equals(RequisitionNo)).SingleOrDefault();

            return View(requisition);

        }

        // GET: Requisitions/Details/5
        public async Task<IActionResult> Details(int? RequisitionId)
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string email = identityUser.Email;
            if (RequisitionId == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisition.Where(r => r.RequisitionId.Equals(RequisitionId))
                .Include(r => r.ContractType)
                .Include(r => r.Department)
                .Include(r => r.RequisitionType)
                .Include(r => r.ShippingMethod)
                .Include(r => r.DemandPlan)
                .Include(r => r.City)
                .Include(r => r.Commodity)
                .Include(r => r.Classification)
                .FirstOrDefaultAsync(m => m.RequisitionId == RequisitionId);
            // the ideal approach here is to have a steps table with a processid indicating requistion, qoutation, tender etc...and the corresponding step(entered on submission/post)

                var lineManagerStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("line")).FirstOrDefault();//and does not include finance step1( sent to line Manager);
                var financeStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("finance")).FirstOrDefault();// not supplychain, step2 (sent to finance);
                var SupplyChainStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("SupplyChain")).FirstOrDefault();// not rfq or supplier step 3 (RFQ Sent)
                var RFQSentStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("suppliersmail")).FirstOrDefault();// RFQ Sent but no response yet(suppliers mail)
                var RFQResponseStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.From.Contains("suppliersmail")).FirstOrDefault();// supplier (qoute received by suplychain)


                //var lineManagerStep = _context.Requisition.Where(s => s.RequisitionId == RequisitionId && s.Status.Contains("New")).FirstOrDefault();//and does not include finance step1( sent to line Manager);
                //var financeStep = _context.Requisition.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("finance")).FirstOrDefault();// not supplychain, step2 (sent to finance);
                //var SupplyChainStep = _context.Requisition.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("SupplyChain")).FirstOrDefault();// not rfq or supplier step 3 (RFQ Sent)
                //var RFQSentStep = _context.Requisition.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("suppliersmail")).FirstOrDefault();// RFQ Sent but no response yet(suppliers mail)
                //var RFQResponseStep = _context.Requisition.Where(s => s.RequisitionId == RequisitionId && s.From.Contains("suppliersmail")).FirstOrDefault();// supplier (qoute received by suplychain)
                                                                                                                                                          //var QouteReview = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("Quote Review"))// supplier (qoute receivewed by Supplychain and finance internally not in syste) and no PO

            //if(QouteReview.Count() > 1)
            //{

            //}

            var PurchaseOrderSent = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("Purchase Order")).FirstOrDefault(); // supplier (purchase order sent)

                // payment is somewhere here
                var InvoiceReceived = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("Invoice Received")).FirstOrDefault(); ;// supplier (invoice recieved)
                var goodsReceived = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("Goods received")).FirstOrDefault(); ;// supplier (purchase order sent)
             
                if (lineManagerStep!= null)
                {
                    ViewData["lineManagerStep"] = lineManagerStep;
                }


                if (financeStep != null)
                {
                 ViewData["financeStep"] = financeStep;
                }

            if (SupplyChainStep!= null)
            {
                ViewData["SupplyChainStep"] = SupplyChainStep;
            }


            if (RFQSentStep != null)
            {
                ViewData["RFQSentStep"] = RFQSentStep;
            }


            if (RFQResponseStep != null)
            {
                ViewData["RFQResponseStep"] = RFQResponseStep;
            }


            if (PurchaseOrderSent != null)
            {
                ViewData["PurchaseOrderSent"] = PurchaseOrderSent;
            }

    
            if (InvoiceReceived != null)
            {
                ViewData["InvoiceReceived"] = InvoiceReceived;
            }

            // checkSteps(RequisitionId);

            if (requisition == null)
                {
                 return NotFound();  //LINK SUPLIER SEARCH WITH SUPPLY CHAIN NOTIFICATION EMAIL
                }
            //if(re)
            //var notification = _context.Notification.Where(n => n.RequisitionId.Equals(requisition.RequisitionId) && n.To.Equals(email)).SingleOrDefault();

            //notification.IsRead = true;
            await _context.SaveChangesAsync();

            return View(requisition);
        }

        //public void checkSteps(int? requisitionIdStep)
        //{
        //    var lineManagerStep = _context.Notification.Where(s => s.RequisitionId == RequisitionId && s.To.Contains("line"))
        //}

        [HttpGet]
        public async Task<IActionResult> SavedRequisitionDetails(int? RequisitionId)
        {
            if (RequisitionId == null)
            {
                return NotFound();
            }

            var requisition = await _context.Requisition.Where(r => r.RequisitionId.Equals(RequisitionId))
                .Include(r => r.ContractType)
                .Include(r => r.Department)
                .Include(r => r.RequisitionType)
                .Include(r => r.ShippingMethod)
                .Include(r => r.DemandPlan)
                .Include(r => r.City)
                .Include(r => r.Commodity)
                .Include(r => r.Classification)
                .FirstOrDefaultAsync(m => m.RequisitionId == RequisitionId);
            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);

        }

        [HttpGet]
        public IActionResult GetSavedRequisition()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetSavedRequisition(Guid RequisitionNo)
        {
            var requisition = _context.Requisition.Where(r => r.RequisitionNo.Equals(RequisitionNo) && r.RequisitionId > 0).SingleOrDefault();
            if (requisition == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId");
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
            ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description");
            ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description");
            ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description");
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description");

            return View("Edit", requisition);
        }

        // GET: Requisitions/Create
        public IActionResult Create()
        {

            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName");
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
            ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description");
            ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description");
            ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description");
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string action, Requisition requisition)
        {
            var supplier = _userContext.i
               .Include(s => s.City)
               .Include(s => s.Classification)
               .Include(s => s.Country)
               .Include(s => s.Municipality)
               .Include(s => s.PaymentMethod)
               .Include(s => s.Province)
               .Include(s => s.Ward)
               .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            if (quotation == null)
            {
                return NotFound();
            }
            if (action == "Save")
            {
                requisition.QueriesEmail = User.Identity.Name;
                return (await SaveAsync(requisition));
            }
            else if (action == "Submit")
            {
                requisition.QueriesEmail = User.Identity.Name;
                return (await SubmitAsync(requisition));
            }

            else
            {
                return RedirectToAction("Index", "Dashboard");
            }

        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveAsync([Bind("RequisitionId,RequisitionNo,RequisitionTitle,RequisitionTypeId,DepartmentId,ContractTypeId,ShippingMethodId,Motivation,QueriesName,QueriesPhone,QueriesEmail,DateCreated,CreatedBy,SiteVisitRequired,AttachmentPath,AttachmentDescription,OverwriteExistingAttachment,AttachmentVisibleToSupplier,ApprovalException,IsComplete,ClassificationId,ServiceItem,CommodityId,Item,UnitOfMeasure,Glaccount,ItemDescription,DetailedDescription,UnitPrice,Quantity,SubTotal,Vattotal,Total,RequestedBy,ExpectedDate,CityId,DeliveryAddress,DemandPlanId,Status,Reason")] Requisition requisition)
        {
            string uniqueFileName = null;
            string filePath = null;
            string sendToEmail = requisition.QueriesEmail; 

            if (ModelState.IsValid)
            {
                if (requisition.RequisitionNo == Guid.Empty)
                {
                    requisition.RequisitionNo = Guid.NewGuid();
                }

                if (requisition.FormFile != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + requisition.FormFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    requisition.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (filePath != null || filePath == "")
                { 
                   requisition.AttachmentPath = filePath;
                }
                requisition.IsComplete = false;
                requisition.DateCreated = DateTime.Now;
                requisition.Status = "Incomplete";
                _context.Add(requisition);
                await _context.SaveChangesAsync();
                var rng = new Random();

                //var message = new Message(new string[] { requisition.QueriesEmail }, "Requisition Number", "Your requisition number is :" + requisition.RequisitionNo, null);
                //await _emailSender.SendEmailAsync(message);
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    //Port = 587, //outlook port 587
                    Port = 25,
                    EnableSsl = true,
                    //UseDefaultCredentials
                    UseDefaultCredentials = false,
                    TargetName = "STARTTLS/smtp.office365.com",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //Credentials = new NetworkCredential("tinashe@qisolutions.co.za","H#.VZlFCj$=c"),
                    Credentials = new NetworkCredential("syntaxdon@gmail.com", "an562727"),
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

                //message.To.Add("scmfinance@yahoo.com");
                message.To.Add(sendToEmail);
                //message.CC.Add(SubmissionNotfication.Cc);
                //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                //message.Attachments.Add(attachment);
                client.Send(message);
                // save attachment detail
                if (filePath != null || filePath == "")
                { 
                    var fileattachment = new Attachment(); 
                    //fileattachment.DocumentPath = filePath;
                    fileattachment.DocumentPath = Path.GetFileName(filePath);
                    fileattachment.CreateDate = DateTime.Now;
                    fileattachment.UpdateDate = DateTime.Now;
                    fileattachment.ProcessTypeId = 1;
                    fileattachment.DocumentName = "Document name";
                    fileattachment.Description = "description";
                    fileattachment.Extension = "docx";
                    _context.Add(fileattachment);
                    await _context.SaveChangesAsync();
               }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId");
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
            ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description");
            ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description");
            ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description");
            ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description");
            return View(requisition);
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

            [HttpPost]
            public async Task<IActionResult> SubmitAsync([Bind("RequisitionId,RequisitionNo,RequisitionTitle,RequisitionTypeId,DepartmentId,ContractTypeId,ShippingMethodId,Motivation,QueriesName,QueriesPhone,QueriesEmail,DateCreated,CreatedBy,SiteVisitRequired,AttachmentPath,AttachmentDescription,OverwriteExistingAttachment,AttachmentVisibleToSupplier,ApprovalException,IsComplete,ClassificationId,ServiceItem,CommodityId,Item,UnitOfMeasure,Glaccount,ItemDescription,DetailedDescription,UnitPrice,Quantity,SubTotal,Vattotal,Total,RequestedBy,ExpectedDate,CityId,DeliveryAddress,DemandPlanId, FormFile")] Requisition requisition)
        //var email = new MimeMessage();
        //email.From.Add(MailboxAddress.Parse("from_address@example.com"));
        //email.To.Add(MailboxAddress.Parse("to_address@example.com"));
        //email.Subject = "Test Email Subject";
        //email.Body = new TextPart(TextFormat.Plain) { Text = "Example Plain Text Message Body" };

        //// send email
        //using var smtp = new SmtpClient();
        //    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        //smtp.Authenticate("[USERNAME]", "[PASSWORD]");
        //smtp.Send(email);
        //smtp.Disconnect(true);

        {
            string uniqueFileName = null;
            string filePath = null;



            if (ModelState.IsValid)
            {

                if (requisition.RequisitionNo == null)
                {
                    requisition.RequisitionNo = Guid.NewGuid();

                }
                else if (requisition.RequisitionNo == Guid.Empty)
                {
                    requisition.RequisitionNo = Guid.NewGuid();

                }
                else
                {
                    await EditRequisition(requisition.RequisitionId, requisition);

                }


                if (requisition.FormFile != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
                    //uniqueFileName = Guid.NewGuid().ToString() + "_" + requisition.FormFile.FileName;
                    uniqueFileName = requisition.FormFile.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //use using so stream can auto dispose
                    requisition.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                if (filePath != null || filePath == "")
                { 
                   requisition.AttachmentPath = filePath;
                 }
                requisition.Status = "New";
                requisition.IsComplete = true;
                requisition.DateCreated = DateTime.Now;
                _context.Add(requisition);
                await _context.SaveChangesAsync();
          
                if(requisition.RequisitionId > 0)
                {

                    var emailLink =
                   _configuration
                  .GetValue<string>("QuotationSettings:RedirectLink")
                  .Replace("{RequisitionId}", $"{requisition.RequisitionId}");
                  //.Replace("{SupplierId}", $"{SupplierId}");

                    var SubmissionNotfication = new Notification();
                    SubmissionNotfication.RequisitionId = requisition.RequisitionId;
                    SubmissionNotfication.To = "scmlinemanager@yahoo.com";
                    SubmissionNotfication.From = requisition.QueriesEmail;
                    SubmissionNotfication.Cc = requisition.QueriesEmail;
                    SubmissionNotfication.Action = "Succesful Submission"; 
                    SubmissionNotfication.Comment = "";
                    // SubmissionNotfication.Message = "new requisition submition. Req No:" +""+ requisition.RequisitionId;""+"" +"<p>please click on the link to view" + "</p>" + "<p>Please use the URL link below to view the link<br/>" + "< ahref = '" + "https://localhost:44334/Requisition/Details?RequisitionId="' > +"" + requisitionId +

                    SubmissionNotfication.Message = " New Requisition Submission.Req No:" + "" + requisition.RequisitionId + "</b>" + "please click on the link to view" + "<a href='" + emailLink + "' </a>";
                    SubmissionNotfication.IsRead.Equals(false);
                    //SubmissionNotfication.Link = ReqSubmission;
                    SubmissionNotfication.Link = "https://localhost:44334/Requisition/Details?RequisitionId=" + "" + requisition.RequisitionId; 
                    SubmissionNotfication.DateCreated = DateTime.Now;
                    _context.Add(SubmissionNotfication);
                    await _context.SaveChangesAsync();

                    //var rng = new Random();
                    //var message = new Message(new string[] { SubmissionNotfication.To }, "New Requisition", "New requisition has been created:" + " " + requisition.RequisitionNo, null);
                    //await _emailSender.SendEmailAsync(message);


                    //var service = new ExchangeService(ExchangeVersion.Exchange2013);
                    //service.Credentials =
                    //    new WebCredentials("tinashe@qisolutions.co.za", "H#.VZlFCj$=c");
                    //service.TraceEnabled = true;
                    //service.TraceFlags = TraceFlags.All;
                    //service.AutodiscoverUrl("tinashe@qisolutions.co.za",RedirectionUrlValidationCallback);
                    //EmailMessage email = new EmailMessage(service);
                    //email.ToRecipients.Add(SubmissionNotfication.To);
                    //email.Subject = "New Requisition";
                    //email.Body = new MessageBody("New requisition has been created:" + " " + requisition.RequisitionNo);
                    //email.Body.BodyType = BodyType.HTML;
                    //email.Attachments.AddFileAttachment(filePath);
                    //email.Send();

                    //SmtpClient client = new SmtpClient("smtp.office365.com")
                    //{
                    //    //Port = 587, //outlook port 587
                    //    Port = 587,
                    //    //Port = 25,
                    //    EnableSsl = true,
                    //    //UseDefaultCredentials
                    //    UseDefaultCredentials =false,
                    //    TargetName = "STARTTLS/smtp.office365.com",
                    //    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //    //Credentials = new NetworkCredential("tinashe@qisolutions.co.za","H#.VZlFCj$=c"),
                    //    Credentials = new NetworkCredential("support@qisolutions.co.za", "H#.VZlFCj$=c"),
                    //    // Credentials = new NetworkCredential("tinashe@qisolutions.co.za", "Jchrist101"),
                    //    // Credentials = new NetworkCredential("thandeka@qisolutions.co.za", "MissT@2021!"),
                    //    // Credentials = new NetworkCredential("thandeka@qisolutions.co.za", "MissT@2021!"),
                    //    //Host = "smtp-mail.outlook.com",
                    //};

                    //MailMessage message = new MailMessage()
                    //{
                    //    //From = new MailAddress(SubmissionNotfication.From), 
                    //    From = new MailAddress("tinashe@qisolutions.co.za"),
                    //   // From = new MailAddress("thandeka@qisolutions.co.za"),
                    //    //2.The authentication email address is the same as the emails "From" address.
                    //    Subject = "New Requisition",
                    //    //Body = "New requisition has been created:" + " " + requisition.RequisitionNo,
                    //    Body = " New Requisition Submission.Req No:" + "" + requisition.RequisitionId + "</b>" + "please click on the link to view" + "" + requisition.RequisitionId,
                    //IsBodyHtml = true,
                    //};

                    //message.To.Add(SubmissionNotfication.To);
                    ////message.CC.Add(SubmissionNotfication.Cc);
                    ////var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                    ////message.Attachments.Add(attachment);
                    //client.Send(message);
                }
            

                // save attachment detail
                if (filePath != null || filePath == "")
                { 
                    var fileattachment = new Attachment();
                    fileattachment.DocumentPath = Path.GetFileName(filePath);
                    fileattachment.CreateDate = DateTime.Now;
                    fileattachment.UpdateDate = DateTime.Now;
                    fileattachment.ProcessTypeId = 1;
                    fileattachment.DocumentName = "Document name";
                    fileattachment.Description = "description";
                    fileattachment.Extension = "docx";
                    _context.Add(fileattachment);
                    await _context.SaveChangesAsync();
               }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId");
                ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
                ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description");
                ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description");
                ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item");
                ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
                ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description");
                ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description");
                return View(requisition);
            }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            //var redirectionUri = new Uri(redirectionUrl);
            var redirectionUri = new Uri("https://outlook.office365.com/EWS/Exchange.asmx"); 
            var result = redirectionUri.Scheme == "https";
            return result;
        }

        public async Task<IActionResult> Edit(int? id)
        {
                IdentityUser identityUser = await _userManager.GetUserAsync(User);
                string email = identityUser.Email;

                if (id == null)
                {
                    return NotFound();
                }

                var requisition = await _context.Requisition.FindAsync(id);
                if (requisition == null)
                {
                    return NotFound();
                }
                var notification = _context.Notification.Where(n => n.RequisitionId.Equals(requisition.RequisitionId) && n.To.Equals(email)).SingleOrDefault();
                if(notification != null)
                {
                notification.IsRead = true;
                }
                
                await _context.SaveChangesAsync();
                ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName", requisition.CityId);
                ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description", requisition.ClassificationId);
                ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description", requisition.CommodityId);
                ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description", requisition.ContractTypeId);
                ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item", requisition.DemandPlanId);
                ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", requisition.DepartmentId);
                ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description", requisition.RequisitionTypeId);
                ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description", requisition.ShippingMethodId);
                return View(requisition);         
        }


            [HttpPost]
            public async Task<IActionResult> Edit(string action, Requisition requisition)
            {
                if (action == "Submit")
                {

                    return (await SubmitAsync(requisition));

                }
                else if (action == "Save")
                {
                    return (await SaveAsync(requisition));
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }

            }

            [HttpGet]
            public async Task<IActionResult> EditRequisition(int? RequisitionId)
            {
                if (RequisitionId == null)
                {
                    return NotFound();
                }

                var requisition = await _context.Requisition.FindAsync(RequisitionId);
                if (requisition == null)
                {
                    return NotFound();
                }
                ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityName", requisition.CityId);
                ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description", requisition.ClassificationId);
                ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description", requisition.CommodityId);
                ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description", requisition.ContractTypeId);
                ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item", requisition.DemandPlanId);
                ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", requisition.DepartmentId);
                ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description", requisition.RequisitionTypeId);
                ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description", requisition.ShippingMethodId);
                return View(requisition);

            }

            [HttpPost]
            public async Task<IActionResult> EditRequisition(int? RequisitionId, [Bind("RequisitionId,RequisitionNo,RequisitionTitle,RequisitionTypeId,ContractTypeId,ApprovalException,ShippingMethodId,Motivation,QueriesName,QueriesPhone,QueriesEmail,DateCreated,CreatedBy,DepartmentId,Status,Reason")] Requisition requisition)
            {
                if (RequisitionId != requisition.RequisitionId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(requisition);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {

                        if (!RequisitionExists(requisition.RequisitionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    //var rng = new Random();
                    //var message = new Message(new string[] { "scmlinemanager@yahoo.com" }, "New Requisition Created", "Requisition Number :" + " " + requisition.RequisitionNo + " " + " has been created", null);
                    //await _emailSender.SendEmailAsync(message);



                    return RedirectToAction(nameof(Index));
                }
                ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId");
                ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
                ViewData["CommodityId"] = new SelectList(_context.Commodity, "CommodityId", "Description");
                ViewData["ContractTypeId"] = new SelectList(_context.ContractType, "ContractTypeId", "Description");
                ViewData["DemandPlanId"] = new SelectList(_context.DemandPlan, "DemandPlanId", "Item");
                ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
                ViewData["RequisitionTypeId"] = new SelectList(_context.RequisitionType, "RequisitionTypeId", "Description");
                ViewData["ShippingMethodId"] = new SelectList(_context.ShippingMethod, "ShippingMethodId", "Description");
                return View(requisition);
            }

            [HttpGet]

        [HttpGet]
        public async Task<IActionResult> ReworkRequisition(int? id)
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReworkRequisition(int? id, string action, string reason)
        {
            if (action == "Rework")
            {
                return await (ReDoRequisition(id, action, reason));


            }
            else
            {
                return RedirectToAction("Details", new { RequisitionId = id });

            }

        }



        [HttpPost]
        public async Task<IActionResult> ReDoRequisition(int? id, string action, string reason)
        {

            string sendToEmail;
            if (ModelState.IsValid)
            {
                var req = _context.Requisition.Where(r => r.RequisitionId.Equals(id)).SingleOrDefault();
                try
                {


                    req.Status = "Incomplete";
                    sendToEmail = req.QueriesEmail;
                    _context.Update(req);
                    await _context.SaveChangesAsync();
                    if (req.RequisitionId > 0)
                    {
                        var notification = new Notification();
                        notification.RequisitionId = req.RequisitionId;
                        notification.To = req.QueriesEmail;
                        notification.From = User.Identity.Name;
                        notification.Comment = reason;
                        notification.Link = _configuration.GetValue<string>("ReqSubmissionSettings:ReqSubmissionLink").Replace("{RequisitionId}", $"{id}");
                        notification.Action = action;
                        notification.Message = "Please click on the link to rework requisition:" + " " + notification.Link;
                        notification.DateCreated = DateTime.Now;
                        _context.Add(notification);
                        await _context.SaveChangesAsync();
                      
                    }

                    //var rng = new Random();
                    //var message = new Message(new string[] { req.QueriesEmail }, "Rework Requisition", "Requisition Number:" + " " + req.RequisitionNo + " " + "needs to be reworked", null);
                    //await _emailSender.SendEmailAsync(message);

                    SmtpClient client = new SmtpClient("smtp.office365.com")
                    {
                        //Port = 587, //outlook port 587
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
                        Body = "Requisition Number:" + " " + req.RequisitionNo + " " + "needs to be reworked",
                        IsBodyHtml = true,
                    };

                    //message.To.Add("scmfinance@yahoo.com");
                    message.To.Add(sendToEmail);
                    //message.CC.Add(SubmissionNotfication.Cc);
                    //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                    //message.Attachments.Add(attachment);
                    client.Send(message);
                    // save attachment detail
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!RequisitionExists(req.RequisitionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View();
        }


        public async Task<IActionResult> ApproveRequisition(int? id, string action, string comment)

        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);
            string email = identityUser.Email;

            var fromAddress = new MailAddress("qiscmapp@gmail.com", "From Name");
            var toAddress = new MailAddress("suppliersmail@yahoo.com", "To Name");
            var notificationLink = ""; ; 
            const string fromPassword = "insyduliawxhesgf";
            const string subject = "Subject";

            var rng = new Random();
            //var message = new Message();

            var requisition = _context.Requisition.Where(r => r.RequisitionId.Equals(id)).SingleOrDefault();

            if (requisition.Status == "New")
            {
                // this means the line manager has approved and needs to send to finance
                requisition.Status = "Inprogress";
                await _context.SaveChangesAsync();
                if (requisition.RequisitionId > 0)
                {
                    var notification = new Notification();
                    notification.RequisitionId = requisition.RequisitionId;
                    notification.To = "scmfinance@yahoo.com";
                    notification.Cc = requisition.QueriesEmail;
                    notification.From = User.Identity.Name;

                    notification.Comment = "Approve";
                    notification.Link = _configuration.GetValue<string>("ReqSubmissionSettings:ReqSubmissionLink").Replace("{RequisitionId}", $"{id}");
                    notificationLink = notification.Link;
                    notification.Action = action;
                    notification.Message = "Approval New requisition has been sent to you" + " " + notification.Link;
                    notification.DateCreated = DateTime.Now;
                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                }

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };


                MailMessage message = new MailMessage()
                {
                    //From = new MailAddress(SubmissionNotfication.From), 
                    // From = new MailAddress("tinashe@qisolutions.co.za"),
                    From = new MailAddress("qiscmapp@gmail.com"),
                    //2.The authentication email address is the same as the emails "From" address.
                    Subject = "New Requisition Approved",
                    Body = requisition.RequisitionNo + " " + "has been sent to you"+""+"</br>" + "Approval New requisition has been sent to you" + " " + notificationLink,


                    IsBodyHtml = true,
                };

                message.To.Add("scmfinance@yahoo.com");
                //message.CC.Add(SubmissionNotfication.Cc);
                //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                //message.Attachments.Add(attachment);
                smtp.Send(message);
            }


            //message = new Message(new string[] { "scmfinance@yahoo.com" }, "New Requisition", "Requisition Number:" + " " + requisition.RequisitionNo + " " + "has been sent to you", null);
            //    await _emailSender.SendEmailAsync(message);

           

            else
            {
                requisition.Status = "Approved";
                await _context.SaveChangesAsync();
                if (requisition.RequisitionId > 0)
                {
                    var notification = new Notification();
                    notification.RequisitionId = requisition.RequisitionId;
                    notification.To = "supplychaindpt@yahoo.com";
                    notification.Cc = requisition.QueriesEmail;
                    notification.From = User.Identity.Name;
                    if (notification.Comment != null)
                    {
                        notification.Comment = comment;
                    }
                    else
                    {
                        notification.Comment = "N/A";
                    }

                    notification.Link = _configuration.GetValue<string>("ReqSubmissionSettings:ReqSubmissionLink").Replace("{RequisitionId}", $"{id}");
                    notification.Action = action;
                    notification.Message = "Requisition approved by Finance Department:" + " " + notification.Link;
                    notification.DateCreated = DateTime.Now;
                    _context.Add(notification);
                    await _context.SaveChangesAsync();
                }
                SmtpClient client = new SmtpClient("smtp.office365.com")
                {
                    //Port = 587, //outlook port 587
                    Port = 25,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    TargetName = "STARTTLS/smtp.office365.com",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //Credentials = new NetworkCredential("tinashe@qisolutions.co.za","H#.VZlFCj$=c"),
                    Credentials = new NetworkCredential("thandeka@qisolutions.co.za", "MissT@2021!"),
                };

                MailMessage message = new MailMessage()
                {
                    From = new MailAddress("thandeka@qisolutions.co.za"),
                    Subject = "New Requisition",
                    Body = "New requisition has been created:" + " " + requisition.RequisitionNo,
                    IsBodyHtml = true,
                };

                message.To.Add("scmfinance@yahoo.com");
                //message.CC.Add(SubmissionNotfication.Cc);
                //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                //message.Attachments.Add(attachment);
                //client.Send(message);
                //message = new Message(new string[] { "supplychaindpt@yahoo.com" }, "Approved Requisition", "Requisition Number:" + " " + requisition.RequisitionNo + " " + "has been approved", null);
            }

            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public async Task<IActionResult> DeclineRequisition(int? id)
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

            return View(requisition);
        }

        [HttpPost]
        public async Task<IActionResult> DeclineRequisition(int? id, string action, string reason)
        {
            if (action == "Submit")
            {
                return await (DeclineUserRequisition(id, action, reason));


            }
            else
            {
                return RedirectToAction("Details", new { RequisitionId = id });

            }

        }
        [HttpPost]
        public async Task<IActionResult> DeclineUserRequisition(int? id, string reason, string action)
        {
            string sendToEmail;
            if (ModelState.IsValid)
            {
                var req = _context.Requisition.Where(r => r.RequisitionId.Equals(id)).SingleOrDefault();
                try
                {

                    req.Reason = reason;
                    req.Status = "Declined";
                    sendToEmail = req.QueriesEmail;
                    _context.Update(req);
                    await _context.SaveChangesAsync();
                    if (req.RequisitionId > 0)
                    {
                        var notification = new Notification();
                        notification.RequisitionId = req.RequisitionId;
                        notification.To = req.QueriesEmail;
                        notification.From = User.Identity.Name;

                        notification.Comment = reason;
                        notification.Link = _configuration.GetValue<string>("ReqSubmissionSettings:ReqSubmissionLink").Replace("{RequisitionId}", $"{id}");
                        notification.Action = action;
                        notification.Message = "Requisition number:" + " " + notification.RequisitionId + " " + "has been declined";
                        _context.Add(notification);
                        await _context.SaveChangesAsync();
                    }
                    //var rng = new Random();
                    //var message = new Message(new string[] { req.QueriesEmail }, "Requisition Declined", "Requisition Number:" + " " + req.RequisitionNo + " " + "has been declined", null);
                    //await _emailSender.SendEmailAsync(message);
                    SmtpClient client = new SmtpClient("smtp.office365.com")
                    {
                        //Port = 587, //outlook port 587
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
                        Body ="Requisition Number:" + " " + req.RequisitionNo + " " + "has been declined",
                        //Body = "New requisition has been created:" + " " + requisition.RequisitionNo,
                        IsBodyHtml = true,
                    };

                    //message.To.Add("scmfinance@yahoo.com");
                    message.To.Add(sendToEmail);
                    //message.CC.Add(SubmissionNotfication.Cc);
                    //var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
                    //message.Attachments.Add(attachment);
                    client.Send(message);


                    //requisition.RequisitionNo + " " + "has been sent to you"
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!RequisitionExists(req.RequisitionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View();
        }

        // GET: Requisitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var requisition = await _context.Requisition
                    .Include(r => r.City)
                    .Include(r => r.Classification)
                    .Include(r => r.Commodity)
                    .Include(r => r.ContractType)
                    .Include(r => r.DemandPlan)
                    .Include(r => r.Department)
                    .Include(r => r.RequisitionType)
                    .Include(r => r.ShippingMethod)
                    .FirstOrDefaultAsync(m => m.RequisitionId == id);
                if (requisition == null)
                {
                    return NotFound();
                }

                return View(requisition);
            }

            // POST: Requisitions/Delete/5
            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var requisition = await _context.Requisition.FindAsync(id);
                _context.Requisition.Remove(requisition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool RequisitionExists(int id)
            {
                return _context.Requisition.Any(e => e.RequisitionId == id);
            }
        }
    }

