using Gestion_Certif.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Certif.Repository
{
    public class AllCertifRepository : IAllCertifRepository
    {
        private readonly MyContext _context;

        public AllCertifRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AllCertif>> GetAllAsync()
        {
            return await _context.AllCertifs.Include(a => a.departement).ToListAsync();
        }

        public async Task<AllCertif> GetByIdAsync(int id)
        {
            return await _context.AllCertifs.Include(a => a.departement).FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task AddAsync(AllCertif certif)
        {
            await _context.AllCertifs.AddAsync(certif);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AllCertif certif)
        {
            _context.AllCertifs.Update(certif);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AllCertif certif)
        {
            _context.AllCertifs.Remove(certif);
            await _context.SaveChangesAsync();
        }

    }
}
