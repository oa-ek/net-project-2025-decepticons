namespace ShubkivTour.Models.Entity
{
    public class Day
    {
        public int Id { get; set; }
        public int TourProgramId { get; set; }
        public TourProgram TourProgram { get; set; }
        public int DayNumber { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
