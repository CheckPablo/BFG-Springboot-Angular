using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Services;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

//using SearchSortPaging;

namespace SupplyChainManagement.Controllers
{
    public class SupplierController : Controller
    {
        private readonly RepositoryContext _context;
        public static int? CurrentSupplierId;

        public static string  RequisitionItem;
        public static string  ReqItemDescription;
        public static string  ReqSupplierName;
        public static int?    ReqQuantity;
        public static string RFQRequisitionId; 
        private readonly IEmailSender _emailSender;
        private IConfiguration configuration;

        public SupplierController(RepositoryContext context ,IEmailSender emailSender, IConfiguration iConfig)
        {
            _context = context;
            _emailSender = emailSender;
            configuration = iConfig;
            //ViewData["MessageCount"] = 1;

        }

        // GET: Supplier
        public async Task<IActionResult> Index()
        {
          
            var repositoryContext = _context.Supplier.Include(s => s.City).Include(s => s.Classification).Include(s => s.Country).Include(s => s.Municipality).Include(s => s.PaymentMethod).Include(s => s.Province).Include(s => s.Ward);
            return View(await repositoryContext.ToListAsync());
        }

        // GET: Supplier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CurrentSupplierId = id;
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
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

            return View(supplier);
        }

        public async Task<IActionResult> SupplierSearchDetails(int? id)
        {
            CurrentSupplierId = id;
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
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

            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> RequisitionToSupplier(IFormCollection Form)
        {
            ViewBag.Name = Form["reqNumber"];
            RFQRequisitionId = ViewBag.Name; 
            if (CurrentSupplierId == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
                .Include(s => s.City)
                .Include(s => s.Classification)
                .Include(s => s.Country)
                .Include(s => s.Municipality)
                .Include(s => s.PaymentMethod)
                .Include(s => s.Province)
                .Include(s => s.Ward)
                .FirstOrDefaultAsync(m => m.SupplierId == CurrentSupplierId);
            if (supplier == null)
            {
                return NotFound();
            }
            var  reqNumber = ViewBag.Name;
            Guid requisitionNo =  Guid.Parse(reqNumber);
            var repositoryContext = _context.Requisition.ToList().Find(x => x.RequisitionNo == requisitionNo);

            RequisitionItem = repositoryContext.Item;
            ReqItemDescription = repositoryContext.ItemDescription;
            ReqQuantity = repositoryContext.Quantity;


            var supplierDetails = _context.Supplier.ToList().Find(x => x.SupplierId == CurrentSupplierId);

            ReqSupplierName = supplierDetails.SupplierName;
            ViewData["requisitionDetails"] = repositoryContext;
            ViewData["selectedSupplierDetails"] = supplierDetails;
            //ViewData["selectedSupplierDetails"] = new SelectList(supplierDetails, "Id", "Display)
            return View("SupplierSearchDetails");
        }

        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId");
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description");
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId");
            ViewData["MunicipalityId"] = new SelectList(_context.Municipality, "MunicipalityId", "MunicipalityAddress");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "Description");
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceName");
            ViewData["WardId"] = new SelectList(_context.Ward, "WardId", "WardName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("SupplierId,SupplierName,ClassificationId,LegalName,RegistrationNo,Vatregistered,VatregistrationNo,Bbbeeid,Currency,PaymentMethodId,PaymentTermId,StreetName,BuildingName,Surburb,CityId,ProvinceId,MunicipalityId,WardId,PostalCode,CountryId,ContactPersonName,ContactPersonSurname,ContactPersonPosition,ContactPersonTelephone,ContactPersonFax,ContactPersonCell,ContactPersonEmail,QuotationContact")] Supplier supplier)
        {
            //if(supplier.SupplierId ==0)
            //{
            //    await SendRFQEmailAsync();
            //}
            
            if (ModelState.IsValid)
            {
                supplier.BuildingName = "building";
                supplier.ContactPersonCell = "0812344321";
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId", supplier.CityId);
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description", supplier.ClassificationId);
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", supplier.CountryId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipality, "MunicipalityId", "MunicipalityAddress", supplier.MunicipalityId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "Description", supplier.PaymentMethodId);
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceName", supplier.ProvinceId);
            ViewData["WardId"] = new SelectList(_context.Ward, "WardId", "WardName", supplier.WardId);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> SendRFQ(IFormCollection Form)
        {
  

            var supplierDetails = _context.Supplier.ToList().Find(x => x.SupplierId == CurrentSupplierId);
            ViewData["selectedSupplierDetails"] = supplierDetails;
            //ViewBag.Name = Form["quoteReqId"];
            //string TransactionNo = ViewBag.Name;
            string TransactionNo = RFQRequisitionId; 
            ViewData["requisitionNumber"] = Guid.Parse(TransactionNo);
            Guid requisitionNo = Guid.Parse(TransactionNo);
            var repositoryContext = _context.Requisition.ToList().Find(x => x.RequisitionNo == requisitionNo);
           // await SendRFQEmailAsync(Guid.Parse(TransactionNo), supplierDetails.SupplierId);
             SendRFQEmailAsync(Guid.Parse(TransactionNo) , supplierDetails.SupplierId);


            var notification = new Notification();
            notification.RequisitionId = repositoryContext.RequisitionId;
            //notification.To = supplierDetails.ContactPersonEmail;
            notification.To = "suppliersmail@yahoo.com"; 
            notification.Cc = repositoryContext.QueriesEmail;
            notification.From = User.Identity.Name;

            notification.Comment = "Approve";
            notification.Link = "N/A";
            //notification.Link = _configuration.GetValue<string>("ReqSubmissionSettings:ReqSubmissionLink").Replace("{RequisitionId}", $"{id}");
            //notification.Action = action;
            notification.Message = "Requisition approved by Line Manager:" + " " + notification.Link;
            notification.DateCreated = DateTime.Now;
            _context.Add(notification);
            await _context.SaveChangesAsync();

            return View("RFQSentConfirmation");
        }


        [HttpGet]
        [Route("ApplicationVerification")]
        public ActionResult CreateEditQuotations(Guid TransactionNo, int SupplierId)
        {
            //user is directed here via the email link, the create edit view is then displayed
            //https://localhost:44334/Quotations/CreateEditQuotation/?TransactionNo=
    
            return View (); 
        }
        //private async Task SendRFQEmailAsync(Guid TransactionNO , int SupplierId)
        private void SendRFQEmailAsync(Guid TransactionNO, int SupplierId)
        {

            var fromAddress = new MailAddress("qiscmapp@gmail.com", "From Name");
            var toAddress = new MailAddress("suppliersmail@yahoo.com", "To Name");
            const string fromPassword = "insyduliawxhesgf";
            const string subject = "Subject";
            //const string body = "Body";

            var rng = new Random();
           // TransactionNO = TransactionNO.
            var emailLink =
              configuration
                .GetValue<string>("QuotationSettings:RedirectLink")
                .Replace("{TransactionNo}", $"{TransactionNO}")
                .Replace("{SupplierId}", $"{SupplierId}");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            //using (var message = new MailMessage(fromAddress, toAddress)
            MailMessage message = new MailMessage()
            {
                From = new MailAddress("qiscmapp@gmail.com"),
                Subject = subject,
                Body = "<p> Dear" + "  " + ReqSupplierName + ",</ p > "
                    + "<p>Please be advised that the RFQ below has been assigned to you.</p>" +
                      "<p>Item: <b>" + RequisitionItem + "</b>" +
                      "<p>Item Description: <b>" + ReqItemDescription + "</b>" +
                      "<p>Quantity: <b>" + ReqQuantity + "</b>" +
                      "<p><strong>Please use the URL link below for payments</strong><br/>" +
                       "<a href='" + emailLink + "'>Click here to submit quotation details</a></p>" +
                    "<p>Kind regards,<br/>" +
                    "QiSolutions Team</p>",
                IsBodyHtml = true,
            };
            {
                message.To.Add("suppliersmail@yahoo.com");
                smtp.Send(message);
            }


            //MailMessage message = new MailMessage()
            //{
            //    //From = new MailAddress(SubmissionNotfication.From), 
            //    // From = new MailAddress("tinashe@qisolutions.co.za"),
            //    From = new MailAddress("thandeka@qisolutions.co.za"),
            //    //2.The authentication email address is the same as the emails "From" address.
            //    Subject = "Request For Quotation",
            //    Body = "<p> Dear" + "  " + ReqSupplierName + ",</ p > "
            //         + "<p>Please be advised that the RFQ below has been assigned to you.</p>" +
            //           "<p>Item: <b>" + RequisitionItem + "</b>" +
            //           "<p>Item Description: <b>" + ReqItemDescription + "</b>" +
            //           "<p>Quantity: <b>" + ReqQuantity + "</b>" +
            //           "<p><strong>Please use the URL link below for payments</strong><br/>" +
            //            "<a href='" + emailLink + "'>Click here to submit quotation details</a></p>" +
            //         "<p>Kind regards,<br/>" +
            //         "QiSolutions Team</p>",
            //    IsBodyHtml = true,
            //};

            ////message.To.Add("scmfinance@yahoo.com");
            //message.To.Add("suppliersmail@yahoo.com");
            ////message.CC.Add(SubmissionNotfication.Cc);
            ////var attachment = new System.Net.Mail.Attachment(filePath); //Attachment(string fileName, string mediaType) 
            ////message.Attachments.Add(attachment);
            //client.Send(message);

        }   

        [HttpPost]
        public async Task<IActionResult> SearchAsync(IFormCollection Form)
        {
            ViewBag.Name = Form["searchTerm"];
            string searchTerm = ViewBag.Name;
            var repositoryContext = _context.Supplier.Where(x => x.SupplierName.Contains(searchTerm));
            return View(await repositoryContext.ToListAsync());
        }

        // GET: Supplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId", supplier.CityId);
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description", supplier.ClassificationId);
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", supplier.CountryId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipality, "MunicipalityId", "MunicipalityAddress", supplier.MunicipalityId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "Description", supplier.PaymentMethodId);
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceName", supplier.ProvinceId);
            ViewData["WardId"] = new SelectList(_context.Ward, "WardId", "WardName", supplier.WardId);
            return View(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,SupplierName,ClassificationId,LegalName,RegistrationNo,Vatregistered,VatregistrationNo,Bbbeeid,Currency,PaymentMethodId,PaymentTermId,StreetName,BuildingName,Surburb,CityId,ProvinceId,MunicipalityId,WardId,PostalCode,CountryId,ContactPersonName,ContactPersonSurname,ContactPersonPosition,ContactPersonTelephone,ContactPersonFax,ContactPersonCell,ContactPersonEmail,QuotationContact")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.SupplierId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityId", supplier.CityId);
            ViewData["ClassificationId"] = new SelectList(_context.Classification, "ClassificationId", "Description", supplier.ClassificationId);
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "CountryId", supplier.CountryId);
            ViewData["MunicipalityId"] = new SelectList(_context.Municipality, "MunicipalityId", "MunicipalityAddress", supplier.MunicipalityId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "Description", supplier.PaymentMethodId);
            ViewData["ProvinceId"] = new SelectList(_context.Province, "ProvinceId", "ProvinceName", supplier.ProvinceId);
            ViewData["WardId"] = new SelectList(_context.Ward, "WardId", "WardName", supplier.WardId);
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Supplier
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

            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Supplier.Any(e => e.SupplierId == id);
        }
    }
}
