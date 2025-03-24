namespace ShubkivTour.Models.Entity
{
	public class TourEvents
	{
		public int Id { get; set; }  // Додано первинний ключ
		public int TourId { get; set; }
		public Tour Tour { get; set; }

		public int EventId { get; set; }
		public Event Event { get; set; }
	}
}
