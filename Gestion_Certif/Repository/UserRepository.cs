using Gestion_Certif.Model;
using Gestion_Certif.Repository;
using Gestion_Certif.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly MyContext _context;

    public UserRepository(MyContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id); 
    }


    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.departement) 
            .ToListAsync();
    }

    public async Task<User> IsExisteAsync(AuthVM user)
    {
            User aaa = await _context.Users.FirstOrDefaultAsync(i => i.email == user.email);
        return aaa;

    }
    public async Task<AuthVM> UserExiste(AuthVM user)
    {
        var userEntity = await _context.Users
            .Where(i => i.email == user.email)
            .Select(u => new AuthVM
            {
                email = u.email,
                password = u.password
            })
            .FirstOrDefaultAsync();

        return userEntity;
    }




    public async Task<IEnumerable<User>> GetUsersByDepartementAsync(int departementId)
    {
        return await _context.Users
            .Where(u => u.DepartementId == departementId)
            .ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> DeleteByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    /*  public void AddUser() {
             var departement = new Departement
             {
                 name = "IT"
             };
          _context.Departements.Add(departement);
          _context.SaveChanges(); // Immediate save to generate ID

             // Create a Certificat related to the Departement
             var certificat = new Certificat
             {
                 certifName = "Data Security",
                 isShared = true,
                 uploadCertif = new byte[0], // Example: Empty byte array
                 achievementDate = DateTime.Now,
                 DepartementId = departement.id // Link to Departement ID
             };
          _context.Certificats.Add(certificat);
          _context.SaveChanges(); // Immediate save to generate ID

             // Create a Request_certif related to the Certificat
             var requestCertif = new Request_certif
             {
                 requestDate = DateTime.Now,
                 status = "Pending",
                 decisionReason = "Initial test entry",
                 required = true,
                 CertificatId = certificat.id // Link to Certificat ID
             };
          _context.Request_Certifs.Add(requestCertif);
          _context.SaveChanges(); // Immediate save to generate ID

             // Create a Manager and a Collaborateur with correct foreign keys
             var manager = new Manager
             {
                 username = "managerUser",
                 password = "securePassword123",
                 email = "mailto:manager@example.com",
                 role = "Manager",
                 DepartementId = departement.id,
                 Request_certifId = requestCertif.id
             };

             var collaborateur = new Collaborateur
             {
                 username = "collabUser",
                 password = "securePassword456",
                 email = "mailto:collab@example.com",
                 role = "Collaborateur",
                 DepartementId = departement.id,
                 Request_certifId = requestCertif.id
             };

          // Add both user types to the Users DbSet
          _context.Users.AddRange(manager, collaborateur);
          _context.SaveChanges();

         }*/


}
