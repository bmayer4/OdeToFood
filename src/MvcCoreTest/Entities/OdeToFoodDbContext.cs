using Microsoft.EntityFrameworkCore;

namespace MvcCoreTest.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
        //http://stackoverflow.com/questions/38338475/no-database-provider-has-been-configured-for-this-dbcontext-on-signinmanager-p
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}