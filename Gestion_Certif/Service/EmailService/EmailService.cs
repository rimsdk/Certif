using System;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Gestion_Certif.Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

     
        private static string _randomString;

        public EmailService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public void GenerateRandom()
        {
            Random rand = new Random();
            StringBuilder randomStringBuilder = new StringBuilder();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < 4; i++)
            {
                randomStringBuilder.Append(chars[rand.Next(chars.Length)]);
            }

            _randomString = randomStringBuilder.ToString();
        }

        public void SendEmail(string recipientEmail)
        {

            GenerateRandom();
            if (string.IsNullOrEmpty(_randomString))
            {
                throw new InvalidOperationException("Random string not generated.");
            }

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(recipientEmail));
            email.Subject = "Code de verification";
            email.Body = new TextPart("plain") { Text = _randomString };

            using var smtp = new SmtpClient();
            try
            {
                smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.Send(email);
                Console.WriteLine("Email sent successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email. Error: {ex.Message}");
            }
            finally
            {
                smtp.Disconnect(true);
                smtp.Dispose();
            }
        }

        public bool VerifyCode(string code)
        {
            if (string.IsNullOrEmpty(_randomString))
            {
                Console.WriteLine("Random string has not been generated.");
                return false;
            }

            return _randomString.Equals(code, StringComparison.OrdinalIgnoreCase);
        }
    }
}
