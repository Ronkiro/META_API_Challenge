using Microsoft.EntityFrameworkCore;

namespace ContatoAPI.Models
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options)
            : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}