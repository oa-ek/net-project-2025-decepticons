namespace ShubkivTour.Models.Entity
{
    public class TourClients
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
