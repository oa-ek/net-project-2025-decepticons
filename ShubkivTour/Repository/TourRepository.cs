using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Repository
{
    public class TourRepository : ITour
    {
        private readonly ApplicationDbContext _context;


        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

		public void CreateTour(Tour tour)
		{
			if (tour == null)
			{
				throw new ArgumentNullException(nameof(tour), "Не всі поля отримали значення");
			}

			_context.Tours.Add(tour);

			/*if (tour.TourProgram != null)
			{
				_context.TourPrograms.Add(tour.TourProgram);

				foreach (var day in tour.TourProgram.Days)
				{
					_context.Days.Add(day);

					foreach (var ev in day.Events)
					{
						_context.Events.Add(ev);
					}
				}
			}*/

			_context.SaveChanges();
		}

		//ЗРОБИ ТАК ЩОБ ПРОГРАМА ЗЧИТУВАЛА ДАНІ З ТИМЧАСОВИХ СПИСКІВ (ДНІВ ТА ІВЕНТІВ) І ЗАПИСУВАЛА ЦІ ДАНІ В ТАБЛИЦІ.
		public void DeleteTour(int id)
        {
            var deletedTour = _context.Tours.FirstOrDefault(g => g.Id == id);
            if (deletedTour != null)
            {
                _context.Tours.Remove(deletedTour);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Tour> GetAllTours()
        {
            return _context.Tours.ToList();
        }

        public Tour GetToursById(int tourId)
        {
            return _context.Tours.FirstOrDefault(p => p.Id == tourId);
        }
    }
}
