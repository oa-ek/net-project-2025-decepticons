using Microsoft.AspNetCore.Identity;

namespace ShubkivTour.Models.Entity
{
    public class Client : IdentityUser
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public int YearOfBirth { get; set; }
        public ICollection<TourClients> TourClients { get; set; }
    }
}
