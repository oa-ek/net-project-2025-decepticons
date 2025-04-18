using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
    public interface IEntertainments
    {
        IEnumerable<Event> GetAllEntertainments();
        Event GetEntertainmentById(int entertainmentId);
        void CreateEntertainment(Event entertainment);
        void DeleteEntertainment(int id);
        void UpdateEntertainment(Event entertainment);
    }
}
