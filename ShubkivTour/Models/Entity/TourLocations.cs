namespace ShubkivTour.Models.Entity
{
    public class TourLocations
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
