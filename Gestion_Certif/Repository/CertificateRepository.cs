using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;
using Microsoft.EntityFrameworkCore;
using static Gestion_Certif.ViewModels.AddCertificateVM;

namespace Gestion_Certif.Repository
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly MyContext _context;
        public CertificateRepository(MyContext myContext)
        {
            this._context = myContext;
        }

        public async Task AddCertif(Certificat certificat)
        {
            var certificate = await GetCertifById(certificat.id);

            if (certificate is null)
            {
                _context.Certificats.Add(certificat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCertif(int id)
        {
            var certificat = await _context.Certificats.FindAsync(id);
            if (certificat != null)
            {
                _context.Certificats.Remove(certificat);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<AddCertificateVM> GetById(int id)
        {
            var certificat = await _context.Certificats
                .Where(c => c.id == id)
                .Select(c => new AddCertificateVM
                {
                    Id = c.id,
                    CertifName = c.certifName,
                    CertifPictureUrl = c.CertifPictureUrl,
                    AchievementDate = c.achievementDate,
                    DepartementId = c.DepartementId,
                    UserId = c.userId
                })
                .FirstOrDefaultAsync();

            if (certificat == null)
            {
                throw new KeyNotFoundException("Certificat not found");
            }

            return certificat;
        }
        public async Task<IEnumerable<AddCertificateVM>> GetAllCertif()
        {
            return await _context.Certificats
                .Select(c => new AddCertificateVM
                {
                    Id = c.id,
                    CertifName = c.certifName,
                    CertifPictureUrl = c.CertifPictureUrl,
                    AchievementDate = c.achievementDate,
                    DepartementId = c.DepartementId,
                    UserId = c.userId
                })
                .ToListAsync();
        }

        public Task<Certificat> GetCertifById(int id)
        {
            return _context.Certificats
                .Include(c => c.departement) // Include Departement details
                .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task UpdateCertif(Certificat certificat)
        {
            _context.Entry(certificat).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
        public async Task<List<CertificateInfo>> GetCertificatesWithMostApprovalsAsync()
        {
            return await _context.Request_Certifs
                .Join(_context.Certificats, rc => rc.AllCertifId, c => c.id, (rc, c) => new { rc, c })
                .Join(_context.Departements, crc => crc.c.DepartementId, d => d.id, (crc, d) => new { crc.rc, crc.c, d })
                .Where(x => x.rc.status == "Approved")
                .GroupBy(x => new { x.c.id, x.c.certifName, x.d.name })
                .Select(g => new CertificateInfo
                {
                    CertificatId = g.Key.id,
                    CertifName = g.Key.certifName,
                    DepartmentName = g.Key.name,
                    ApprovedRequestCount = g.Count()
                })
                .OrderByDescending(x => x.ApprovedRequestCount)
                .ThenBy(x => x.DepartmentName)
                .ToListAsync();
        }
        
        public async Task<List<Certificat>> GetCertifsByDepartement(int departementId)
        {
            return await _context.Certificats
                .Where(c => c.DepartementId == departementId)
                .Include(c => c.departement) // Include Departement details
                .ToListAsync();
        }
        /*
        public async Task<IEnumerable<Certificat>> GetSharedCertifsAsync()
        {
            return await _context.Certificats
                .Where(c => c.isShared)
                .Include(c => c.departement) // Include Departement details
                .ToListAsync();
        }
        */
        public Task<List<CertificateWithCollaboratorCountVM>> GetAllCollaboratorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
