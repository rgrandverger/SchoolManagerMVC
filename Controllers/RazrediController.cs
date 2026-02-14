using Microsoft.AspNetCore.Mvc;
using SchoolManagerMVC.Models;
using SchoolManagerMVC.Services;

namespace SchoolManagerMVC.Controllers
{
    public class RazrediController : Controller
    {
        private readonly IRazredService _razredService;

        public RazrediController(IRazredService razredService)
        {
            _razredService = razredService;
        }

        // GET: Razredi
        public IActionResult Index()
        {
            var razredi = _razredService.GetAll();
            return View(razredi);
        }

        // GET: Razredi/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var razred = _razredService.GetById(id.Value);
            if (razred == null) return NotFound();

            return View(razred);
        }

        // GET: Razredi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Razredi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,Smjer,GodinaUpisa")] Razred razred)
        {
            if (ModelState.IsValid)
            {
                _razredService.Add(razred);
                return RedirectToAction(nameof(Index));
            }
            return View(razred);
        }

        // GET: Razredi/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var razred = _razredService.GetById(id.Value);
            if (razred == null) return NotFound();

            return View(razred);
        }

        // POST: Razredi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Naziv,Smjer,GodinaUpisa")] Razred razred)
        {
            if (id != razred.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _razredService.Update(razred);
                return RedirectToAction(nameof(Index));
            }
            return View(razred);
        }

        // GET: Razredi/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var razred = _razredService.GetById(id.Value);
            if (razred == null) return NotFound();

            return View(razred);
        }

        // POST: Razredi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _razredService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}