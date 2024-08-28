using System;
using System.Collections.Generic;

namespace Gestion_Certif.Model
{
    public class Request_certif
    {
        public int id { get; set; }
        public DateTime requestDate { get; set; }
        public string status { get; set; }
        public string decisionReason { get; set; }
        public Boolean required { get; set; }
        public int? SenderId { get; set; }
        public User Sender { get; set; }
        public int AllCertifId { get; set; }
        public AllCertif AllCertif { get; set; }
        public int? ReceiverId { get; set; }
        public User Receiver { get; set; }

    }
}
