using Microsoft.EntityFrameworkCore;

namespace ShortURL.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ShortUrlInfo> ShortUrlInfos { get; set; } 
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // Creating DB  on the first call
        }
    }
}