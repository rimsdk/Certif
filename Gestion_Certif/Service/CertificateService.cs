using Gestion_Certif.Mappers;
using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gestion_Certif.Service
{
    public class CertificateService : ICertificateService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICertificateRepository _certificateRepository;

        public CertificateService(ICertificateRepository certificateRepository, IHttpContextAccessor httpContextAccessor)
        {
            _certificateRepository = certificateRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddCertif(AddCertificateVM certificateVM)
        {
            var certificate = CertificateMapper.ToModel(certificateVM);
            await _certificateRepository.AddCertif(certificate);
        }

        public async Task DeleteCertif(int certificateId)
        {
            var certificate = await _certificateRepository.GetCertifById(certificateId);
            if (certificate == null)
                throw new KeyNotFoundException("Certificat not found");

            await _certificateRepository.DeleteCertif(certificate);
        }

        public Task<IEnumerable<Certificat>> GetAllCertif()
        {
            return _certificateRepository.GetAllCertif();
        }

        public Task<Certificat> GetCertifById(int id)
        {
            return _certificateRepository.GetCertifById(id);
        }

        public async Task UpdateCertif(UpdateCertificateVM certificateVM)
        {
            var existingCertificate = await _certificateRepository.GetCertifById(certificateVM.id);
            if (existingCertificate == null)
                throw new KeyNotFoundException("Certificat not found");

            var updatedCertificate = CertificateMapper.UpdateModel(existingCertificate, certificateVM);
            await _certificateRepository.UpdateCertif(updatedCertificate);
        }

        public async Task<List<Certificat>> GetCertifsByDepartement(int departementId)
        {
            return await _certificateRepository.GetCertifsByDepartement(departementId);
        }

        public async Task UploadCertificatFileAsync(int certificatId, IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file), "No file uploaded");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                var certificat = await _certificateRepository.GetCertifById(certificatId);
                if (certificat == null)
                    throw new KeyNotFoundException("Certificat not found");

                certificat.uploadCertiftifUrl = fileBytes; // Updated to match the model property name
                await _certificateRepository.UpdateCertif(certificat);
            }
        }
        /*
        public Task<IEnumerable<Certificat>> GetSharedCertifsAsync()
        {
            return _certificateRepository.GetSharedCertifsAsync();
        }
        */
        public Task DeleteCertif(Certificat certificat)
        {
            throw new NotImplementedException();
        }
    }
}
