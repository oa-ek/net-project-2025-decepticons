namespace ShubkivTour.Models.DTO
{
    public class TourProgramViewModel
    {
        public List<DayDTO> Days { get; set; } = new List<DayDTO>();
        public DayDTO CurrentDay { get; set; } = new DayDTO();
    }
}
