using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Repository
{
    public class EntertainmentRepository : IEntertainments
    {
        private readonly ApplicationDbContext _context;

        public EntertainmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateEntertainment(Entertainment entertainment)
        {
            if (entertainment == null)
            {
                throw new ArgumentNullException(nameof(entertainment), "Не всі поля отримали значення");
            }
            _context.Entertainments.Add(entertainment);
            _context.SaveChanges();
        }

        public void DeleteEntertainment(int id)
        {
            var deletedEntertainment = _context.Entertainments.FirstOrDefault(g => g.Id == id);
            if (deletedEntertainment != null)
            {
                _context.Entertainments.Remove(deletedEntertainment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Entertainment> GetAllEntertainments()
        {
            return _context.Entertainments.ToList();
        }

        public Entertainment GetEntertainmentById(int entertainmentId)
        {
            return _context.Entertainments.FirstOrDefault(p => p.Id == entertainmentId);
        }
        public void UpdateEntertainment(Entertainment entertainment)
        {
            var existingEntertainment = _context.Entertainments.Find(entertainment.Id);
            if (existingEntertainment != null)
            {
                existingEntertainment.Name = entertainment.Name;
                existingEntertainment.Description = entertainment.Description;
                _context.SaveChanges();
            }
        }

    }
}
