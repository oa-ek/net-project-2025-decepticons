namespace ShubkivTour.Models.Entity
{
    public class Day
    {
        public int Id { get; set; }
        //public DateTime Date { get; set; }

        public int TourProgramId { get; set; }
        public TourProgram TourProgram { get; set; }
        public int DayNumber { get; set; }
        /*		public int TourId { get; set; }
                public Tour Tour { get; set; }*/

        //public ICollection<DayEvents> DayEvents { get; set; } = new List<DayEvents>();
        public ICollection<Event> Events { get; set; } = new List<Event>();

    }
}
