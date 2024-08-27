namespace Gestion_Certif.ViewModels
{
    public class PutUserVM
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int? DepartementId { get; set; }
        public string phoneNumer { get; set; }
        public string Adress { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
