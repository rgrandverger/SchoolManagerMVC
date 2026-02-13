using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagerMVC.Data;
using SchoolManagerMVC.Models;

namespace SchoolManagerMVC.Controllers
{
    public class UceniciController : Controller
    {
        private readonly AppDbContext _context;

        public UceniciController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ucenici
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Ucenici.Include(u => u.Razred);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Ucenici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenici
                .Include(u => u.Razred)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucenik == null)
            {
                return NotFound();
            }

            return View(ucenik);
        }

        // GET: Ucenici/Create
        public IActionResult Create()
        {
            ViewData["RazredId"] = new SelectList(_context.Razredi, "Id", "Id");
            return View();
        }

        // POST: Ucenici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,DatumRodenja,Email,Prosjek,RazredId")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucenik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RazredId"] = new SelectList(_context.Razredi, "Id", "Id", ucenik.RazredId);
            return View(ucenik);
        }

        // GET: Ucenici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenici.FindAsync(id);
            if (ucenik == null)
            {
                return NotFound();
            }
            ViewData["RazredId"] = new SelectList(_context.Razredi, "Id", "Id", ucenik.RazredId);
            return View(ucenik);
        }

        // POST: Ucenici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,DatumRodenja,Email,Prosjek,RazredId")] Ucenik ucenik)
        {
            if (id != ucenik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucenik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcenikExists(ucenik.Id))
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
            ViewData["RazredId"] = new SelectList(_context.Razredi, "Id", "Id", ucenik.RazredId);
            return View(ucenik);
        }

        // GET: Ucenici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ucenik = await _context.Ucenici
                .Include(u => u.Razred)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucenik == null)
            {
                return NotFound();
            }

            return View(ucenik);
        }

        // POST: Ucenici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ucenik = await _context.Ucenici.FindAsync(id);
            if (ucenik != null)
            {
                _context.Ucenici.Remove(ucenik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcenikExists(int id)
        {
            return _context.Ucenici.Any(e => e.Id == id);
        }
    }
}
