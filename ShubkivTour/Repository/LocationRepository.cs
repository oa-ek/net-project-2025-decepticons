using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Repository
{
	public class LocationRepository : ILocation
	{
		private readonly ApplicationDbContext _context;

		public LocationRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateLocation(Location location)
		{
			if (location == null)
			{
				throw new ArgumentNullException(nameof(location), "Не всі поля отримали значення");
			}
			_context.Locations.Add(location);
			_context.SaveChanges();
		}

		public void DeleteLocation(int id)
		{
			var deletedLocation = _context.Locations.FirstOrDefault(l => l.Id == id);
			if (deletedLocation != null)
			{
				_context.Locations.Remove(deletedLocation);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Location> GetAllLocations()
		{
			return _context.Locations.ToList();
		}

		public Location GetLocationById(int locationId)
		{
			return _context.Locations.FirstOrDefault(l => l.Id == locationId);
		}
		public void UpdateLocation(Location location)
		{
			var existingLocation = _context.Locations.Find(location.Id);
			if (existingLocation != null)
			{
				existingLocation.Name = location.Name;
				existingLocation.Description = location.Description;
				_context.SaveChanges();
			}
		}

	}
}
