namespace ShubkivTour.Models.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public ICollection<TourClients> TourClients { get; set; }
    }
}
