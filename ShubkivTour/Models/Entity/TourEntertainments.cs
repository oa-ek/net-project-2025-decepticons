namespace ShubkivTour.Models.Entity
{
    public class TourEntertainments
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}
