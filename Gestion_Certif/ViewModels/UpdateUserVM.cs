using Gestion_Certif.Model;

namespace Gestion_Certif.ViewModels
{
    public class UpdateUserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int? DepartementId { get; set; }

    }
}
