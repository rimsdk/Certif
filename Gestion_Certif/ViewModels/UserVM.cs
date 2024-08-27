using Gestion_Certif.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;


namespace Gestion_Certif.ViewModels
{
    public class UserVM
    {

        public int? id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int? DepartementId { get; set; }
        [JsonPropertyName("mainDepartement")]
        public Departement Departement { get; set; }
        [JsonPropertyName("optionalDepartement")]
        public Departement? departement { get; set; }

        public int? Request_certifId { get; set; }
        public Request_certif? request { get; set; }
        public string phoneNumer { get; set; }
        public string Adress { get; set; }
        public string? ProfilePictureUrl { get; set; }

    }
}
