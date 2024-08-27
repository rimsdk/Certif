using System;

namespace Gestion_Certif.ViewModels
{
    public class Request_CertifVM
    {
        public int Id { get; set; }
        public DateTime requestDate { get; set; }
        public string status { get; set; }
        public string decisionReason { get; set; }
        public Boolean required { get; set; }
        public int CertificatId { get; set; }
    }
}
