using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
    public interface IEntertainments
    {
        IEnumerable<Entertainment> GetAllEntertainments();
        Entertainment GetEntertainmentById(int entertainmentId);
        void CreateEntertainment(Entertainment entertainment);
        void DeleteEntertainment(int id);
        void UpdateEntertainment(Entertainment entertainment);
    }
}
