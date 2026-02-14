using SchoolManagerMVC.Data;
using SchoolManagerMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagerMVC.Services
{
    public class UcenikService : IUcenikService
    {
        private readonly AppDbContext _context;

        public UcenikService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ucenik> GetAll()
        {
            return _context.Ucenici.Include(u => u.Razred).ToList();
        }

        public Ucenik? GetById(int id)
        {
            return _context.Ucenici.Include(u => u.Razred).FirstOrDefault(u => u.Id == id);
        }

        public void Add(Ucenik ucenik)
        {
            _context.Ucenici.Add(ucenik);
            _context.SaveChanges();
        }

        public void Update(Ucenik ucenik)
        {
            _context.Ucenici.Update(ucenik);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ucenik = _context.Ucenici.Find(id);
            if (ucenik != null)
            {
                _context.Ucenici.Remove(ucenik);
                _context.SaveChanges();
            }
        }
    }
}