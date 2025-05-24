using System.ComponentModel.DataAnnotations;

namespace ShubkivTour.Models.DTO
{
    public class ReviewViewModel
    {
        public int TourId { get; set; }
        //public string TourName { get; set; }

        [Required]
        public string ReviewerName { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
