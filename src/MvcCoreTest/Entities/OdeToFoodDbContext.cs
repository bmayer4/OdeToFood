using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcCoreTest.Entities
{
    // IMO, we should new-up a new context for users instead of 
    // hijacking the OdeToFoodDbConext.
//    public class OdeToFoodDbContext : DbContext
    public class OdeToFoodDbContext : IdentityDbContext<User>
    {
        //http://stackoverflow.com/questions/38338475/no-database-provider-has-been-configured-for-this-dbcontext-on-signinmanager-p
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}