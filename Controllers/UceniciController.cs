using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagerMVC.Models;
using SchoolManagerMVC.Services;

namespace SchoolManagerMVC.Controllers
{
    public class UceniciController : Controller
    {
        private readonly IUcenikService _ucenikService;
        private readonly IRazredService _razredService;

        public UceniciController(IUcenikService ucenikService, IRazredService razredService)
        {
            _ucenikService = ucenikService;
            _razredService = razredService;
        }

        // GET: Ucenici
        public IActionResult Index()
        {
            var ucenici = _ucenikService.GetAll();
            return View(ucenici);
        }

        // GET: Ucenici/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var ucenik = _ucenikService.GetById(id.Value);
            if (ucenik == null) return NotFound();

            return View(ucenik);
        }

        // GET: Ucenici/Create
        public IActionResult Create()
        {
            ViewData["RazredId"] = new SelectList(_razredService.GetAll(), "Id", "Naziv");
            return View();
        }

        // POST: Ucenici/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Ime,Prezime,DatumRodenja,Email,Prosjek,RazredId")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                _ucenikService.Add(ucenik);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RazredId"] = new SelectList(_razredService.GetAll(), "Id", "Naziv", ucenik.RazredId);
            return View(ucenik);
        }

        // GET: Ucenici/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var ucenik = _ucenikService.GetById(id.Value);
            if (ucenik == null) return NotFound();

            ViewData["RazredId"] = new SelectList(_razredService.GetAll(), "Id", "Naziv", ucenik.RazredId);
            return View(ucenik);
        }

        // POST: Ucenici/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Ime,Prezime,DatumRodenja,Email,Prosjek,RazredId")] Ucenik ucenik)
        {
            if (id != ucenik.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _ucenikService.Update(ucenik);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RazredId"] = new SelectList(_razredService.GetAll(), "Id", "Naziv", ucenik.RazredId);
            return View(ucenik);
        }

        // GET: Ucenici/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var ucenik = _ucenikService.GetById(id.Value);
            if (ucenik == null) return NotFound();

            return View(ucenik);
        }

        // POST: Ucenici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ucenikService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}