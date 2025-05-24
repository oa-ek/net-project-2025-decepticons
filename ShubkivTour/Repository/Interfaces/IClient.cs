using ShubkivTour.Models.Entity;

namespace ShubkivTour.Repository.Interfaces
{
	public interface IClient
    {
        IEnumerable<Client> GetAllTourClients(int tourId);
        Client GetClientById(string clientId);
        void CreateClient(Client client);
        void DeleteClient(string id);
        void UpdateClient(Client client);
        bool RemoveClientFromTour(int tourId, string clientId);
    }
}
