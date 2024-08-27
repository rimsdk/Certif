using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Service.EmailService
{
    public interface IEmailService
    {
        void SendEmail(string email);
        public bool VerifyCode(string code);
    }
}
