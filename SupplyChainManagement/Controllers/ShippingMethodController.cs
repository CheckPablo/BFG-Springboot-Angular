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
    public class ShippingMethodController : Controller
    {
        private readonly RepositoryContext _context;

        public ShippingMethodController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: ShippingMethod
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShippingMethod.ToListAsync());
        }

        // GET: ShippingMethod/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var shippingMethod = await _context.ShippingMethod
                .FirstOrDefaultAsync(m => m.ShippingMethodId == id);
            if (shippingMethod == null)
            {
                return NotFound();
            }

            return View(shippingMethod);
        }

        // GET: ShippingMethod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShippingMethod/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ShippingMethodId,Description")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            { 
                _context.Add(shippingMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippingMethod);
        }

        // GET: ShippingMethod/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var shippingMethod = await _context.ShippingMethod.FindAsync(id);
            if (shippingMethod == null)
            {
                return NotFound();
            }
            return View(shippingMethod);
        }

        // POST: ShippingMethod/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ShippingMethodId,Description")] ShippingMethod shippingMethod)
        {
            if (id != shippingMethod.ShippingMethodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingMethodExists(shippingMethod.ShippingMethodId))
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
            return View(shippingMethod);
        }

        // GET: ShippingMethod/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var shippingMethod = await _context.ShippingMethod
                .FirstOrDefaultAsync(m => m.ShippingMethodId == id);
            if (shippingMethod == null)
            {
                return NotFound();
            }

            return View(shippingMethod);
        }

        // POST: ShippingMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shippingMethod = await _context.ShippingMethod.FindAsync(id);
            _context.ShippingMethod.Remove(shippingMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingMethodExists(int id)
        {
            return _context.ShippingMethod.Any(e => e.ShippingMethodId == id);
        }
    }
}
