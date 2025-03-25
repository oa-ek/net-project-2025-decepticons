namespace ShubkivTour.Models.Entity
{
	public class TourProgram
	{
        public int Id { get; set; }

        public Tour Tour { get; set; }
        public int TourId { get; set; }

        public Day Day { get; set; }
        public int DayId { get; set; }

    }
}
