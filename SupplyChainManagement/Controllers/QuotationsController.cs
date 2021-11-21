using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Services;
using Contract;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace SupplyChainManagement.Controllers
{
    public class QuotationsController : Controller
    {
        private readonly RepositoryContext _context;
        //private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _env;
        public static int? CurrentSupplierId;
        public static string RequisitionItem;
        public static string ReqItemDescription;
        public static string ReqSupplierName;
        public static int? ReqQuantity;

        public QuotationsController(RepositoryContext context, IWebHostEnvironment IWebHostEnvironment, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
            //_repositoryWrapper = _repositoryWrapper;
            _env = IWebHostEnvironment;
        }

        // GET: Quotations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quotation.ToListAsync());
        }

        // GET: Quotations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation
                .FirstOrDefaultAsync(m => m.QuotationId == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }

        // GET: Quotations/Create
        //public IActionResult Create()
        //{
        //    return View();

        //}

        [HttpPost]
        public IActionResult SearchRequisition(IFormCollection Form)
        {

            return View("CreateEditQuotations");
        }


        public async Task<IActionResult> Create([Bind("QuotationId,SupplierId,RequisitionId,Item,ItemDescription,Quantity,UnitPrice,Total,BillToAddress,BillToName,DateCreated,DateUpdated,TermsAndContions,SpecialNotesAndInstructions,SubTotal,TaxRate,ValidUntil,TotalTaxedAmount,QuoteCreatedBy,QuotationName,SupplierPhoneNumber,SupplierAddress,SupplierFax,SupplierEmail,FormFile")] Quotation quotation, IFormCollection Form)

        {
            //ViewBag.Name = Form["reqNumber"];
            string uniqueFileName = null;
            string filePath = null;
            Random rnd = new Random();

           // quotation.RequisitionId = Convert.ToInt32(Form["ReqId"]);
            quotation.BillToName = User.Identity.Name;
            quotation.QuoteCreatedBy = User.Identity.Name;
            quotation.ValidUntil = DateTime.Now;
           // quotation.QuotationId  = rnd.Next(25 + (2 * 3), 50);
            //quotation.QuotationId = 1;
            //if (ModelState.IsValid)
            //{

            _context.Add(quotation);
            await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            //}

            var SubmissionNotfication = new Notification();
            SubmissionNotfication.RequisitionId = quotation.RequisitionId ?? 0;
            SubmissionNotfication.To = "supplychain@yahoo.com";
            SubmissionNotfication.From = "suppliersmail@yahoo.com";
           // SubmissionNotfication.Cc = requisition.QueriesEmail;
            SubmissionNotfication.Action = "Succesful Submission";
            SubmissionNotfication.Comment = "";
            SubmissionNotfication.Message = "RFQ Response";
            SubmissionNotfication.IsRead.Equals(false);
            //SubmissionNotfication.Link = ReqSubmission;
            SubmissionNotfication.Link = "https://localhost:44334/Requisition/Details?RequisitionId=" + "" + quotation.RequisitionId;
            SubmissionNotfication.DateCreated = DateTime.Now;
           // _context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Authors] ON");
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Quotation ON");
            _context.Add(SubmissionNotfication);
            await _context.SaveChangesAsync();


            if (quotation.FormFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "Files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + quotation.FormFile.FileName;
                filePath = Path.Combine(uploadsFolder, uniqueFileName);
                quotation.FormFile.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            var fileattachment = new Attachment();
            fileattachment.DocumentPath = filePath;
            fileattachment.CreateDate = DateTime.Now;
            fileattachment.UpdateDate = DateTime.Now;
            fileattachment.ProcessTypeId = 2; // The prcessTypeId for Quotations is 2 in the database 
            fileattachment.DocumentName = uniqueFileName;
            fileattachment.Description = "";
            fileattachment.Extension = "docx";
            _context.Add(fileattachment);
            await _context.SaveChangesAsync();
            return View(quotation);
        }

        [HttpGet]
        //[Route("ApplicationVerification")]
        //[Route("Default1")]
        public ActionResult CreateEditQuotations(Guid TransactionNo, int SupplierId)
        {

            var requisition = _context.Requisition.Where(r => r.RequisitionNo == TransactionNo && r.RequisitionId > 0).SingleOrDefault();
            if (requisition == null)
            {
                return NotFound();
            }
            var supplierDetails = _context.Supplier.ToList().Find(x => x.SupplierId == SupplierId);
            ViewData["requisitionDetails"] = requisition;
            ViewData["selectedSupplierDetails"] = supplierDetails;


            //user is directed here via the email link, the create edit view is then displayed
            //https://localhost:44334/Quotations/CreateEditQuotation/?TransactionNo=

            return View("CreateEditQuotations");
        }

        // GET: Quotations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation.FindAsync(id);
            if (quotation == null)
            {
                return NotFound();
            }
            return View(quotation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuotationId,SupplierId,RequisitionId,Item,ItemDescription,Quantity,UnitPrice,Total,BillToAddress,BillToName,DateCreated,DateUpdated,TermsAndContions,SpecialNotesAndInstructions,SubTotal,TaxRate,ValidUntil,TotalTaxedAmount,QuoteCreatedBy,QuotationName,SupplierPhoneNumber,SupplierAddress,SupplierFax,SupplierEmail")] Quotation quotation)
        {
            if (id != quotation.QuotationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuotationExists(quotation.QuotationId))
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
            return View(quotation);
        }

        // GET: Quotations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quotation = await _context.Quotation
                .FirstOrDefaultAsync(m => m.QuotationId == id);
            if (quotation == null)
            {
                return NotFound();
            }

            return View(quotation);
        }

        // POST: Quotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quotation = await _context.Quotation.FindAsync(id);
            _context.Quotation.Remove(quotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuotationExists(int id)
        {
            return _context.Quotation.Any(e => e.QuotationId == id);
        }
    }
}
