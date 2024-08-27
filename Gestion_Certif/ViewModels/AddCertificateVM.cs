using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Certif.ViewModels
{
    public class AddCertificateVM
    {
        public int Id { get; set; } // Maps to Certificat.id

        public string? CertifName { get; set; } // Maps to Certificat.certifName

        public byte[]? CertifUrl { get; set; } // Maps to Certificat.uploadCertiftifUrl

        public int DepartementId { get; set; } // Maps to Certificat.DepartementId

        public string? CertifPictureUrl { get; set; }


    }
}
