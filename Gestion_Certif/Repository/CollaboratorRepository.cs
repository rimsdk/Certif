using Gestion_Certif.Model;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Certif.Repository
{
    public class CollaborateurRepository : ICollaboratorRepository
    {
        private readonly MyContext _context;

        public CollaborateurRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Collaborateur>> GetAllAsync()
        {
            return await _context.Users.OfType<Collaborateur>().ToListAsync();
        }

        public async Task<Collaborateur> GetByIdAsync(int id)
        {
            return await _context.Users.OfType<Collaborateur>().SingleOrDefaultAsync(c => c.id == id);
        }

        public async Task AddAsync(Collaborateur collaborateur)
        {
            _context.Users.Add(collaborateur);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collaborateur collaborateur)
        {
            _context.Entry(collaborateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var collaborateur = await GetByIdAsync(id);
            if (collaborateur != null)
            {
                _context.Users.Remove(collaborateur);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Collaborateur>> GetCollaborateursByDepartementAsync(int departementId)
        {
            return await _context.Users.OfType<Collaborateur>()
                .Where(c => c.DepartementId == departementId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Collaborateur>> GetByUsernameAsync(string username)
        {
            return await _context.Users.OfType<Collaborateur>()
                .Where(c => c.username == username)
                .ToListAsync();
        }
    }
}
