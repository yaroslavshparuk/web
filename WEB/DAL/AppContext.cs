using Microsoft.EntityFrameworkCore;

namespace WEB.DAL
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
    : base(options) { }

        public DbSet<Models.User> Users { get; set; }
    }
}
