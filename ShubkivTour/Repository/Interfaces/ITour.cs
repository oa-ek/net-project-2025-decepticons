using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
    public interface ITour
    {
        IEnumerable<Tour> GetAllTours();
        Tour GetToursById(int tourId);
        void CreateTour(Tour tour);
        void DeleteTour(int id);
    }
}
