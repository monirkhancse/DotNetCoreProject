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
    public class EmployeeLedgersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLedgersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeLedgers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeLedger.Include(e => e.EmpLedgerTitle).Include(e => e.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeLedgers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLedger = await _context.EmployeeLedger
                .Include(e => e.EmpLedgerTitle)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLedger == null)
            {
                return NotFound();
            }

            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Create
        public IActionResult Create()
        {
            ViewData["EmpLedgerTitleId"] = new SelectList(_context.EmpLedgerTitle, "EmpLedgerTitleId", "Title");
            ViewData["EmployeeID"] = new SelectList(_context.employees, "EmployeeId", "Name");
            return View();
        }

        // POST: EmployeeLedgers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,EmpLedgerTitleId,EmployeeID,PreviousDue,PayAmount,Received,Remarks")] EmployeeLedger employeeLedger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeLedger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpLedgerTitleId"] = new SelectList(_context.EmpLedgerTitle, "EmpLedgerTitleId", "Title", employeeLedger.EmpLedgerTitleId);
            ViewData["EmployeeID"] = new SelectList(_context.employees, "EmployeeId", "Name", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLedger = await _context.EmployeeLedger.FindAsync(id);
            if (employeeLedger == null)
            {
                return NotFound();
            }
            ViewData["EmpLedgerTitleId"] = new SelectList(_context.EmpLedgerTitle, "EmpLedgerTitleId", "Title", employeeLedger.EmpLedgerTitleId);
            ViewData["EmployeeID"] = new SelectList(_context.employees, "EmployeeId", "Name", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // POST: EmployeeLedgers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,EmpLedgerTitleId,EmployeeID,PreviousDue,PayAmount,Received,Remarks")] EmployeeLedger employeeLedger)
        {
            if (id != employeeLedger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeLedger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeLedgerExists(employeeLedger.Id))
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
            ViewData["EmpLedgerTitleId"] = new SelectList(_context.EmpLedgerTitle, "EmpLedgerTitleId", "Title", employeeLedger.EmpLedgerTitleId);
            ViewData["EmployeeID"] = new SelectList(_context.employees, "EmployeeId", "Name", employeeLedger.EmployeeID);
            return View(employeeLedger);
        }

        // GET: EmployeeLedgers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeLedger = await _context.EmployeeLedger
                .Include(e => e.EmpLedgerTitle)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeLedger == null)
            {
                return NotFound();
            }

            return View(employeeLedger);
        }

        // POST: EmployeeLedgers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeLedger = await _context.EmployeeLedger.FindAsync(id);
            _context.EmployeeLedger.Remove(employeeLedger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeLedgerExists(int id)
        {
            return _context.EmployeeLedger.Any(e => e.Id == id);
        }
    }
}
