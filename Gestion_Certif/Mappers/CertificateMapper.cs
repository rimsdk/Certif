using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Mappers
{
    public static class CertificateMapper
    {
        public static Certificat ToModel(AddCertificateVM viewModel)
        {
            return new Certificat
            {
                id = viewModel.Id,
                certifName = viewModel.CertifName ?? string.Empty, // Handle null values
                uploadCertiftifUrl = viewModel.CertifUrl, // This is nullable
                DepartementId = viewModel.DepartementId , // Handle null values
                CertifPictureUrl = viewModel.CertifPictureUrl ?? string.Empty // Handle null values
                // Note: `achievementDate` and `userId` are not included in AddCertificateVM
            };
        }

        public static AddCertificateVM ToViewModel(Certificat model)
        {
            return new AddCertificateVM
            {
                Id = model.id,
                CertifName = model.certifName,
                CertifUrl = model.uploadCertiftifUrl,
                DepartementId = model.DepartementId,
                CertifPictureUrl = model.CertifPictureUrl
            };
        }

        public static Certificat UpdateModel(Certificat existingCertificat, UpdateCertificateVM updateCertificateVM)
        {
            if (updateCertificateVM.CertifName != null)
                existingCertificat.certifName = updateCertificateVM.CertifName;

            if (updateCertificateVM.CertifUrl != null)
                existingCertificat.uploadCertiftifUrl = updateCertificateVM.CertifUrl;

            if (updateCertificateVM.DepartementId.HasValue)
                existingCertificat.DepartementId = updateCertificateVM.DepartementId.Value;

            if (updateCertificateVM.CertifPictureUrl != null)
                existingCertificat.CertifPictureUrl = updateCertificateVM.CertifPictureUrl;

            return existingCertificat;
        }
    }
}
