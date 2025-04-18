using ShubkivTour.Models.Entity;
namespace ShubkivTour.Models.DTO
{
    public class EventDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly Time { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public string ImageFilePath { get; set; }

    }
}
