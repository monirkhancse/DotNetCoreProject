using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreProject.Models;

namespace DotNetCoreProject.Controllers
{
    public class EmpLedgerTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpLedgerTitlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpLedgerTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpLedgerTitle.ToListAsync());
        }

        // GET: EmpLedgerTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empLedgerTitle = await _context.EmpLedgerTitle
                .FirstOrDefaultAsync(m => m.EmpLedgerTitleId == id);
            if (empLedgerTitle == null)
            {
                return NotFound();
            }

            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpLedgerTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpLedgerTitleId,Title,CreatedDate")] EmpLedgerTitle empLedgerTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empLedgerTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empLedgerTitle = await _context.EmpLedgerTitle.FindAsync(id);
            if (empLedgerTitle == null)
            {
                return NotFound();
            }
            return View(empLedgerTitle);
        }

        // POST: EmpLedgerTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpLedgerTitleId,Title,CreatedDate")] EmpLedgerTitle empLedgerTitle)
        {
            if (id != empLedgerTitle.EmpLedgerTitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empLedgerTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpLedgerTitleExists(empLedgerTitle.EmpLedgerTitleId))
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
            return View(empLedgerTitle);
        }

        // GET: EmpLedgerTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empLedgerTitle = await _context.EmpLedgerTitle
                .FirstOrDefaultAsync(m => m.EmpLedgerTitleId == id);
            if (empLedgerTitle == null)
            {
                return NotFound();
            }

            return View(empLedgerTitle);
        }

        // POST: EmpLedgerTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empLedgerTitle = await _context.EmpLedgerTitle.FindAsync(id);
            _context.EmpLedgerTitle.Remove(empLedgerTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpLedgerTitleExists(int id)
        {
            return _context.EmpLedgerTitle.Any(e => e.EmpLedgerTitleId == id);
        }
    }
}
