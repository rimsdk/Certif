namespace Gestion_Certif.ViewModels
{
    public class UpdateCertificateVM
    {
        public int id { get; set; }
        public string? CertifName { get; set; } // Maps to Certificat.certifName

        public byte[]? CertifUrl { get; set; } // Maps to Certificat.uploadCertiftifUrl

        public int? DepartementId { get; set; } // Maps to Certificat.DepartementId (optional)

        public string? CertifPictureUrl { get; set; } //
    }
}
