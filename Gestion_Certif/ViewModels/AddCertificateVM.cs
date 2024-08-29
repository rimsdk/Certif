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
<<<<<<< HEAD
            public int UserId { get; set; }
        public User? Sender { get; set; }
       
=======
      
        public int UserId { get; set; }
        
>>>>>>> e198897e4e056c3dce016972bb2d359cef6e4999



    }
}
