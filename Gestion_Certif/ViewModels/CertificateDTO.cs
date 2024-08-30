namespace Gestion_Certif.ViewModels
{
    public class CertificateDTO
    {
        public int Id { get; set; }
        public string CertifName { get; set; }
        public string CertifPictureUrl { get; set; }
        public DateTime AchievementDate { get; set; }
        public string DepartmentName { get; set; }
    }
}
