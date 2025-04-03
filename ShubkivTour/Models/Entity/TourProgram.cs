using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
namespace ShubkivTour.Models.Entity
{
	public class TourProgram
	{
        public int Id { get; set; }
        public string Name { get; set; }
        //public Tour Tour { get; set; }
        //public int TourId { get; set; } 

        public ICollection<Day> Days { get; set; } = new List<Day>();

	}
}
