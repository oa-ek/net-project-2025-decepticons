using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
	public interface IGuide
	{
		IEnumerable<Guide> GetAllGuides();
		Guide GetGuideById(int guideId);
		void CreateGuide(Guide guide);
		void DeleteGuide(int id);
	}
}
