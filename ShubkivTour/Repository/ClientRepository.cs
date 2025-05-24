using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShubkivTour.Data;
using ShubkivTour.Models.Entity;
using ShubkivTour.Repository.Interfaces;

namespace ShubkivTour.Repository
{
    public class ClientRepository : IClient
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context, UserManager<Client> userManager)
        {
            _context = context;
        }
        public void CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAllTourClients(int tourId)
        {
            var tour = _context.Tours
                .Include(t => t.TourClients)
                    .ThenInclude(tc => tc.Client)
                .FirstOrDefault(t => t.Id == tourId);

            if (tour == null)
                return Enumerable.Empty<Client>();

            return tour.TourClients
                .Where(tc => tc.Client != null)
                .Select(tc => tc.Client);
        }



        public Client GetClientById(string clientId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveClientFromTour(int tourId, string clientId)
        {
            var tourClient = _context.TourClients
     .FirstOrDefault(tc => tc.TourId == tourId && tc.ClientId == clientId);

            if (tourClient == null)
                return false;

            var tour = _context.Tours.FirstOrDefault(t => t.Id == tourId);
            tour.CurrentMembers--;

            _context.TourClients.Remove(tourClient);
            _context.SaveChanges();

            return true;
        }

        public void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
