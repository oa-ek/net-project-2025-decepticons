namespace ShubkivTour.Models.Entity
{
    public class EventImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; } 
    }
}
