using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ti2_Forum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class LojaXDb : IdentityDbContext<ApplicationUser>
    {
        public LojaXDb()
            : base("LojaXDbConnectionString", throwIfV1Schema: false)
        {
        }

        static LojaXDb()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<LojaXDb>(new ApplicationDbInitializer());
        }

        public static LojaXDb Create()
        {
            return new LojaXDb();
        }

        // definir as tabelas da BD
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }

        // método a ser executado no início da criação do Modelo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // eliminar a convenção de atribuir automaticamente o 'on Delete Cascade' nas FKs
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}