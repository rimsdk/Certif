using System;
using System.Collections.Generic;

namespace Gestion_Certif.Model
{
    public class Certificat
    {
        public int id { get; set; }
        public string certifName { get; set; }
        public byte[]? uploadCertiftifUrl { get; set; }
        public int DepartementId { get; set; }
        public Departement departement { get; set; }
        public DateTime achievementDate { get; set; }
        public string? CertifPictureUrl { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
