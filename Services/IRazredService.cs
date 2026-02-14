using SchoolManagerMVC.Models;

namespace SchoolManagerMVC.Services
{
    public interface IRazredService
    {
        IEnumerable<Razred> GetAll();
        Razred? GetById(int id);
        void Add(Razred razred);
        void Update(Razred razred);
        void Delete(int id);
    }
}