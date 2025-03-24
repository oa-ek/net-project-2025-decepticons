namespace ShubkivTour.Models.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public Location Location { get; set; }
        public ICollection<TourEvents> TourEvents { get; set; }
    }
}
