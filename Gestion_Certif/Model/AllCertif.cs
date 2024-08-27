namespace Gestion_Certif.Model
{
    public class AllCertif
    {
        public int id { get; set; }
        public string certifName { get; set; }
        public string certifUrl { get; set; }
        public int DepartementId { get; set; }
        public Departement departement { get; set; }

        public string? CertifPictureUrl { get; set; }

    }
}
