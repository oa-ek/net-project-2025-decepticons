namespace ShubkivTour.Models.Entity
{
	public class Day
	{
		public int Id { get; set; } // Було id з малої, виправлено
		public DateTime Date { get; set; }

		// Зв'язок з туром
		public int TourId { get; set; }
		public Tour Tour { get; set; }

		// Зв'язок з подіями
		public ICollection<Event> Events { get; set; } = new List<Event>();
	}
}
