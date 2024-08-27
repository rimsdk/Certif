using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Gestion_Certif.Model;

namespace Gestion_Certif.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        private readonly MyContext _context;

        public DepartementRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departement>> GetAllAsync()
        {
            return await _context.Departements.ToListAsync();
        }

        public async Task<Departement> GetByIdAsync(int id)
        {
            return await _context.Departements.FindAsync(id);
        }

        public async Task AddAsync(Departement departement)
        {
            await _context.Departements.AddAsync(departement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Departement departement)
        {
            _context.Departements.Update(departement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departement = await _context.Departements.FindAsync(id);
            if (departement != null)
            {
                _context.Departements.Remove(departement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
