using ShubkivTour.Models.Entity;

namespace ShubkivTour.Models.DTO
{
    public class UserWithRole
    {
        public Client User { get; set; }
        public string Role { get; set; }
        public bool IsLocked { get; set; }
    }
}
