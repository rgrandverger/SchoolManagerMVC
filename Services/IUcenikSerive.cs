using SchoolManagerMVC.Models;

namespace SchoolManagerMVC.Services
{
    public interface IUcenikService
    {
        IEnumerable<Ucenik> GetAll();
        Ucenik? GetById(int id);
        void Add(Ucenik ucenik);
        void Update(Ucenik ucenik);
        void Delete(int id);
    }
}