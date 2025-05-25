using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
    public interface ITour
    {
        IEnumerable<Tour> GetAllTours();
        IEnumerable<Tour> GetUpcomingTours();
        Tour GetToursById(int tourId);
        void CreateTour(Tour tour);
        void DeleteTour(int id);
        Task RegisterForTour(int tourId, string userId);


        IEnumerable<Review> GetReviews();
        IEnumerable<Client> GetTourClient(int tourId);
        void RemoveClientFromTour(int tourId, string clientId);

    }
}
