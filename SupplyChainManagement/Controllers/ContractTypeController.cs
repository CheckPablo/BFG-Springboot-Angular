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
    public class ContractTypeController : Controller
    {
        private readonly RepositoryContext _context;

        public ContractTypeController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: ContractType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContractType.ToListAsync());
        }

        // GET: ContractType/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var contractType = await _context.ContractType
                .FirstOrDefaultAsync(m => m.ContractTypeId == id);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // GET: ContractType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContractType/Create
       
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("ContractTypeId,Description")] ContractType contractType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractType);
        }

        // GET: ContractType/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var contractType = await _context.ContractType.FindAsync(id);
            if (contractType == null)
            {
                return NotFound();
            }
            return View(contractType);
        }

        // POST: ContractType/Edit/5
       
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ContractTypeId,Description")] ContractType contractType)
        {
            if (id != contractType.ContractTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractTypeExists(contractType.ContractTypeId))
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
            return View(contractType);
        }

        // GET: ContractType/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var contractType = await _context.ContractType
                .FirstOrDefaultAsync(m => m.ContractTypeId == id);
            if (contractType == null)
            {
                return NotFound();
            }

            return View(contractType);
        }

        // POST: ContractType/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractType = await _context.ContractType.FindAsync(id);
            _context.ContractType.Remove(contractType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractTypeExists(int id)
        {
            return _context.ContractType.Any(e => e.ContractTypeId == id);
        }
    }
}
