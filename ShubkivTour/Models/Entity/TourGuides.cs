namespace ShubkivTour.Models.Entity
{
    public class TourGuides
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
