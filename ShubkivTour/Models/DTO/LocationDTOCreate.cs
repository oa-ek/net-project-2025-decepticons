using ShubkivTour.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace ShubkivTour.Models.DTO
{
    public class LocationDTOCreate
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "Ім'я обов'язкове")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Опис обов'язковий")]
		public string Description { get; set; }
	}
}
