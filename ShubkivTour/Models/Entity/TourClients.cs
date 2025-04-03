namespace ShubkivTour.Models.Entity
{
    public class TourClients
    {
        public int Id { get; set; }

        public int TourId { get; set; }
		public int Id { get; set; }

		public int TourId { get; set; }
        public Tour Tour { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime BookingDate { get; set; }
    }
}
