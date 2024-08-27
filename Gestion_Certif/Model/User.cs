using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestion_Certif.Model
{
    public abstract class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public ICollection<Request_certif> SentRequests { get; set; } = new HashSet<Request_certif>();
        public ICollection<Request_certif> ReceivedRequests { get; set; } = new HashSet<Request_certif>(); public int? Request_certifId { get; set; }
        public Request_certif? request { get; set; }
        public int? DepartementId { get; set; }
        public Departement? departement { get; set; }
        public string phoneNumer { get; set; }
        public string Adress { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Certificat> Certifs { get; set; } = new HashSet<Certificat>(); // Relation avec
        public string UserType { get; set; }


    }
}
