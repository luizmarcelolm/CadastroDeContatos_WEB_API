using CadastroContato.API.Model;
using Microsoft.EntityFrameworkCore;

namespace CadastroContato.API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
