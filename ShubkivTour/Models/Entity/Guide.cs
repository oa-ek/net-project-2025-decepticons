namespace ShubkivTour.Models.Entity
{
    public class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Contact { get; set; }
        public ICollection<TourGuides> TourGuides { get; set; }
    }
}
