namespace ShubkivTour.Models.Entity
{
    public class Entertainment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<TourEntertainments> TourEntertainments { get; set; }
    }
}
