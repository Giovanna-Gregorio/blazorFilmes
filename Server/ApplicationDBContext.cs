using BlazorFilmes.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorFilmes.Server
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}