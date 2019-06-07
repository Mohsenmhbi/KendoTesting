using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KendoTesting.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("KendoTest1", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        static ApplicationDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
        /// <summary>
        /// ///////////////////////
        /// </summary>
        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,Migrations.Configuration>());
        //}

        public System.Data.Entity.DbSet<KendoTesting.Models.Group> Groups { get; set; }

        public System.Data.Entity.DbSet<KendoTesting.Models.RangGroup> RangGroups { get; set; }

        public System.Data.Entity.DbSet<KendoTesting.Models.Product1> Product1s { get; set; }
    }
}