namespace ShubkivTour.Models.DTO
{
    public class DayDTO
    {
        public int DayNumber { get; set; }
        public List<EventDTO> Events { get; set; } = new List<EventDTO>();
    }
}
