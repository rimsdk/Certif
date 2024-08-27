using Microsoft.EntityFrameworkCore;

namespace Gestion_Certif.Model
{
    public class MyContext : DbContext
    {
        public DbSet<Certificat> Certificats { get; set; }
     

        public DbSet<Request_certif> Request_Certifs { get; set; }
        public DbSet<AllCertif> AllCertifs { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<Collaborateur> Collaborateurs { get; set; }
        

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasDiscriminator<string>("UserType")
                    .HasValue<Collaborateur>("Collaborator")
                    .HasValue<Manager>("Manager");

            modelBuilder.Entity<Request_certif>()
                .HasOne(rc => rc.Sender)
                .WithMany(u => u.SentRequests)
                .HasForeignKey(rc => rc.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Request_certif>()
                .HasOne(rc => rc.Receiver)
                .WithMany(u => u.ReceivedRequests)
                .HasForeignKey(rc => rc.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
