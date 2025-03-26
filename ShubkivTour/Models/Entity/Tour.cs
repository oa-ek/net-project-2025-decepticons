namespace ShubkivTour.Models.Entity
{
	public class Tour
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Complexity { get; set; }
		public string Category { get; set; }
		public int Price { get; set; }
		public int Members { get; set; } //Кількість учасників скільки може бути на турі
		public DateTime Date { get; set; }
		public TourProgram TourProgram { get; set; }

		// Навігаційні властивості
		public ICollection<TourGuides> TourGuides { get; set; } = new List<TourGuides>();
		//public ICollection<TourEvents> TourEvents { get; set; } = new List<TourEvents>();
		public ICollection<TourClients> TourClients { get; set; } = new List<TourClients>();


		public ICollection<Review> Reviews { get; set; } = new List<Review>();
		public ICollection<Day> Days { get; set; } = new List<Day>(); // Тур має багато днів

	}
}
