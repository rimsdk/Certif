using Gestion_Certif.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gestion_Certif.ViewModels
{
    public class AddCertificateVM
    {
        
        
            public int Id { get; set; }
            public string CertifName { get; set; }
            public string? CertifPictureUrl { get; set; }
        public byte[]? uploadCertiftifUrl { get; set; }

        public DateTime AchievementDate { get; set; }
            public int DepartementId { get; set; }

            public int UserId { get; set; }
        public User? Sender { get; set; }
       




    }
}
