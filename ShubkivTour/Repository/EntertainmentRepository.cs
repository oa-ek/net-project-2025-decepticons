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

        public void CreateEntertainment(Event entertainment)
        {
            if (entertainment == null)
            {
                throw new ArgumentNullException(nameof(entertainment), "Не всі поля отримали значення");
            }
            _context.Events.Add(entertainment);
            _context.SaveChanges();
        }

        public void DeleteEntertainment(int id)
        {
            var deletedEntertainment = _context.Events.FirstOrDefault(g => g.Id == id);
            if (deletedEntertainment != null)
            {
                _context.Events.Remove(deletedEntertainment);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Event> GetAllEntertainments()
        {
            return _context.Events.ToList();
        }

        public Event GetEntertainmentById(int entertainmentId)
        {
            return _context.Events.FirstOrDefault(p => p.Id == entertainmentId);
        }
        public void UpdateEntertainment(Event entertainment)
        {
            var existingEntertainment = _context.Events.Find(entertainment.Id);
            if (existingEntertainment != null)
            {
                existingEntertainment.Name = entertainment.Name;
                existingEntertainment.Description = entertainment.Description;
                _context.SaveChanges();
            }
        }

    }
}
