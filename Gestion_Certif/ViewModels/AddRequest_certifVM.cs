using System;

namespace Gestion_Certif.ViewModels
{
    public class AddRequest_certifVM
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string DecisionReason { get; set; }
        public bool Required { get; set; }
        public int? SenderId { get; set; }
        public int AllCertifId { get; set; }

        public int? ReceiverId { get; set; }
    }
}
