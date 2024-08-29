using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;
using Gestion_Certif.Mappers; // Assurez-vous que ce namespace est correct
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Certif.Service
{
    public class AllCertifService : IAllCertifService
    {
        private readonly IAllCertifRepository _allCertifRepository;


        public AllCertifService(IAllCertifRepository allCertifRepository)
        {
            _allCertifRepository = allCertifRepository;
        }

        public async Task<IEnumerable<AllCertifVM>> GetAllCertifsAsync()
        {
            var certifs = await _allCertifRepository.GetAllAsync();
            return certifs.Select(certif => AllCertifMapper.ToViewModel(certif)); // Utilisez AllCertifMapper
        }

        public async Task<AllCertifVM> GetCertifByIdAsync(int id)
        {
            var certif = await _allCertifRepository.GetByIdAsync(id);
            return certif != null ? AllCertifMapper.ToViewModel(certif) : null; // Utilisez AllCertifMapper
        }

        public async Task<AllCertifVM> CreateCertifAsync(AllCertifVM certifDto)
        {
            var certif = AllCertifMapper.ToModel(certifDto); // Utilisez AllCertifMapper
            await _allCertifRepository.AddAsync(certif);
            return AllCertifMapper.ToViewModel(certif); // Utilisez AllCertifMapper
        }

        //public async Task<bool> UpdateCertifAsync(AllCertifVM certifDto)
        //{
        //    var certif = await _allCertifRepository.GetByIdAsync(certifDto.Id);
        //    if (certif == null)
        //    {
        //        return false;
        //    }

        //    certif = AllCertifMapper.UpdateModel(certif, certifDto); // Utilisez AllCertifMapper
        //    await _allCertifRepository.UpdateAsync(certif);
        //    return true;
        //}

        public async Task<bool> DeleteCertifAsync(int id)
        {
            var certif = await _allCertifRepository.GetByIdAsync(id);
            if (certif == null)
            {
                return false;
            }

            await _allCertifRepository.DeleteAsync(certif);
            return true;
        }
        public async Task<IEnumerable<AllCertifVM>> GetCertifsByDepartementAsync(int departementId)
        {
            var certifs = await _allCertifRepository.GetByDepartementIdAsync(departementId);
            return certifs.Select(c => AllCertifMapper.ToViewModel(c));
        }
    }
}
