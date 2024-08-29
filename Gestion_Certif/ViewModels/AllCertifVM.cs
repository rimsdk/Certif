namespace Gestion_Certif.ViewModels
{
    public class AllCertifVM
    {
        public int Id { get; set; }
        public string CertifName { get; set; }
        public string CertifUrl { get; set; }
        public int DepartementId { get; set; }
        public string? CertifPictureUrl { get; set; }
        public DepartementVM Departement { get; set; }
    }
}
