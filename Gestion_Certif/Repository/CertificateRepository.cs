using Gestion_Certif.Model;
using Gestion_Certif.ViewModels;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteCertif(Certificat certificat)
        {
            var certificate = await GetCertifById(certificat.id);
            if (certificate != null)
            {
                _context.Certificats.Remove(certificate);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Certificat>> GetAllCertif()
        {
            return await _context.Certificats
                .Include(c => c.departement) // Include Departement details
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
        /*
        public async Task<List<CertificateInfo>> GetCertificatesWithMostApprovalsAsync()
        {
            return await _context.Request_Certifs
                .Join(_context.Certificats, rc => rc.CertificatId, c => c.id, (rc, c) => new { rc, c })
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
        */
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
