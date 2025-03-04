namespace ShubkivTour.Models.Entity
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TourGuides> TourGuides { get; set; }
        public ICollection<TourLocations> TourLocations { get; set; }
        public ICollection<TourEntertainments> TourEntertainments { get; set; }
        public ICollection<TourClients> TourClients { get; set; }
        public string Complexity { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}
