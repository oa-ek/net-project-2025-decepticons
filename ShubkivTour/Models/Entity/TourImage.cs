namespace ShubkivTour.Models.Entity
{
    public class TourImage 
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; } 
    }
}
