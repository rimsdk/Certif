using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;

namespace Gestion_Certif.Mappers
{
    public static class AllCertifMapper
    {
        public static AllCertif ToModel(AllCertifVM viewModel)
        {
            return new AllCertif
            {
                id = viewModel.Id,
                certifName = viewModel.CertifName ?? string.Empty, // Handle null values
                certifUrl = viewModel.CertifUrl ?? string.Empty, // Handle null values
                DepartementId = viewModel.DepartementId,
                CertifPictureUrl = viewModel.CertifPictureUrl // Handle null values
                // Note: `departement` is not included in AllCertifVM
            };
        }

        public static AllCertifVM ToViewModel(AllCertif certif)
        {
            return new AllCertifVM
            {
                Id = certif.id,
                CertifName = certif.certifName,
                CertifUrl = certif.certifUrl,
                DepartementId = certif.DepartementId,
                CertifPictureUrl = certif.CertifPictureUrl,
                Departement = new DepartementVM
                {
                    Id = certif.departement.id,
                    Name = certif.departement.name
                }
            };
        }

    }
}
