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
    public class RazrediController : Controller
    {
        private readonly AppDbContext _context;

        public RazrediController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Razredi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Razredi.ToListAsync());
        }

        // GET: Razredi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razredi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (razred == null)
            {
                return NotFound();
            }

            return View(razred);
        }

        // GET: Razredi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Razredi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Smjer,GodinaUpisa")] Razred razred)
        {
            if (ModelState.IsValid)
            {
                _context.Add(razred);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(razred);
        }

        // GET: Razredi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razredi.FindAsync(id);
            if (razred == null)
            {
                return NotFound();
            }
            return View(razred);
        }

        // POST: Razredi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Smjer,GodinaUpisa")] Razred razred)
        {
            if (id != razred.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(razred);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazredExists(razred.Id))
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
            return View(razred);
        }

        // GET: Razredi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razred = await _context.Razredi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (razred == null)
            {
                return NotFound();
            }

            return View(razred);
        }

        // POST: Razredi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var razred = await _context.Razredi.FindAsync(id);
            if (razred != null)
            {
                _context.Razredi.Remove(razred);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazredExists(int id)
        {
            return _context.Razredi.Any(e => e.Id == id);
        }
    }
}
