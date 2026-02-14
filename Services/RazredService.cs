using SchoolManagerMVC.Data;
using SchoolManagerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagerMVC.Services
{
    public class RazredService : IRazredService
    {
        private readonly AppDbContext _context;

        public RazredService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Razred> GetAll()
        {
            return _context.Razredi.Include(r => r.Ucenici).ToList();
        }

        public Razred? GetById(int id)
        {
            return _context.Razredi.Include(r => r.Ucenici).FirstOrDefault(r => r.Id == id);
        }

        public void Add(Razred razred)
        {
            _context.Razredi.Add(razred);
            _context.SaveChanges();
        }

        public void Update(Razred razred)
        {
            _context.Razredi.Update(razred);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var razred = _context.Razredi.Find(id);
            if (razred != null)
            {
                _context.Razredi.Remove(razred);
                _context.SaveChanges();
            }
        }
    }
}