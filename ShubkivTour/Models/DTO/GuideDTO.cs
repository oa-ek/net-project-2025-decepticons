using System.ComponentModel.DataAnnotations;

namespace ShubkivTour.Models.DTO
{
    public class GuideDTO
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Ім'я обов'язкове")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Спеціальність обов'язкова")]
		public string Specialty { get; set; }
		[Required(ErrorMessage = "Контакти обов'язкові")]
		public string Contact { get; set; }
    }
}
