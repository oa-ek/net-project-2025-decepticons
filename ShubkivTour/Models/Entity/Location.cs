namespace ShubkivTour.Models.Entity
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<TourLocations> TourLocations { get; set; }
    }
}
