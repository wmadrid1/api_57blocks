using API_57Blocks.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_57Blocks
{
    public class APIContext : DbContext 
    {

        public APIContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
