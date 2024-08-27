using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestion_Certif.Model;

namespace Gestion_Certif.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly MyContext _context;

        public ManagerRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _context.Users.OfType<Manager>().ToListAsync();
        }

        public async Task<Manager> GetByIdAsync(int id)
        {
            return await _context.Users.OfType<Manager>().SingleOrDefaultAsync(c => c.id == id);
        }

        public async Task AddAsync(Manager manager)
        {
            _context.Users.Add(manager);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Manager manager)
        {
            _context.Entry(manager).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manager = await GetByIdAsync(id);
            if (manager != null)
            {
                _context.Users.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Manager>> GetManagersByDepartementAsync(int departementId)
        {
            return await _context.Users.OfType<Manager>()
                .Where(m => m.DepartementId == departementId)
                .ToListAsync();
        }


    }
}
