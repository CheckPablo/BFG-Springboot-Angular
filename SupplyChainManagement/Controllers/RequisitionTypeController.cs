using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;

namespace SupplyChainManagement.Controllers
{
    public class RequisitionTypeController : Controller
    {
        private readonly RepositoryContext _context;

        public RequisitionTypeController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: RequisitionType
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequisitionType.ToListAsync());
        }

        // GET: RequisitionType/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var requisitionType = await _context.RequisitionType
                .FirstOrDefaultAsync(m => m.RequisitionTypeId == id);
            if (requisitionType == null)
            {
                return NotFound();
            }

            return View(requisitionType);
        }

        // GET: RequisitionType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequisitionType/Create
       
        [HttpPost]
        public async Task<IActionResult> Create([Bind("RequisitionTypeId,Description")] RequisitionType requisitionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisitionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requisitionType);
        }

        // GET: RequisitionType/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var requisitionType = await _context.RequisitionType.FindAsync(id);
            if (requisitionType == null)
            {
                return NotFound();
            }
            return View(requisitionType);
        }

        // POST: RequisitionType/Edit/5
      
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("RequisitionTypeId,Description")] RequisitionType requisitionType)
        {
            if (id != requisitionType.RequisitionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisitionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitionTypeExists(requisitionType.RequisitionTypeId))
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
            return View(requisitionType);
        }

        // GET: RequisitionType/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var requisitionType = await _context.RequisitionType
                .FirstOrDefaultAsync(m => m.RequisitionTypeId == id);
            if (requisitionType == null)
            {
                return NotFound();
            }

            return View(requisitionType);
        }

        // POST: RequisitionType/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisitionType = await _context.RequisitionType.FindAsync(id);
            _context.RequisitionType.Remove(requisitionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitionTypeExists(int id)
        {
            return _context.RequisitionType.Any(e => e.RequisitionTypeId == id);
        }
    }
}
