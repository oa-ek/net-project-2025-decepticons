using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Repository
{
	public class GuideRepository : IGuide
	{
		private readonly ApplicationDbContext _context;

		public GuideRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateGuide(Guide guide)
		{
			if (guide == null)
			{
				throw new ArgumentNullException(nameof(guide), "Не всі поля отримали значення");
			}
			_context.Guides.Add(guide);
			_context.SaveChanges();
		}

		public void DeleteGuide(int id)
		{
			var deletedGuide = _context.Guides.FirstOrDefault(g => g.Id == id);
			if (deletedGuide != null)
			{
				_context.Guides.Remove(deletedGuide);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Guide> GetAllGuides()
		{
			return _context.Guides.ToList();
		}

		public Guide GetGuideById(int guideId)
		{
			return _context.Guides.FirstOrDefault(p => p.Id == guideId);
		}
        public void UpdateGuide(Guide guide)
        {
            var existingGuide = _context.Guides.Find(guide.Id);
            if (existingGuide != null)
            {
                existingGuide.Name = guide.Name;
                existingGuide.Specialty = guide.Specialty;
                existingGuide.Contact = guide.Contact;
                _context.SaveChanges();
            }
        }

    }
}
